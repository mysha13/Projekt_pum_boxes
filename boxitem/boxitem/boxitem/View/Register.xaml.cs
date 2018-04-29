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
            //    BD.User user1 = new BD.User();
            //    user1.Login = "asdasd";
            //    user1.Name = "sd";
            //    user1.Password = "sd";
            //    user1.Surname = "sd";
            //    user1.UserId = 3;

            //    bb.Users.Add(user1);
            //    bb.SaveChanges();
            //}


            using (var bb = new BD.BoxesEntities())
            {
                IQueryable<BD.User> us =
                        from u in bb.Users
                        where u.Login == LoginRegister.Text
                        select u;

                var check = from a in bb.Users
                            where a.Login == LoginRegister.Text
                            select a;
                
                if ( check.Count() > 0)
                {
                    MessageBox.Show("Podany login jest zajęty");
                    //    LoginRegister.Clear();
                }
                else
                {
                    // var boxes = bb.Boxes
                    //.ToList()
                    //.Where(x => x.UserId == id)
                    //.Select(x => ViewModel.BoxViewModel.Create(x.Name, x.Number, x.Description))
                    ////.Where()
                    //.ToList();

                    // datagridBoxes.ItemsSource = boxes;

                    // //boxes.Add(ViewModel.BoxViewModel.Create("asd", 234, "asd"));
                    BD.User user = new BD.User
                    {
                        Name = NameRegister.Text.Trim(),
                        Surname = SurnameRegister.Text.Trim(),
                        Login = LoginRegister.Text.Trim(),
                        Password = PasswordRegister.Text.Trim()
                    };
                    bb.Users.Add(user);

                    //var users = bb.Users
                    //    .ToList()
                    //    .Select(x => ViewModel.UserViewModel.Create(x.Login, x.Password, x.Name, x.Surname))
                    //    .ToList();

                    //users.Add(ViewModel.UserViewModel.Create(LoginRegister.Text, PasswordRegister.Text, NameRegister.Text, SurnameRegister.Text));


                    bb.SaveChanges();
                }

               

                //if (us == )
                //{
                //    MessageBox.Show("Podany login jest zajęty");
                //    LoginRegister.Clear();
                //}
                //else
                //{
                //    bb.Users.Add(new Users
                //    {
                //        Name = NameRegister.ToString().Trim(),
                //        Surname = SurnameRegister.ToString().Trim(),
                //        Login = LoginRegister.ToString().Trim(),
                //        Password = PasswordRegister.ToString().Trim()
                //    });

                //    bb.SaveChanges();
                //    this.Close();
                //}
                //try
                //{


                //    foreach (var i in us)
                //    {
                //        //string haslo = i.Password.Trim();
                //        //string haslo1 = tbPasswordLogin.Text;//pbPasswordLogin.SecurePassword.ToString();
                //        //MessageBox.Show(haslo);
                //        //MessageBox.Show(haslo1);
                //        if (LoginRegister.Text != i.Login.Trim())
                //        {
                //            //zmienna = i.UserId;
                //            bb.Users.Add(new Users
                //            {
                //                Name = NameRegister.ToString().Trim(),
                //                Surname = SurnameRegister.ToString().Trim(),
                //                Login = LoginRegister.ToString().Trim(),
                //                Password = PasswordRegister.ToString().Trim()
                //            });

                //            bb.SaveChanges();
                //            this.Close();
                //        }
                //        else
                //        {
                //            MessageBox.Show("Podany login jest zajęty");
                //            LoginRegister.Clear();
                //        }
                //    }
                //}
                //catch (DbEntityValidationException exp)
                //{
                //    foreach (var eve in exp.EntityValidationErrors)
                //    {
                //        Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                //            eve.Entry.Entity.GetType().Name, eve.Entry.State);
                //        foreach (var ve in eve.ValidationErrors)
                //        {
                //            Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                //                ve.PropertyName, ve.ErrorMessage);
                //        }
                //    }

                //}

            }
        }
    }
}
