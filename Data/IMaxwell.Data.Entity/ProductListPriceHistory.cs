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
    
    public partial class ProductListPriceHistory
    {
        public Nullable<System.DateTime> EndDate { get; set; }
        public Nullable<decimal> ListPrice { get; set; }
        public System.DateTime ModifiedDate { get; set; }
        public int ProductID { get; set; }
        public System.DateTime StartDate { get; set; }
    
        public virtual Product Product { get; set; }
    }
}
