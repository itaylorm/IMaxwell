//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IMaxwell.Data.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class SpecialOffer
    {
        public SpecialOffer()
        {
            this.SpecialOfferProducts = new HashSet<SpecialOfferProduct>();
        }
    
        public string Category { get; set; }
        public string Description { get; set; }
        public Nullable<decimal> DiscountPct { get; set; }
        public System.DateTime EndDate { get; set; }
        public Nullable<int> MaxQty { get; set; }
        public int MinQty { get; set; }
        public System.DateTime ModifiedDate { get; set; }
        public System.Guid rowguid { get; set; }
        public int SpecialOfferID { get; set; }
        public System.DateTime StartDate { get; set; }
        public string Type { get; set; }
    
        public virtual ICollection<SpecialOfferProduct> SpecialOfferProducts { get; set; }
    }
}
