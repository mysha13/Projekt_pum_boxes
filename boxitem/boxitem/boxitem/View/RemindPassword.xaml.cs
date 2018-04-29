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
            using (var data = new BD.BoxesEntities())
            {
                try
                {
                    IQueryable<BD.User> fituser =
                        from u in data.Users
                        where u.Login == tbLoginRemindPassword.Text && u.Name==tbNameRemindPassword.Text && u.Surname==tbSurnameRemindPassword.Text
                        select u;

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
                        tbLoginRemindPassword.Clear();
                        tbNameRemindPassword.Clear();
                        tbSurnameRemindPassword.Clear();
                        tbPasswordRemindPassword.Clear();
                    }
                    
                }
                catch
                {
                    MessageBox.Show("Użytkownik nie istnieje. \nWprowadź poprawne dane, podane podczas rejestracji.");
                    tbLoginRemindPassword.Clear();
                    tbNameRemindPassword.Clear();
                    tbSurnameRemindPassword.Clear();
                    tbPasswordRemindPassword.Clear();
                }
               

                    
            }

        }

        private void textChangedEventHandler(object sender, TextChangedEventArgs e)
        {
            tbPasswordRemindPassword.Clear();
        }
        
    }
}
