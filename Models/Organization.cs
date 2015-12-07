//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LDTE_Web.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Organization
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Organization()
        {
            this.OrganizationAddresses = new HashSet<OrganizationAddress>();
        }
    
        public int OrganizationID { get; set; }
        public string OrganizationName { get; set; }
        public string OrganizationCode { get; set; }
        public string OrganizationAlias { get; set; }
        public string MasterAccount { get; set; }
        public string MasterPassword { get; set; }
        public string MasterPosition { get; set; }
        public Nullable<System.DateTime> InactiveDate { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrganizationAddress> OrganizationAddresses { get; set; }
        public virtual OrganizationPhone OrganizationPhone { get; set; }
    }
}