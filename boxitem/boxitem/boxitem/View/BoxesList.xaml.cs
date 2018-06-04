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
        BD.BoxesEntities database = new BD.BoxesEntities();

        public BoxesList()
        {
            InitializeComponent();
            DisplayBoxes(currentitem.UserID);
        }

        private void DisplayBoxes(int id)
        {
            var boxes = database.Boxes
                .ToList()
                .Where(x => x.UserId == id)
                .Select(x => ViewModel.BoxViewModel.Create(x.Name, x.Number, x.Description, x.BoxID))
                .ToList();

            datagridBoxesList.ItemsSource = boxes;
            database.SaveChanges();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AddItemToAnotherBox()
        {
            int currentitemId = GetSelectedItemId();
            AddAndSaveItemToAnotherBox(currentitemId);
        }

        private int GetSelectedItemId()
        {
            object item = datagridBoxesList.SelectedItem;
            string ID = (datagridBoxesList.SelectedCells[4].Column.GetCellContent(item) as TextBlock).Text;
            int currentID = int.Parse(ID);
            return currentID;
        }

        private void btnChooseBoxesList_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AddItemToAnotherBox();

                DBAction.DeleteData deletetransfer = new DBAction.DeleteData();
                deletetransfer.DeleteWhileTransferItem(currentitem.ItemID);
                //DeleteWhileTransferItem(currentitem.ItemID)

                //var old = (from o in database.Items
                //           where o.ItemId == currentitem.ItemID
                //           select o).FirstOrDefault();

                //database.Items.Remove(old);
                //database.SaveChanges();
                MessageBox.Show("Przedmiot został przeniesiony");
                this.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Nie wybrano pudełka!");
            }
        }

        private void AddAndSaveItemToAnotherBox(int currentitemId)
        {
            var updatebox = (from stu in database.Items
                             where stu.ItemId == currentitem.ItemID
                             select stu).SingleOrDefault();
            BD.Item newitem = new BD.Item
            {
                Name = updatebox.Name.ToString(),
                Number = updatebox.Number,
                Description = updatebox.Description.ToString(),
                Picture = updatebox.Picture,
                BoxId = currentitemId,
                Boxes = database.Boxes.Single(x => x.BoxID == currentitemId)
            };
            database.Items.Add(newitem);
            database.SaveChanges();
        }
    }
}
