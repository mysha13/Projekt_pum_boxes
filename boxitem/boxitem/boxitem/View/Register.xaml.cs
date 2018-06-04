using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
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
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        CurrentInfo currentuser = new CurrentInfo();
        BD.BoxesEntities database = new BD.BoxesEntities();

        public Register()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnRegisterRegister_Click(object sender, RoutedEventArgs e)
        {
            //using (var bb = new BD.BoxesEntities())
            //{
                var getallfitusers = from a in database.Users
                            where a.Login == LoginRegister.Text
                            select a;
                
                if ( getallfitusers.Count() > 0)
                {
                    MessageBox.Show("Podany login jest zajęty");
                    //    LoginRegister.Clear();
                }
                else
                {
                AddNewUser();
                }       

            //}
        }
        private void AddNewUser()
        {
            BD.User newuser = new BD.User
            {
                Name = NameRegister.Text.Trim(),
                Surname = SurnameRegister.Text.Trim(),
                Login = LoginRegister.Text.Trim(),
                Password = PasswordRegister.Text.Trim()
            };

            database.Users.Add(newuser);
            database.SaveChanges();

            MessageBox.Show("Użytkownik '" + LoginRegister.Text + "' został dodany");
            this.Close();
        }


    }
}
