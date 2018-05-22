using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace boxitem.ViewModel
{
    class ItemViewModel
    {
        public string Name { get; set; }        
        public Nullable<int> Number { get; set; }
        public string Description { get; set; }
        public int ItemId { get; set; }
        public int BoxId { get; set; }
        //public byte[] Picture { get; set; }

        public ItemViewModel(string name, int? number, string description)
        {
            this.Name = name;
            this.Number = number;
            this.Description = description;
        }

        public static ItemViewModel Create(string name, int? number, string description)
        {
            return new ItemViewModel(name, number, description);
        }
        public ItemViewModel(string name, int? number, string description, int itemid)
        {
            this.Name = name;
            this.Number = number;
            this.Description = description;
            this.ItemId = itemid;
        }
        public static ItemViewModel Create(string name, int? number, string description, int itemid)
        {
            return new ItemViewModel(name, number, description, itemid);
        }
    }
}
