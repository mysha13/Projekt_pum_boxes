using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.IO;
using System.Data;
using System.Collections;

namespace boxitem.View
{
    /// <summary>
    /// Interaction logic for Boxes.xaml
    /// </summary>
    public partial class Boxes : Window
    {
        CurrentInfo currentuser = new CurrentInfo();
        CurrentInfo currentbox = new CurrentInfo();
        BD.BoxesEntities database = new BD.BoxesEntities();

        public Boxes()
        {
            InitializeComponent();
                DisplayBoxes(currentuser.UserID);

            
        }
        public void DisplayBoxes(int iduser)
        {            
            using (var bb = new BD.BoxesEntities())
            { 
                var boxes = bb.Boxes                                   
                    .ToList()
                    .Where(x=>x.UserId== iduser)
                    .Select(x => ViewModel.BoxViewModel.Create(x.Name, x.Number, x.Description, x.BoxID))                    
                    .ToList();               

               datagridBoxes.ItemsSource = boxes;               
            }
        }

        private void btnCancelBoxes_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnFindItem_Click(object sender, RoutedEventArgs e)
        {
            FindItem find = new FindItem();
            find.Show();
        }

        private void btnChooseBoxes_Click(object sender, RoutedEventArgs e)
        {        
            try
            {
                //object item = datagridBoxes.SelectedItem;
                //string IDitem = (datagridBoxes.SelectedCells[4].Column.GetCellContent(item) as TextBlock).Text;
                int ID = GetSelectedItemId();//int.Parse(IDitem);
                
                currentbox.BoxID = ID;
                //MessageBox.Show(currentbox.UserID.ToString());  
                Items items = new Items(currentbox.BoxID);
                items.Show();                  
            }
            catch
            {
                MessageBox.Show("Nie wybrano żadnego pudełka. \nWybierz istniejące lub dodaj nowe.");
            }
        }

        private void btnAddPhotoBoxes_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int IID = GetSelectedItemId();

                OFileDialog();

                FileStream Stream = new FileStream(tbFilePathBoxes.Text, FileMode.Open, FileAccess.Read);
                StreamReader Reader = new StreamReader(Stream);
                Byte[] ImgData = new Byte[Stream.Length - 1];
                Stream.Read(ImgData, 0, (int)Stream.Length - 1);



               // BD.BoxesEntities dbdb = new BD.BoxesEntities();
                var nowe = (from stu in database.Boxes
                            where stu.BoxID == IID
                            select stu).SingleOrDefault();

                nowe.Picture = ImgData;
                database.SaveChanges();

                //MessageBox.Show(datagridBoxes.SelectedIndex.ToString());

                imageBoxes.Source = LoadImage(ImgData);
            }
            catch (Exception)
            {
                MessageBox.Show("Nie wybrano pudełka!");
            }
            
                        
        }

        private static BitmapImage LoadImage(byte[] imageData)
        {
            if (imageData == null || imageData.Length == 0) return null;
            var image = new BitmapImage();
            using (var mem = new MemoryStream(imageData))
            {
                mem.Position = 0;
                image.BeginInit();
                image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.UriSource = null;
                image.StreamSource = mem;
                image.EndInit();
            }
            image.Freeze();
            return image;
        }

        private void btnAddBoxes_Click(object sender, RoutedEventArgs e)
        {
            AddBox addbox = new AddBox();
            addbox.Show();
        }

        private void btnDeleteBoxes_Click(object sender, RoutedEventArgs e)
        {                     
            if (MessageBox.Show("Na pewno chcesz usunąć pudełko z całą zawartością?", "Usuwanie", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                
            {
                Close();
            }
            else
            {
                int IID = GetSelectedItemId();
                 
                //BD.BoxesEntities dbdb = new BD.BoxesEntities();                
                var deletebox = (from stu in database.Boxes
                                where stu.BoxID == IID
                                select stu).SingleOrDefault();

                database.Boxes.Remove(deletebox);
                database.SaveChanges();
                DisplayBoxes(currentuser.UserID);
            }
        }
        private void OFileDialog()
        {
            // wczytywanie zdjęcia z katalogow
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                tbFilePathBoxes.Text = op.FileName;
                imageBoxes.Source = new BitmapImage(new Uri(op.FileName));
                
            }
            
        }

        
        private void btnRefreshBoxes_Click(object sender, RoutedEventArgs e)
        {
            DisplayBoxes(currentuser.UserID);
        }

        private void datagridBoxes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                int IID = GetSelectedItemId();
                               
                var currentimage = (from stu in database.Boxes
                                    where stu.BoxID == IID
                                    select stu).SingleOrDefault();

                if (currentimage.Picture != null)
                {
                    var imagenwe = BitmapImageFromBytes(currentimage.Picture);
                    imageBoxes.Source = imagenwe;
                    
                }
                else
                {
                    imageBoxes.Source = null;
                }
            }
            catch (Exception)
            {

                throw;
            }
            
           

            
        }
              
        public static BitmapImage BitmapImageFromBytes(byte[] bytes)
        {
            BitmapImage image = null;
            MemoryStream stream = null;
            try
            {
                stream = new MemoryStream(bytes);
                stream.Seek(0, SeekOrigin.Begin);
                System.Drawing.Image img = System.Drawing.Image.FromStream(stream);
                image = new BitmapImage();
                image.BeginInit();
                MemoryStream ms = new MemoryStream();
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                ms.Seek(0, SeekOrigin.Begin);
                image.StreamSource = ms;
                image.StreamSource.Seek(0, SeekOrigin.Begin);
                image.EndInit();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                stream.Close();
                stream.Dispose();
            }
            return image;
        }

        private void btnShowBoxes_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int IID = GetSelectedItemId();
                //BD.BoxesEntities dbdb = new BD.BoxesEntities();
                var currentimage = (from stu in database.Boxes
                                    where stu.BoxID == IID
                                    select stu).SingleOrDefault();

                if (currentimage.Picture != null)
                {
                    var imagefromdb = BitmapImageFromBytes(currentimage.Picture);
                    imageBoxes.Source = imagefromdb;
                }
                else
                {
                    imageBoxes.Source = null;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Nie wybrano pudełka.");
            }
            
        }

        private void btnDeletePhotoBoxes_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                int IID = GetSelectedItemId();

                if (MessageBox.Show("Na pewno chcesz usunąć zdjęcie pudełka?", "Usuwanie", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)

                {
                    Close();
                }
                else
                {
                    //BD.BoxesEntities dbdb = new BD.BoxesEntities();
                    var currentimage = (from stu in database.Boxes
                                        where stu.BoxID == IID
                                        select stu).SingleOrDefault();

                    if (currentimage.Picture != null)
                    {
                        currentimage.Picture = null;
                        imageBoxes.Source = null;
                        database.SaveChanges();
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Nie wybrano pudełka!");
            }
            

        }

        private void datagridBoxes_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

            try
            {
                var row_list = GetDataGridRows(datagridBoxes);
                foreach (DataGridRow single_row in row_list)
                {
                    if (single_row.IsSelected == true)
                    {
                        int IID = GetSelectedItemId();
                        //BD.BoxesEntities dbdb = new BD.BoxesEntities();
                        var currentimage = (from stu in database.Boxes
                                            where stu.BoxID == IID
                                            select stu).SingleOrDefault();
                        if (currentimage.Picture != null)
                        {
                            var imagefromdb = BitmapImageFromBytes(currentimage.Picture);
                            imageBoxes.Source = imagefromdb;
                        }
                        else
                        {
                            imageBoxes.Source = null;
                        }
                    }
                }

            }
            catch { }
        }
        public IEnumerable<DataGridRow> GetDataGridRows(DataGrid grid)
        {
            var itemsSource = grid.ItemsSource as IEnumerable;
            if (null == itemsSource) yield return null;
            foreach (var item in itemsSource)
            {
                var row = grid.ItemContainerGenerator.ContainerFromItem(item) as DataGridRow;
                if (null != row) yield return row;
            }
        }
        public int GetSelectedItemId()
        {
            object item = datagridBoxes.SelectedItem;
            string ID = (datagridBoxes.SelectedCells[4].Column.GetCellContent(item) as TextBlock).Text;
            int IID = int.Parse(ID);
            return IID;
        }
    }
}
