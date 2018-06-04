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
        BD.BoxesEntities database = new BD.BoxesEntities();

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
            try
            {
                GetAndSaveUserInfo();
            }
            catch
            {
                MessageBox.Show("Błędne dane logowania \n Użytkownik nie istnieje");
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
            View.Boxes boxes = new View.Boxes();                             
            boxes.ShowDialog();
            this.Close();
        }

        private void CheckUsersInfo(int checkid)
        {
            if (checkid == -1)
            {
                MessageBox.Show("Błędne dane logowania \n Użytkownik nie istnieje");
            }
            else
            {
                currentuser.UserID = checkid;
                OpenNextWindow();
            }            
        }

        private void GetAndSaveUserInfo()
        {
            IQueryable<BD.User> fituser =
                        from u in database.Users
                        where u.Login == tbLoginLogin.Text
                        select u;

            int checkid = -1;
            foreach (var user1 in fituser)
            {
                if (tbPasswordLogin.Text == user1.Password.Trim())
                {
                    checkid = user1.UserId;
                    //currentuser.USERLoginCurrent = user1.Login;
                    //currentuser.USERNameCurrent = user1.Name;
                    //currentuser.USERSurnameCurrent = user1.Surname;
                }
            }
            CheckUsersInfo(checkid);
        }
       
    }
}
