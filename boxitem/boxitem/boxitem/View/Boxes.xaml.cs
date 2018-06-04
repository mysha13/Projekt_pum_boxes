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
        //CurrentInfo currentbox = new CurrentInfo();
        BD.BoxesEntities database = new BD.BoxesEntities();

        public Boxes()
        {
            InitializeComponent();
            DisplayBoxes(currentuser.UserID);
        }

        public void DisplayBoxes(int iduser)
        {
            var boxes = database.Boxes
                .ToList()
                .Where(x => x.UserId == iduser)
                .Select(x => ViewModel.BoxViewModel.Create(x.Name, x.Number, x.Description, x.BoxID))
                .ToList();

            datagridBoxes.ItemsSource = boxes;    
        }

        private void btnCancelBoxes_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        
        private void btnRefreshBoxes_Click(object sender, RoutedEventArgs e)
        {
            DisplayBoxes(currentuser.UserID);
        }
        
        //private void btnShowBoxes_Click(object sender, RoutedEventArgs e)
        //{
        //    try
        //    {
        //        int currentboxID = GetSelectedItemId();

        //        var currentimage = (from stu in database.Boxes
        //                            where stu.BoxID == currentboxID
        //                            select stu).SingleOrDefault();

        //        if (currentimage.Picture != null)
        //        {
        //            var imagefromdb = BitmapImageFromBytes(currentimage.Picture);
        //            imageBoxes.Source = imagefromdb;
        //        }
        //        else
        //        {
        //            imageBoxes.Source = null;
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        MessageBox.Show("Nie wybrano pudełka.");
        //    }            
        //}
        
        private void datagridBoxes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //try
            //{
                var row_list = GetDataGridRows(datagridBoxes);

                foreach (DataGridRow single_row in row_list)
                {
                    if (single_row.IsSelected == true)
                    {
                        int currentboxID = GetSelectedItemId();

                        ShowBoxPhoto(currentboxID);
                        //var showboximage = (from stu in database.Boxes
                        //                    where stu.BoxID == currentboxID
                        //                    select stu).SingleOrDefault();

                        //if (showboximage.Picture != null)
                        //{
                        //    var imagefromdb = BitmapImageFromBytes(showboximage.Picture);
                        //    imageBoxes.Source = imagefromdb;
                        //}
                        //else
                        //{
                        //    imageBoxes.Source = null;
                        //}
                    }
                }
            //}
            //catch { }
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

        private int GetSelectedItemId()
        {
            object item = datagridBoxes.SelectedItem;
            string ID = (datagridBoxes.SelectedCells[4].Column.GetCellContent(item) as TextBlock).Text;
            int currentID = int.Parse(ID);
            return currentID;
        }
        
        #region ImagesAction

        //private static BitmapImage LoadImage(byte[] imageData)
        //{
        //    if (imageData == null || imageData.Length == 0) return null;
        //    var image = new BitmapImage();
        //    using (var mem = new MemoryStream(imageData))
        //    {
        //        mem.Position = 0;
        //        image.BeginInit();
        //        image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
        //        image.CacheOption = BitmapCacheOption.OnLoad;
        //        image.UriSource = null;
        //        image.StreamSource = mem;
        //        image.EndInit();
        //    }
        //    image.Freeze();
        //    return image;
        //}

        //private static BitmapImage BitmapImageFromBytes(byte[] bytes)
        //{
        //    BitmapImage image = null;
        //    MemoryStream stream = null;
        //    try
        //    {
        //        stream = new MemoryStream(bytes);
        //        stream.Seek(0, SeekOrigin.Begin);
        //        System.Drawing.Image img = System.Drawing.Image.FromStream(stream);
        //        image = new BitmapImage();
        //        image.BeginInit();
        //        MemoryStream ms = new MemoryStream();
        //        img.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
        //        ms.Seek(0, SeekOrigin.Begin);
        //        image.StreamSource = ms;
        //        image.StreamSource.Seek(0, SeekOrigin.Begin);
        //        image.EndInit();
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //    finally
        //    {
        //        stream.Close();
        //        stream.Dispose();
        //    }
        //    return image;
        //}

        #endregion

        #region NextWindows

        private void btnFindItem_Click(object sender, RoutedEventArgs e)
        {
            FindItem find = new FindItem();
            find.Show();
        }

        private void btnAddBoxes_Click(object sender, RoutedEventArgs e)
        {
            AddBox addbox = new AddBox();
            addbox.Show();
        }

        #endregion

        #region ActionOnBox

        private void btnChooseBoxes_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int id = GetSelectedItemId();
                currentuser.BoxID = id;
                Items items = new Items();
                items.Show();
            }
            catch
            {
                MessageBox.Show("Nie wybrano żadnego pudełka. \nWybierz istniejące lub dodaj nowe.");
            }
        }

        private void btnDeleteBoxes_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int currentboxID = GetSelectedItemId();

                if (MessageBox.Show("Na pewno chcesz usunąć pudełko z całą zawartością?", "Usuwanie",
                    MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)

                {
                    DeleteCurrentBox(currentboxID);
                    //var deletebox = (from stu in database.Boxes
                    //                 where stu.BoxID == currentboxID
                    //                 select stu).SingleOrDefault();

                    //database.Boxes.Remove(deletebox);
                    //database.SaveChanges();
                    //DisplayBoxes(currentuser.UserID);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Nie wybrano pudełka!");
            }
        }

        public void DeleteCurrentBox(int currentboxID)
        {
            DBAction.DeleteData delete = new DBAction.DeleteData();
            delete.DeleteBox(currentboxID);
            
            //BD.Box deletebox = new BD.Box();
            // deletebox = (from stu in database.Boxes
            //                 where stu.BoxID == currentboxID
            //                 select stu).SingleOrDefault();

            //database.Boxes.Remove(deletebox);
            //database.SaveChanges();
            DisplayBoxes(currentuser.UserID);
        }

        #endregion

        #region ActionOnPhoto

        private void btnDeletePhotoBoxes_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int currentboxID = GetSelectedItemId();

                if (MessageBox.Show("Na pewno chcesz usunąć zdjęcie pudełka?", "Usuwanie",
                    MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    //DeleteBoxPhoto(currentboxID);
                    DBAction.DeleteData deleteboxphoto = new DBAction.DeleteData();
                    deleteboxphoto.DeleteBoxPhoto(currentboxID);
                    //var currentboximage = (from box in database.Boxes
                    //                       where box.BoxID == currentboxID
                    //                       select box).SingleOrDefault();

                    //if (currentboximage.Picture != null)
                    //{
                    //    currentboximage.Picture = null;
                    //    imageBoxes.Source = null;
                    //    database.SaveChanges();
                    //}
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Nie wybrano pudełka!");
            }
        }

        private void btnAddPhotoBoxes_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int currentboxID = GetSelectedItemId();

                OpenFileDialog();

                GetAndSavePhoto(currentboxID);

                //FileStream Stream = new FileStream(tbFilePathBoxes.Text, FileMode.Open, FileAccess.Read);
                //StreamReader Reader = new StreamReader(Stream);
                //Byte[] ImgData = new Byte[Stream.Length - 1];
                //Stream.Read(ImgData, 0, (int)Stream.Length - 1);

                //var box = (from b in database.Boxes
                //            where b.BoxID == currentboxID
                //           select b).SingleOrDefault();

                //box.Picture = ImgData;
                //database.SaveChanges();

                //imageBoxes.Source = LoadImage(ImgData);
            }
            catch (Exception)
            {
                MessageBox.Show("Nie wybrano pudełka!");
            }
        }

        private void OpenFileDialog()
        {
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

        //private void DeleteBoxPhoto(int currentboxID)
        //{
        //    var currentboximage = (from box in database.Boxes
        //                           where box.BoxID == currentboxID
        //                           select box).SingleOrDefault();

        //    if (currentboximage.Picture != null)
        //    {
        //        currentboximage.Picture = null;
        //        imageBoxes.Source = null;
        //        database.SaveChanges();
        //    }
        //}

        private void GetAndSavePhoto(int currentboxID)
        {
            FileStream Stream = new FileStream(tbFilePathBoxes.Text, FileMode.Open, FileAccess.Read);
            StreamReader Reader = new StreamReader(Stream);
            Byte[] ImgData = new Byte[Stream.Length - 1];
            Stream.Read(ImgData, 0, (int)Stream.Length - 1);

            var box = (from b in database.Boxes
                       where b.BoxID == currentboxID
                       select b).SingleOrDefault();

            box.Picture = ImgData;
            database.SaveChanges();

            imageBoxes.Source = DBAction.ImageData.LoadImage(ImgData);
        }

        private void ShowBoxPhoto(int currentboxID)
        {
            var showboximage = (from stu in database.Boxes
                                where stu.BoxID == currentboxID
                                select stu).SingleOrDefault();

            if (showboximage.Picture != null)
            {
                var imagefromdb = DBAction.ImageData.BitmapImageFromBytes(showboximage.Picture);
                imageBoxes.Source = imagefromdb;
            }
            else
            {
                imageBoxes.Source = null;
            }
        }
        #endregion
    }
}
