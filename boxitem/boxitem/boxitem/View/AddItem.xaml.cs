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
            using (var database = new BD.BoxesEntities())
            {
                int idbox = currentbox.BoxID;

                var items = database.Boxes
                    .ToList()
                    .Where(x => x.BoxID == idbox)
                    .Select(x => ViewModel.ItemViewModel.Create(x.Name, x.Number, x.Description))
                    .ToList();
                try
                {
                    BD.Item newitem = new BD.Item
                    {
                        Name = tbNameAddItem.Text.Trim(),
                        Number = int.Parse(tbNumberAddItem.Text),
                        Description = tbDescriptionAddItem.Text.Trim(),
                        BoxId = currentbox.BoxID,
                        Boxes = database.Boxes.Single(x => x.BoxID == idbox)                 
                    };

                    database.Items.Add(newitem);
                    database.SaveChanges();
                    this.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Błędne dane. Pole 'Liczba rzeczy' musi być liczbą!");
                }
                
            }
        }
    }
}
