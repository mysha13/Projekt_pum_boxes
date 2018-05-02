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
                int idbox = currentbox.BoxId;

                var items = database.Boxes
                    .ToList()
                    .Where(x => x.UserId == idbox)
                    .Select(x => ViewModel.ItemViewModel.Create(x.Name, x.Number, x.Description))//, x.UserId))
                                                                                                 //.Where()
                    .ToList();

                BD.Item newitem = new BD.Item
                {
                    Name = tbNameAddItem.Text.Trim(),
                    Number = int.Parse(tbNumberAddItem.Text),
                    Description = tbDescriptionAddItem.Text.Trim(),
                    //UserId = iduser,                    
                };

                database.Items.Add(newitem);
                //items.Add(ViewModel.ItemViewModel.Create(tbNameAddItem.ToString(), int.Parse(tbNumberAddItem.ToString()), tbDescriptionAddItem.Text.Trim(),int.Parse(idbox.ToString())));
                database.SaveChanges();
            }
        }
    }
}
