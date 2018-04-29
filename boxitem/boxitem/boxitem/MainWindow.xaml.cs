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
            //var bb = new BoxesEntities();
            InitializeComponent();
            //Register r = new Register();
            //r.Show();
           //View. Boxes b = new View.Boxes(1);                          //-----BŁĄD
            //b.Show();
            //Items i = new Items();
            //i.Show();
            //RemindPassword rp = new RemindPassword();
            //rp.Show();
            //FindItem fi = new FindItem();
            //fi.Show();
            //BoxesList bl = new BoxesList();
            //bl.Show();
            //AddPhoto ap = new AddPhoto();
            //ap.Show();
            //AddItem ai = new AddItem();
            //ai.Show();
            //AddBox ab = new AddBox();
            //ab.Show();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
       
        private void btnLoginLogin_Click(object sender, RoutedEventArgs e)
        {
            using (var data = new BD.BoxesEntities())
            {
                IQueryable<BD.User> fituser =
                        from u in data.Users
                        where u.Login == tbLoginLogin.Text
                        select u;
            }
            // brak dostępu do pól fituser
            
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
                        }
                    }
                    if (checkid == -1)
                    {
                        MessageBox.Show("Błędne dane logowania \n Użytkownik nie istnieje");
                    }
                    else
                    {
                        currentuser.UserId = checkid; //int.Parse(uid.ToString())
                        //MessageBox.Show(currentuser.UserId.ToString());
                        OpenNextWindow();
                        //this.Hide();
                        //View.Boxes boxes = new View.Boxes(currentuser.UserId);                      //-----BŁĄD
                        //boxes.ShowDialog();
                        //this.Close();
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
            RemindPassword remindpassword = new RemindPassword();
            remindpassword.Show(); 
        }

        private void btnRegisterLogin_Click(object sender, RoutedEventArgs e)
        {
            Register register = new Register();
            register.Show();
        }
        private void OpenNextWindow ()
        {
            //currentuser.UserId = checkid; //int.Parse(uid.ToString())
                                          //MessageBox.Show(currentuser.UserId.ToString());
                                          //this.Hide();
            View.Boxes boxes = new View.Boxes(currentuser.UserId);                      //-----BŁĄD
            boxes.ShowDialog();
            //this.Close();
        }
    }
}
