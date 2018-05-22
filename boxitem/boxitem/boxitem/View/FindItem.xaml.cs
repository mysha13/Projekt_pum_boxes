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
    /// Interaction logic for FindItem.xaml
    /// </summary>
    public partial class FindItem : Window
    {
        CurrentInfo currentuser = new CurrentInfo();
        public FindItem()
        {
            InitializeComponent();
        }

        private void btnCancelFindItem_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

       
        private void btnSerachFindItem_Click(object sender, RoutedEventArgs e)
        {           
            string search_name = tbNameFindItem.Text.Trim();

            BD.BoxesEntities dbdb = new BD.BoxesEntities();
            var allbox = (from stu in dbdb.Items
                          join m in dbdb.Boxes 
                          on stu.BoxId equals m.BoxID
                          where stu.Name == search_name
                          select stu).ToList();

            if (allbox.Count()>0)
            {
                datagridBoxesListFindItem.ItemsSource = allbox;
            }
            else
            {
                MessageBox.Show("Taki przedmiot nie istnieje. Sprawdź pisownie.");
            }

            
        }

        private void btnGotoFindItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                object item = datagridBoxesListFindItem.SelectedItem;
                string IDitem = (datagridBoxesListFindItem.SelectedCells[4].Column.GetCellContent(item) as TextBlock).Text;
                int ID = int.Parse(IDitem);

                currentuser.BoxID = ID;
                //MessageBox.Show(currentbox.UserID.ToString());  
                Items items = new Items(currentuser.BoxID);
                items.Show();
                this.Close();
            }
            catch
            {
                MessageBox.Show("Nie wybrano żadnego pudełka.");
            }
        }
    }
}
