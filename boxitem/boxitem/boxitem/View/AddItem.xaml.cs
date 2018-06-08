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
    /// Interaction logic for AddItem.xaml
    /// </summary>
    public partial class AddItem : Window
    {
        CurrentInfo currentbox = new CurrentInfo();
       // BD.BoxesEntities database = new BD.BoxesEntities();

        public AddItem()
        {
            InitializeComponent();
        }

        private void btnCancelAddItem_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnOkAddItem_Click(object sender, RoutedEventArgs e)
        {
            int idbox = currentbox.BoxID;
            //int idbox = currentbox.BoxID;
            //var items = database.Boxes
            //       .ToList()
            //       .Where(x => x.BoxID == idbox)
            //       .Select(x => ViewModel.ItemViewModel.Create(x.Name, x.Number, x.Description))
            //       .ToList();
            try
            {
                DBAction.AddData additem = new DBAction.AddData();
                additem.AddItem(idbox, int.Parse(tbNumberAddItem.Text), tbNameAddItem.Text.Trim(), tbDescriptionAddItem.Text.Trim());
                this.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Błędne dane. Pole 'Liczba rzeczy' musi być liczbą!");
                tbNumberAddItem.Clear();
            }               
        }        
    }
}
