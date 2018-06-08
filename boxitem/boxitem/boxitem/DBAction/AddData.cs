using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace boxitem.DBAction
{
    class AddData
    {
        CurrentInfo currentinfo = new CurrentInfo();
        BD.BoxesEntities database = new BD.BoxesEntities();

        public void AddUser(string name, string surname, string login, string password)
        {
            //List<ViewModel.UserViewModel> getallfitusers = new List<ViewModel.UserViewModel>();
            //DBAction.GetData getusers = new GetData();
            //getallfitusers = getusers.GetFitUsers(login);
            var getallfitusers = from a in database.Users
                                 where a.Login == login
                                 select a;

            if (getallfitusers.Count() > 0)
            {
                MessageBox.Show("Podany login jest zajęty");
                //    LoginRegister.Clear();               
            }
            else
            {
                BD.User newuser = new BD.User
                {
                    Name = name,
                    Surname = surname,
                    Login = login,
                    Password = password
                };

                database.Users.Add(newuser);
                database.SaveChanges();

                MessageBox.Show("Użytkownik '" + login + "' został dodany");
               
            }
                
                        
        }
        public void AddBox(int iduser, int number, string name, string description)
        {
            //AddBox add = new boxitem.AddBox();

            BD.Box newbox = new BD.Box
            {                
                Name = name,//add.tbNameAddBox.Text.Trim(),
                Number = number,//int.Parse(add.tbNumberAddBox.Text),
                Description = description,//add.tbDescriptionAddBox.Text.Trim(),
                UserId = iduser,
                Users = database.Users.Single(x => x.UserId == iduser)

            };
            database.Boxes.Add(newbox);
            database.SaveChanges();
            MessageBox.Show("Dodano pudełko pomyślnie!");
        }

        public void AddItem (int idbox,int number, string name, string description)
        {
            BD.Item newitem = new BD.Item
            {
                Name = name,
                Number = number,
                Description = description,
                BoxId = idbox,
                Boxes = database.Boxes.Single(x => x.BoxID == idbox)
            };
            database.Items.Add(newitem);
            database.SaveChanges();
            MessageBox.Show("Dodano przedmiot pomyślnie!");
        }

        public void AddItemWhileTransfer(int currentitemId)
        {
            var updatebox = (from stu in database.Items
                             where stu.ItemId == currentinfo.ItemID
                             select stu).SingleOrDefault();


            BD.Item newitem = new BD.Item
            {
                Name = updatebox.Name.ToString(),
                Number = updatebox.Number,
                Description = updatebox.Description.ToString(),
                Picture = updatebox.Picture,
                BoxId = currentitemId,
                Boxes = database.Boxes.Single(x => x.BoxID == currentitemId)
            };
            database.Items.Add(newitem);
            database.SaveChanges();


        }
        
        public void SaveItemPhoto(Byte[] ImgData)
        {
            var item = (from stu in database.Items
                        where stu.ItemId == currentinfo.ItemID
                        select stu).SingleOrDefault();

            item.Picture = ImgData;
            database.SaveChanges();
        }

        public void SaveBoxPhoto(Byte[] ImgData)
        {
            var box = (from b in database.Boxes
                       where b.BoxID == currentinfo.BoxID
                       select b).SingleOrDefault();

            box.Picture = ImgData;
            database.SaveChanges();

            
                                
        }

    }
}
