using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace boxitem.DBAction
{
    class AddData
    {
        CurrentInfo currentinfo = new CurrentInfo();
        BD.BoxesEntities database = new BD.BoxesEntities();

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
