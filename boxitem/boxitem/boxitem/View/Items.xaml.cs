using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace boxitem
{
    /// <summary>
    /// Interaction logic for Items.xaml
    /// </summary>
    public partial class Items : Window
    {
        CurrentInfo currentbox = new CurrentInfo();

        public Items(int boxid)
        {
            InitializeComponent();
            DisplayItems(boxid);

        }

        private void DisplayItems(int boxid)
        {
            using (var database = new BD.BoxesEntities())
            {
                var allitems = database.Items
                    .ToList()
                    .Where(x => x.BoxId == currentbox.BoxID)
                    .Select(x => ViewModel.ItemViewModel.Create(x.Name, x.Number, x.Description,x.ItemId))                    
                    .ToList();

                datagridItems.ItemsSource = allitems;

                database.SaveChanges();
            }
        }

        private void btnMoveItems_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                object item = datagridItems.SelectedItem;
                string ID = (datagridItems.SelectedCells[3].Column.GetCellContent(item) as TextBlock).Text;
                int IID = int.Parse(ID);
                currentbox.ItemID = IID;
                BoxesList boxlist = new BoxesList();
                boxlist.Show();
            }
            catch (Exception)
            {
                MessageBox.Show("Nie wybrano przedmiotu!");
            }
            
        }

        private void btnCancelItems_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnAddItems_Click(object sender, RoutedEventArgs e)
        {
            AddItem additem = new AddItem();
            additem.Show();
        }

        private void btnDeleteItems_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Na pewno chcesz usunąć przedmiot?", "Usuwanie", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
            {
                Close();                
            }
            else
            {
                object item = datagridItems.SelectedItem;
                string ID = (datagridItems.SelectedCells[3].Column.GetCellContent(item) as TextBlock).Text;
                int IID = int.Parse(ID);
              
                BD.BoxesEntities dbdb = new BD.BoxesEntities();
                var deleteitem = (from stu in dbdb.Items
                                 where stu.ItemId == IID
                                 select stu).SingleOrDefault();

                dbdb.Items.Remove(deleteitem);
                dbdb.SaveChanges();
                DisplayItems(currentbox.BoxID);         
            }
        }

        private void btnRefreshItems_Click(object sender, RoutedEventArgs e)
        {
            DisplayItems(currentbox.BoxID);
        }

        private void btnAddPhotoItems_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                object item = datagridItems.SelectedItem;
                string ID = (datagridItems.SelectedCells[3].Column.GetCellContent(item) as TextBlock).Text;
                int IID = int.Parse(ID);
                currentbox.ItemID = IID;
                OFileDialog();
                FileStream Stream = new FileStream(tbFilePathItems.Text, FileMode.Open, FileAccess.Read);
                StreamReader Reader = new StreamReader(Stream);
                Byte[] ImgData = new Byte[Stream.Length - 1];
                Stream.Read(ImgData, 0, (int)Stream.Length - 1);


                BD.BoxesEntities dbdb = new BD.BoxesEntities();
                var nowe = (from stu in dbdb.Items
                            where stu.ItemId == IID
                            select stu).SingleOrDefault();

                nowe.Picture = ImgData;
                dbdb.SaveChanges();

               // MessageBox.Show(datagridItems.SelectedIndex.ToString());
                imageItems.Source = LoadImage(ImgData);
            }
            catch (Exception)
            {
                MessageBox.Show("Nie wybrano przedmiotu!");
            }
            
        }

        private void OFileDialog()
        {            
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                tbFilePathItems.Text = op.FileName;
                imageItems.Source = new BitmapImage(new Uri(op.FileName));
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

        private void btnDeletePhotoItems_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                object item = datagridItems.SelectedItem;
                string ID = (datagridItems.SelectedCells[3].Column.GetCellContent(item) as TextBlock).Text;
                int IID = int.Parse(ID);
                if (MessageBox.Show("Na pewno chcesz usunąć zdjęcie przedmiotu?", "Usuwanie", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                {
                    Close();
                }
                else
                {
                    BD.BoxesEntities dbdb = new BD.BoxesEntities();
                    var currentimage = (from stu in dbdb.Boxes
                                        where stu.BoxID == IID
                                        select stu).SingleOrDefault();

                    if (currentimage.Picture != null)
                    {
                        currentimage.Picture = null;
                        imageItems.Source = null;
                        dbdb.SaveChanges();
                    }

                }
            }
            catch (Exception)
            {
                MessageBox.Show("Nie wybrano przedmiotu!");
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

        private void btnShowItems_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                object item = datagridItems.SelectedItem;
                string ID = (datagridItems.SelectedCells[3].Column.GetCellContent(item) as TextBlock).Text;
                int IID = int.Parse(ID);

                BD.BoxesEntities dbdb = new BD.BoxesEntities();
                var currentimage = (from stu in dbdb.Items
                                    where stu.ItemId == IID
                                    select stu).SingleOrDefault();

                if (currentimage.Picture != null)
                {
                    var imagefromdb = BitmapImageFromBytes(currentimage.Picture);
                    imageItems.Source = imagefromdb;
                }
                else
                {
                    imageItems.Source = null;
                }
            }
            
            catch(Exception)
            {
                MessageBox.Show("Nie wybrano przedmiotu.");
            }

        }
    }
}
