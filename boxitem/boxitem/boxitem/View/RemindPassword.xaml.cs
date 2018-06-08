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
    /// Interaction logic for RemindPassword.xaml
    /// </summary>
    public partial class RemindPassword : Window
    {
        BD.BoxesEntities database = new BD.BoxesEntities();

        public RemindPassword()
        {            
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnVerifyAndRemindRemindPassword_Click(object sender, RoutedEventArgs e)
        {
            DBAction.GetData getuserdata = new DBAction.GetData();
            IQueryable<BD.User> fituser = getuserdata.RemindPassword(tbLoginRemindPassword.Text, tbNameRemindPassword.Text, tbSurnameRemindPassword.Text);
            
            if (fituser.Count() > 0)
            {
                foreach (var i in fituser)
                {
                    tbPasswordRemindPassword.Text = i.Password.ToString();
                }
            }
            else
            {
                MessageBox.Show("Użytkownik nie istnieje. \nWprowadź poprawne dane, podane podczas rejestracji.");
                ClearAllTextBox();
            }
        }

        private void textChangedEventHandler(object sender, TextChangedEventArgs e)
        {
            tbPasswordRemindPassword.Clear();
        }

        private void ClearAllTextBox()
        {
            tbLoginRemindPassword.Clear();
            tbNameRemindPassword.Clear();
            tbSurnameRemindPassword.Clear();
            tbPasswordRemindPassword.Clear();
        }
        
    }
}
