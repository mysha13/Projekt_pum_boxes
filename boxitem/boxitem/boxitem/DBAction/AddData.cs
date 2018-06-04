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
            var nowe = (from stu in database.Items
                        where stu.ItemId == currentinfo.ItemID
                        select stu).SingleOrDefault();

            nowe.Picture = ImgData;
            database.SaveChanges();
        }

    }
}
