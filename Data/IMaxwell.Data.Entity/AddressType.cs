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
    
    public partial class AddressType
    {
        public AddressType()
        {
            this.CustomerAddresses = new HashSet<CustomerAddress>();
            this.VendorAddresses = new HashSet<VendorAddress>();
        }
    
        public int AddressTypeID { get; set; }
        public System.DateTime ModifiedDate { get; set; }
        public string Name { get; set; }
        public System.Guid rowguid { get; set; }
    
        public virtual ICollection<CustomerAddress> CustomerAddresses { get; set; }
        public virtual ICollection<VendorAddress> VendorAddresses { get; set; }
    }
}