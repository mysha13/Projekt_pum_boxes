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

       public void GetItemPhoto(int currentitemID)
        {
            Items item = new Items();

            var showboximage = (from stu in database.Items
                                where stu.ItemId == currentitemID
                                select stu).SingleOrDefault();

            if (showboximage.Picture != null)
            {
                var imagefromdb = DBAction.ImageData.BitmapImageFromBytes(showboximage.Picture);
                item.imageItems.Source = imagefromdb;
            }
            else
            {
                item.imageItems.Source = null;
            }
        }

        public  void GetAndShowBoxPhoto(int currentboxID)
        {
            View.Boxes box = new View.Boxes();

            var showboximage = (from stu in database.Boxes
                                where stu.BoxID == currentboxID
                                select stu).SingleOrDefault();

            if (showboximage.Picture != null)
            {
                var imagefromdb = DBAction.ImageData.BitmapImageFromBytes(showboximage.Picture);
                
                box.imageBoxes.Source = imagefromdb;
            }
            else
            {
                box.imageBoxes.Source = null;
            }
        }


    }
}
