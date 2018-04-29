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

namespace boxitem
{
    /// <summary>
    /// Interaction logic for AddPhoto.xaml
    /// </summary>
    public partial class AddPhoto : Window
    {
        public AddPhoto()
        {
            InitializeComponent();
        }

        private void btnCancelAddPhoto_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnOkAddPhoto_Click(object sender, RoutedEventArgs e)
        {
            
            CurrentInfo currentid = new CurrentInfo();
            int itemid=currentid.ItemId;
            int boxid = currentid.BoxId;

            if(boxid !=0 && itemid !=0)
            {

                //OFileDialog();
                // trzeba  dodac zapis do bazy - dodac zdj przedmiotu
            }
            if(boxid !=0 && itemid ==0)
            {
                //OFileDialog();
                // trzeba  dodac zapis do bazy - dodac zdj pudełka
            }


        }
        private void OFileDialog()
        {
            // wczytywanie zdjęcia
            //OpenFileDialog op = new OpenFileDialog();
            //op.Title = "Select a picture";
            //op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
            //  "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
            //  "Portable Network Graphic (*.png)|*.png";
            //if (op.ShowDialog() == true)
            //{
            //    imageAddPhoto.Source = new BitmapImage(new Uri(op.FileName));
            //}
        }
    }
}
