//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace boxitem.BD
{
    using System;
    using System.Collections.Generic;
    
    public partial class Item
    {
        public string Name { get; set; }
        public Nullable<int> Number { get; set; }
        public string Description { get; set; }
        public int ItemId { get; set; }
        public int BoxId { get; set; }
        public byte[] Picture { get; set; }
    
        public virtual Box Boxes { get; set; }
    }
}
