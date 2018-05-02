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

namespace boxitem.View
{
    /// <summary>
    /// Interaction logic for Boxes.xaml
    /// </summary>
    public partial class Boxes : Window
    {

        public Boxes(int id)
        {
            InitializeComponent();
            //CurrentInfo currentuser = new CurrentInfo();
            //MessageBox.Show(currentuser.ToString());
            MessageBox.Show(id.ToString());
                DisplayBoxes(id);
        }
        private void DisplayBoxes(int id)
        {            
            using (var bb = new BD.BoxesEntities())
            { 
                //IQueryable<Boxes> box =
                //        from u in bb.Boxes
                //        where u.UserId=id;
                //        select u;

               
               
                var boxes = bb.Boxes                                    //-----BŁĄD
                    .ToList()
                    .Where(x=>x.UserId==id)
                    .Select(x => ViewModel.BoxViewModel.Create(x.Name, x.Number, x.Description, x.BoxID))                    
                    .ToList();               

                datagridBoxes.ItemsSource = boxes;

               // boxes.Add(ViewModel.BoxViewModel.Create("asd", 234, "asd"));
                bb.SaveChanges();

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
            CurrentInfo currentbox = new CurrentInfo();
            int zmienna = 0;
            try
            {
                string idbox=datagridBoxes.CurrentItem.ToString();
                
                currentbox.BoxId = zmienna;//int.Parse(uid.ToString())
                MessageBox.Show(currentbox.UserId.ToString());                
                View.Boxes boxes = new View.Boxes(currentbox.BoxId);
                boxes.Show();
                
            }
            catch
            {
                MessageBox.Show("Nie wybrano żadnego pudełka. Wybierz lub dodaj nowe.");
            }
        }

        private void btnAddPhotoBoxes_Click(object sender, RoutedEventArgs e)
        {

            //OFileDialog();
            //FileStream Stream = new FileStream(tbFilePathBoxes.Text, FileMode.Open, FileAccess.Read);
            //StreamReader Reader = new StreamReader(Stream);
            //Byte[] ImgData = new Byte[Stream.Length - 1];
            //Stream.Read(ImgData, 0, (int)Stream.Length - 1);
            //using (BD.BoxesEntities database = new BD.BoxesEntities())
            //{
            //    BD.Box o = database.Boxes.Create();
            //    o.Name = GetFileNameNoExt(tbFilePathBoxes.Text);
            //    o.Picture = ImgData;
            //    //o.Picture= File.ReadAllBytes(op.FileName);
            //    database.Boxes.Add(o);
            //    database.SaveChanges();
            //}








           
            //AddPhoto addphot = new AddPhoto();
            //addphot.Show();
            //int nrid = int.Parse(datagridBoxes.CurrentItem.ToString());
            //using (var database = new BD.BoxesEntities())
            //{
            //    BD.Box boxone = new BD.Box();
            //    boxone.Picture = ConvertToByte(this.imageBoxes, sPath);
            //    boxone.BoxID = nrid;
            //    database.Boxes.Add(boxone);
            //    database.SaveChanges();
                
            //}
        }

        private void btnAddBoxes_Click(object sender, RoutedEventArgs e)
        {
            AddBox addbox = new AddBox();
            addbox.Show();
        }

        private void btnDeleteBoxes_Click(object sender, RoutedEventArgs e)
        {            
            //usuwanie komunikat z zapytaniem
            //MessageBox.Show("Na pewno chcesz usunąć pudełko z całą zawartością?", "Usuwanie",
            //   MessageBoxButton.YesNo, MessageBoxImage.Warning);
            //if (MessageBox.Show("Na pewno chcesz usunąć pudełko z całą zawartością?", "Usuwanie", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
            //{
            //    //Close();
            //    //do no stuff
            //}
            //else
            //{
            //    //usuwanie pudełka z bazy 

            //    //do yes stuff
            //}
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
        private byte[] ConvertToByte(string sPath)
        {
            byte[] data = null;
            FileInfo fInfo = new FileInfo(sPath);
            long numBytes = fInfo.Length;
            FileStream fStream = new FileStream(sPath, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fStream);
            data = br.ReadBytes((int)numBytes);
            return data;
        }
        public string GetFileNameNoExt(string FilePathFileName)
        {
            return System.IO.Path.GetFileNameWithoutExtension(FilePathFileName);
        }
    }
}
