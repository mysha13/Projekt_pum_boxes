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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace boxitem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CurrentInfo currentuser = new CurrentInfo();

        public MainWindow()
        {            
            InitializeComponent();            
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
       
        private void btnLoginLogin_Click(object sender, RoutedEventArgs e)
        {           
            using (var data = new BD.BoxesEntities())
            {
                try
                {
                    IQueryable<BD.User> fituser =
                        from u in data.Users
                        where u.Login == tbLoginLogin.Text
                        select u;

                    int checkid = -1;
                    foreach (var i in fituser)
                    {
                        if (tbPasswordLogin.Text == i.Password.Trim())
                        {
                            checkid = i.UserId;
                            currentuser.USERLoginCurrent = i.Login;
                            currentuser.USERNameCurrent = i.Name;
                            currentuser.USERSurnameCurrent = i.Surname;
                        }
                    }
                    if (checkid == -1)
                    {
                        MessageBox.Show("Błędne dane logowania \n Użytkownik nie istnieje");
                    }
                    else
                    {
                        currentuser.UserID = checkid; //int.Parse(uid.ToString())                        
                        //MessageBox.Show(currentuser.UserId.ToString());
                        OpenNextWindow();                        
                    }
                }
                catch
                {
                    MessageBox.Show("Błędne dane logowania \n Użytkownik nie istnieje");
                }
                //currentuser.UserId = zmienna;

                //var users = bb.Users
                //    .ToList()
                //    .Select(x => x.UserId == Id)
                //    .Where(x => tbLoginLogin.Text==ViewModel.UserViewModel.Check(x.login,x.password))
                //    .ToList();
            }
        }

        private void btnRemindPasswordLogin_Click(object sender, RoutedEventArgs e)
        {
            RemindPassword remindpasswordwindow = new RemindPassword();
            remindpasswordwindow.Show(); 
        }

        private void btnRegisterLogin_Click(object sender, RoutedEventArgs e)
        {
            Register registerwindow = new Register();
            registerwindow.Show();
        }

        private void OpenNextWindow ()
        {
            this.Hide();
            View.Boxes boxes = new View.Boxes();//(currentuser.UserID);                              
            boxes.ShowDialog();
            this.Close();
        }
    }
}
