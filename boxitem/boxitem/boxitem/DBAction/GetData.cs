using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace boxitem.DBAction
{
    class GetData
    {
        CurrentInfo currentinfo = new CurrentInfo();
        BD.BoxesEntities database = new BD.BoxesEntities();

        public List<ViewModel.UserViewModel> GetFitUsers(string login)
        {
            //var getallfitusers = from a in database.Users
            //                     where a.Login == LoginRegister.Text
            //                     select a;

            List<ViewModel.UserViewModel> getallfitusers = new List<ViewModel.UserViewModel>();

            //getallfitusers = database.Users
            //    .ToList()
            //    .Where(x => x.Login == login)
            //    .Select(x=>x.Login)
            //    .ToList();

            return getallfitusers;
        }

       public Byte[] GetItemPhoto(int currentitemID)
        {
            Items item = new Items();

            var showitemimage = (from stu in database.Items
                                where stu.ItemId == currentitemID
                                select stu).SingleOrDefault();

            return showitemimage.Picture;
        }

       public Byte[] GetAndShowBoxPhoto(int currentboxID)
        {
            var showboximage = (from stu in database.Boxes
                                where stu.BoxID == currentboxID
                                select stu).SingleOrDefault();

            return showboximage.Picture;
            
        }

       public List<ViewModel.BoxViewModel> DispalyBoxes(int iduser)
        {
            List<ViewModel.BoxViewModel> boxes = new List<ViewModel.BoxViewModel>();
             boxes = database.Boxes
                .ToList()
                .Where(x => x.UserId == iduser)
                .Select(x => ViewModel.BoxViewModel.Create(x.Name, x.Number, x.Description, x.BoxID))
                .ToList();

            return boxes;
        }

       public List<ViewModel.ItemViewModel> DisplayItems(int idbox)
        {
            List<ViewModel.ItemViewModel> allitems = new List<ViewModel.ItemViewModel>();
            allitems = database.Items
                .ToList()
                .Where(x => x.BoxId == currentinfo.BoxID)
                .Select(x => ViewModel.ItemViewModel.Create(x.Name, x.Number, x.Description, x.ItemId))
                .ToList();

            return allitems;
        }

        public List<BD.Item> FindItem(string search_name)
        {
            List<BD.Item> allbox = new List<BD.Item>();

            allbox = (from stu in database.Items
                      join m in database.Boxes
                      on stu.BoxId equals m.BoxID
                      where stu.Name == search_name
                      select stu).ToList();

            return allbox;
        }

        public IQueryable<BD.User> RemindPassword(string login, string name, string surname)
        {
            IQueryable<BD.User> fituser = (from u in database.Users
                                           where u.Login == login && u.Name == name && u.Surname == surname
                                           select u);

            return fituser;
        }
    }
}
