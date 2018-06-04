using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace boxitem.DBAction
{
    class DeleteData
    {
        CurrentInfo currentuser = new CurrentInfo();       
        BD.BoxesEntities database = new BD.BoxesEntities();
        
        public void DeleteBox(int currentboxID)
        {
            BD.Box deletebox = new BD.Box();
            deletebox = (from stu in database.Boxes
                         where stu.BoxID == currentboxID
                         select stu).SingleOrDefault();

            database.Boxes.Remove(deletebox);
            database.SaveChanges();
        }

        public void DeleteItem(int currentitemID)
        {
            var deleteitem = (from stu in database.Items
                              where stu.ItemId == currentitemID
                              select stu).SingleOrDefault();

            database.Items.Remove(deleteitem);
            database.SaveChanges();
        }

        public void DeleteItemPhoto(int currentitemID)
        {
            var currentitemimage = (from stu in database.Items
                                where stu.ItemId == currentitemID
                                select stu).SingleOrDefault();

            if (currentitemimage.Picture != null)
            {
                currentitemimage.Picture = null;
                Items item = new Items();
                item.imageItems.Source = null;
                database.SaveChanges();
            }
        }

        public void DeleteBoxPhoto(int currentboxID)
        {
            var currentboximage = (from box in database.Boxes
                                   where box.BoxID == currentboxID
                                   select box).SingleOrDefault();

            if (currentboximage.Picture != null)
            {
                currentboximage.Picture = null;
                View.Boxes box = new View.Boxes();                
                box.imageBoxes.Source = null;
                database.SaveChanges();
            }
        }

        public void DeleteWhileTransferItem(int currentitem)
        {
            var old = (from o in database.Items
                       where o.ItemId == currentitem
                       select o).FirstOrDefault();

            database.Items.Remove(old);
            database.SaveChanges();
        }
    }
}
