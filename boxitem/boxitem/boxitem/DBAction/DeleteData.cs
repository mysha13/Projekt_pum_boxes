using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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
            BD.Item deleteitem = new BD.Item();
            deleteitem = (from stu in database.Items
                              where stu.ItemId == currentitemID
                              select stu).SingleOrDefault();

            database.Items.Remove(deleteitem);
            database.SaveChanges();
        }

        public Byte[] DeleteItemPhoto(int currentitemID)
        {
            var currentitemimage = (from stu in database.Items
                                where stu.ItemId == currentitemID
                                select stu).SingleOrDefault();

            if (currentitemimage.Picture == null)
            {
                MessageBox.Show("Przedmiot nie posiada zdjęcia!");
            }
            else
            {
                currentitemimage.Picture = null;
                database.SaveChanges();
            }
            return currentitemimage.Picture;
               
            

        }

        public Byte[] DeleteBoxPhoto(int currentboxID)
        {
            var currentboximage = (from box in database.Boxes
                                   where box.BoxID == currentboxID
                                   select box).SingleOrDefault();

            if (currentboximage.Picture == null)
            {
                MessageBox.Show("Pudełko nie posiada zdjęcia!");
            }
            else
            {
                currentboximage.Picture = null;
                database.SaveChanges();               
            }
            return currentboximage.Picture;

            //if (currentboximage.Picture != null)
            //{
            //    currentboximage.Picture = null;
            //    View.Boxes box = new View.Boxes();                
            //    box.imageBoxes.Source = null;
            //    database.SaveChanges();
            //}
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
