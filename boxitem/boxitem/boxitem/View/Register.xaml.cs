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
            DBAction.AddData adduser = new DBAction.AddData();
            adduser.AddUser(NameRegister.Text.Trim(), SurnameRegister.Text.Trim(), LoginRegister.Text.Trim(), PasswordRegister.Text.Trim());
            
            //var getallfitusers = from a in database.Users
            //                     where a.Login == LoginRegister.Text
            //                     select a;
            //List<ViewModel.UserViewModel> getallfitusers = new List<ViewModel.UserViewModel>();
            //DBAction.GetData getusers = new DBAction.GetData();
            //getallfitusers = getusers.GetFitUsers(LoginRegister.Text);

            //if (getallfitusers.Count() > 0)
            //{
            //    MessageBox.Show("Podany login jest zajęty");
            //    //    LoginRegister.Clear();
            //}
            //else
            //{
            //    DBAction.AddData adduser = new DBAction.AddData();
            //    adduser.AddUser(NameRegister.Text.Trim(), SurnameRegister.Text.Trim(), LoginRegister.Text.Trim(), PasswordRegister.Text.Trim());
            //    this.Close();
            //}       

            //}
        }
       
    }
}
