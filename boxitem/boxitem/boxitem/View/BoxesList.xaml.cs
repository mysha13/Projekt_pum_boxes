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

        private void DisplayBoxes(int iduser)
        {
            DBAction.GetData getallboxes = new DBAction.GetData();
            datagridBoxesList.ItemsSource = getallboxes.DispalyBoxes(iduser);
            
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
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
                currentitem.BoxID = GetSelectedItemId();

                DBAction.AddData addcurrentitem = new DBAction.AddData();
                addcurrentitem.AddItemWhileTransfer(currentitem.BoxID);

                DBAction.DeleteData deletetransfer = new DBAction.DeleteData();
                deletetransfer.DeleteWhileTransferItem(currentitem.ItemID);
                
                MessageBox.Show("Przedmiot został przeniesiony");
                this.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Nie wybrano pudełka!");
            }
        }
        
    }
}
