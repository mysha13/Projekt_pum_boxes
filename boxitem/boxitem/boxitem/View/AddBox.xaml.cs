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
            using (var database = new BD.BoxesEntities())
            {
                int iduser = currentuser.UserID;
                try
                {
                    BD.Box newbox = new BD.Box
                    {
                        Name = tbNameAddBox.Text.Trim(),
                        Number = int.Parse(tbNumberAddBox.Text),
                        Description = tbDescriptionAddBox.Text.Trim(),
                        UserId = iduser,
                        Users = database.Users.Single(x => x.UserId == iduser)

                    };
                    database.Boxes.Add(newbox);
                    database.SaveChanges();
                    this.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Blędne dane! Kod pudełka musi być liczbą!");
                }  
               
            }
        }
    }
}
