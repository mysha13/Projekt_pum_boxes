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
        BD.BoxesEntities database = new BD.BoxesEntities();

        public Boxes()
        {
            InitializeComponent();
            DisplayBoxesFromUser(currentuser.UserID);
        }

        public void DisplayBoxesFromUser(int iduser)
        {
            //var boxes = database.Boxes
            //    .ToList()
            //    .Where(x => x.UserId == iduser)
            //    .Select(x => ViewModel.BoxViewModel.Create(x.Name, x.Number, x.Description, x.BoxID))
            //    .ToList();

            //List<ViewModel.BoxViewModel> boxes = new List<ViewModel.BoxViewModel>();
            
            DBAction.GetData getallboxes = new DBAction.GetData();
            //boxes=getallboxes.DispalyBoxes(iduser);
            datagridBoxes.ItemsSource = getallboxes.DispalyBoxes(iduser); //boxes;    
        }
        
        private void btnRefreshBoxes_Click(object sender, RoutedEventArgs e)
        {
            DisplayBoxesFromUser(currentuser.UserID);
        }
                
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

                    //ShowBoxPhoto(currentboxID);
                    DBAction.GetData getphoto = new DBAction.GetData();

                    byte[] photo=getphoto.GetAndShowBoxPhoto(currentboxID);

                    CheckIfPhotoExist(photo);
                    
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

        private void CheckIfPhotoExist(byte[] photo)
        {
            if (photo != null)
            {
                var imagefromdb = DBAction.ImageData.BitmapImageFromBytes(photo);
                imageBoxes.Source = imagefromdb;
            }
            else
            {
                imageBoxes.Source = null;
            }
        }
                
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

        private void btnCancelBoxes_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
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
                    DBAction.DeleteData deletebox = new DBAction.DeleteData();
                    deletebox.DeleteBox(currentboxID);
                    DisplayBoxesFromUser(currentuser.UserID);
                    //DeleteCurrentBox(currentboxID);                    
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Nie wybrano pudełka!");
            }
        }

        //public void DeleteCurrentBox(int currentboxID)
        //{
        //    DBAction.DeleteData delete = new DBAction.DeleteData();
        //    delete.DeleteBox(currentboxID);            
        //    DisplayBoxesFromUser(currentuser.UserID);
        //}

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
                    byte[] photo=deleteboxphoto.DeleteBoxPhoto(currentboxID);


                    //var currentboximage = (from box in database.Boxes
                    //                       where box.BoxID == currentboxID
                    //                       select box).SingleOrDefault();

                    //if (photo != null)
                    //{
                        //photo = null;
                        imageBoxes.Source = null;
                        database.SaveChanges();
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
                currentuser.BoxID = currentboxID;
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
            
            DBAction.AddData addphoto = new DBAction.AddData();
            addphoto.SaveBoxPhoto(ImgData);

            this.Hide();
            View.Boxes showagain = new View.Boxes();
            showagain.ShowDialog();
            this.Close();
            
            var image= DBAction.ImageData.LoadImage(ImgData);
            imageBoxes.Source = image;//DBAction.ImageData.LoadImage(ImgData);
        }

        //private void ShowBoxPhoto(int currentboxID)
        //{

        //    var showboximage = (from stu in database.Boxes
        //                        where stu.BoxID == currentboxID
        //                        select stu).SingleOrDefault();

        //    if (showboximage.Picture != null)
        //    {
        //        var imagefromdb = DBAction.ImageData.BitmapImageFromBytes(showboximage.Picture);
        //        imageBoxes.Source = imagefromdb;
        //    }
        //    else
        //    {
        //        imageBoxes.Source = null;
        //    }
        //}
        #endregion
    }
}
