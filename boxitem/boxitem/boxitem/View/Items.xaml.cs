using Microsoft.Win32;
using System;
using System.Collections;
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
        CurrentInfo currentinfo = new CurrentInfo();
        BD.BoxesEntities database = new BD.BoxesEntities();

        public Items()
        {
            InitializeComponent();
            DisplayItemsFromBox(currentinfo.BoxID);

        }

        private void DisplayItemsFromBox(int boxid)
        {
            //List<ViewModel.ItemViewModel> allitems = new List<ViewModel.ItemViewModel>();
            DBAction.GetData getallitems = new DBAction.GetData();

            //allitems = database.Items
            //    .ToList()
            //    .Where(x => x.BoxId == currentinfo.BoxID)
            //    .Select(x => ViewModel.ItemViewModel.Create(x.Name, x.Number, x.Description, x.ItemId))
            //    .ToList();

            datagridItems.ItemsSource = getallitems.DisplayItems(currentinfo.BoxID);
        }
        
        private void btnRefreshItems_Click(object sender, RoutedEventArgs e)
        {
            DisplayItemsFromBox(currentinfo.BoxID);
        }
                 
        //private void btnShowItems_Click(object sender, RoutedEventArgs e)
        //{
        //    try
        //    {
        //        int currentitemID = GetSelectedItemId();
                
        //        var currentimage = (from stu in database.Items
        //                            where stu.ItemId == currentitemID
        //                            select stu).SingleOrDefault();

        //        if (currentimage.Picture != null)
        //        {
        //            var imagefromdb = BitmapImageFromBytes(currentimage.Picture);
        //            imageItems.Source = imagefromdb;
        //        }
        //        else
        //        {
        //            imageItems.Source = null;
        //        }
        //    }
            
        //    catch(Exception)
        //    {
        //        MessageBox.Show("Nie wybrano przedmiotu.");
        //    }
        //}

        private int GetSelectedItemId()
        {
            object item = datagridItems.SelectedItem;
            string ID = (datagridItems.SelectedCells[3].Column.GetCellContent(item) as TextBlock).Text;
            int currentID = int.Parse(ID);
            return currentID;
        }

        private void datagridItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var row_list = GetDataGridRows(datagridItems);

                foreach (DataGridRow single_row in row_list)
                {
                    if (single_row.IsSelected == true)
                    {
                        int currentitemID = GetSelectedItemId();
                        DBAction.GetData getphoto = new DBAction.GetData();
                        byte[] photo = getphoto.GetItemPhoto(currentitemID);
                        CheckIfPhotoExist(photo);                        
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

        private void CheckIfPhotoExist(byte[] photo)
        {
            if (photo != null)
            {
                var imagefromdb = DBAction.ImageData.BitmapImageFromBytes(photo);
                imageItems.Source = imagefromdb;
            }
            else
            {
                imageItems.Source = null;
            }
        }
        
        #region NextWindows

        private void btnAddItems_Click(object sender, RoutedEventArgs e)
        {
            AddItem additem = new AddItem();
            additem.Show();
        }

        private void btnCancelItems_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        #endregion

        #region ActionOnItem

        private void btnDeleteItems_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int currentitemID = GetSelectedItemId();

                if (MessageBox.Show("Na pewno chcesz usunąć przedmiot?", "Usuwanie",
                    MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    DBAction.DeleteData deleteitem = new DBAction.DeleteData();
                    deleteitem.DeleteItem(currentitemID);
                    DisplayItemsFromBox(currentinfo.BoxID);
                }
            }
            catch
            {
                MessageBox.Show("Nie wybrano przedmiotu!");
            }
        }

        private void btnMoveItems_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int currentitemID = GetSelectedItemId();
                currentinfo.ItemID = currentitemID;
                BoxesList boxlist = new BoxesList();
                boxlist.Show();
            }
            catch (Exception)
            {
                MessageBox.Show("Nie wybrano przedmiotu!");
            }
        }

        #endregion

        #region ActionOnPhoto

        private void OpenFileDialog()
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

        private void btnAddPhotoItems_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int currentitemID = GetSelectedItemId();
                currentinfo.ItemID = currentitemID;

                OpenFileDialog();
                GetAndSaveItemPhoto(currentitemID);
                
            }
            catch (Exception)
            {
                MessageBox.Show("Nie wybrano przedmiotu!");
            }
        }

        private void  GetAndSaveItemPhoto(int currentitemID)
        {
            FileStream Stream = new FileStream(tbFilePathItems.Text, FileMode.Open, FileAccess.Read);
            StreamReader Reader = new StreamReader(Stream);
            Byte[] ImgData = new Byte[Stream.Length - 1];
            Stream.Read(ImgData, 0, (int)Stream.Length - 1);

            DBAction.AddData addphoto = new DBAction.AddData();
            addphoto.SaveItemPhoto(ImgData);

            this.Hide();
            Items showagain = new Items();
            showagain.ShowDialog();
            this.Close();

            var image = DBAction.ImageData.LoadImage(ImgData);
            imageItems.Source = image;
        }

        private void btnDeletePhotoItems_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int currentitemID = GetSelectedItemId();
                if (MessageBox.Show("Na pewno chcesz usunąć zdjęcie przedmiotu?", "Usuwanie",
                    MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    //var currentimage = (from stu in database.Items
                    //                    where stu.ItemId == currentitemID
                    //                    select stu).SingleOrDefault();
                    DBAction.DeleteData deletecurrentimage = new DBAction.DeleteData();
                    byte[] photo = deletecurrentimage.DeleteItemPhoto(currentitemID);
                    
                    //Items item = new Items();
                    imageItems.Source = null;

                }
            }
            catch (Exception)
            {
                MessageBox.Show("Nie wybrano przedmiotu!");
            }
        }

        #endregion


    }
}
