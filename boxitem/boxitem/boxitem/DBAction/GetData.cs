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
            var showboximage = (from stu in database.Items
                                where stu.ItemId == currentitemID
                                select stu).SingleOrDefault();

            if (showboximage.Picture != null)
            {
                var imagefromdb = DBAction.ImageData.BitmapImageFromBytes(showboximage.Picture);
                Items item = new Items();
                item.imageItems.Source = imagefromdb;
            }
            else
            {
                Items item = new Items();
                item.imageItems.Source = null;
            }
        }


    }
}
