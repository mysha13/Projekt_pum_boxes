using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace boxitem.ViewModel
{
    class BoxViewModel
    {
        public string Name { get; set; }

        public int? Number { get; set; }

        public string Description { get; set; }
        public int UserId { get; set; }

        public BoxViewModel(string name, int? number, string description)
        {
            this.Name = name;
            this.Number = number;
            this.Description = description;
        }

        public static BoxViewModel Create(string name, int? number, string description)
        {
            return new BoxViewModel(name, number, description);
        }
        public BoxViewModel(string name, int? number, string description, int userid)
        {
            this.Name = name;
            this.Number = number;
            this.Description = description;
            this.UserId = userid;
        }
        public static BoxViewModel Create(string name, int? number, string description, int userid)
        {
            return new BoxViewModel(name, number, description, userid);
        }

    }
}
