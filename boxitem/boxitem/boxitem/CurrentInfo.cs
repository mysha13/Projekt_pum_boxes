using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace boxitem
{
    class CurrentInfo
    {
        public static int UserId { set; get; }
        public static int BoxId { set; get; }
        public static int ItemId { set; get; }

        public static string UserNameCurrent { set; get; }
        public static string UserLoginCurrent { set; get; }
        public static string UserSurnameCurrent { set; get; }

        public int UserID
        {
            get
            {
                return UserId;
            }
            set
            {
                UserId = value;
            }
        }
        public int BoxID
        {
            get
            {
                return BoxId;
            }
            set
            {
                BoxId = value;
            }
        }
        public int ItemID
        {
            get
            {
                return ItemId;
            }
            set
            {
                ItemId = value;
            }
        }
        public string USERNameCurrent
        {
            get
            {
                return UserNameCurrent;
            }
            set
            {
                UserNameCurrent = value;
            }
        }
        public string USERLoginCurrent
        {
            get
            {
                return UserLoginCurrent;
            }
            set
            {
                UserLoginCurrent = value;
            }
        }
        public string USERSurnameCurrent
        {
            get
            {
                return UserSurnameCurrent;
            }
            set
            {
                UserSurnameCurrent = value;
            }
        }
    }
}
