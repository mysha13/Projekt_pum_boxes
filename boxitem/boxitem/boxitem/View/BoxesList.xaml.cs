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
    /// Interaction logic for BoxesList.xaml
    /// </summary>
    public partial class BoxesList : Window
    {
        CurrentInfo currentitem = new CurrentInfo();

        public BoxesList()
        {
            InitializeComponent();

            DisplayBoxes(currentitem.UserID);

        }

        private void DisplayBoxes(int id)
        {
            using (var bb = new BD.BoxesEntities())
            {
                var boxes = bb.Boxes
                    .ToList()
                    .Where(x => x.UserId == id)
                    .Select(x => ViewModel.BoxViewModel.Create(x.Name, x.Number, x.Description, x.BoxID))
                    .ToList();

                datagridBoxesList.ItemsSource = boxes;
                
                bb.SaveChanges();

            }
        }

        private void btnOkBoxesList_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                object item = datagridBoxesList.SelectedItem;
                string ID = (datagridBoxesList.SelectedCells[4].Column.GetCellContent(item) as TextBlock).Text;
                int IID = int.Parse(ID);

                BD.BoxesEntities dbdb = new BD.BoxesEntities();
                var updatebox = (from stu in dbdb.Items
                                 where stu.ItemId == currentitem.ItemID
                                 select stu).SingleOrDefault();

                BD.Item newitem = new BD.Item
                {
                    Name = updatebox.Name.ToString(),
                    Number = updatebox.Number,
                    Description = updatebox.Description.ToString(),
                    Picture = updatebox.Picture,
                    BoxId = IID,
                    Boxes = dbdb.Boxes.Single(x => x.BoxID == IID)
                };
                dbdb.Items.Add(newitem);
                dbdb.SaveChanges();

                var old = (from o in dbdb.Items
                           where o.ItemId == currentitem.ItemID
                           select o).FirstOrDefault();

                dbdb.Items.Remove(old);
                dbdb.SaveChanges();
                MessageBox.Show("Przedmiot został przeniesiony");
                this.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Nie wybrano pudełka!");
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
