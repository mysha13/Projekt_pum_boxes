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
    /// Interaction logic for Items.xaml
    /// </summary>
    public partial class Items : Window
    {
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
                    .Where(x => x.BoxId == boxid)
                    .Select(x => ViewModel.ItemViewModel.Create(x.Name, x.Number, x.Description))                    
                    .ToList();

                datagridItems.ItemsSource = allitems;

                database.SaveChanges();

            }
        }
        private void btnMoveItems_Click(object sender, RoutedEventArgs e)
        {
            BoxesList boxlist = new BoxesList();
            boxlist.Show();
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
            //usuwanie komunikat z zapytaniem
            MessageBox.Show("Na pewno chcesz usunąć przedmiot?", "Usuwanie",
               MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (MessageBox.Show("Na pewno chcesz usunąć przedmiot?", "Usuwanie", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
            {
                Close();
                //do no stuff
            }
            else
            {
                //usuwanie przedmiotu z bazy 

                //do yes stuff
            }
        }
    }
}
