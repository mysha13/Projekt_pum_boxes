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
    /// Interaction logic for AddBox.xaml
    /// </summary>
    public partial class AddBox : Window
    {
        CurrentInfo currentuser = new CurrentInfo();
        //BD.BoxesEntities database = new BD.BoxesEntities();
        
        public AddBox()
        {
            InitializeComponent();  
        }

        private void btnCancelAddIBox_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnOkAddBox_Click(object sender, RoutedEventArgs e)
        {
            int iduser = currentuser.UserID;
            try
            {
                DBAction.AddData addbox = new DBAction.AddData();
                addbox.AddBox(iduser, int.Parse(tbNumberAddBox.Text), tbNameAddBox.Text.Trim(), tbDescriptionAddBox.Text.Trim());
                this.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Blędne dane! Kod pudełka musi być liczbą!");
                tbNumberAddBox.Clear();
            }
        }        
    }
}
