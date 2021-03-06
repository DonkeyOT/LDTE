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
    
    public partial class ClientAccountGroup
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ClientAccountGroup()
        {
            this.ClientAccountGroupRoutines = new HashSet<ClientAccountGroupRoutine>();
        }
    
        public int ClientAccountGroupID { get; set; }
        public int ClientID { get; set; }
        public int NetworkID { get; set; }
        public string ClientAccountGroupName { get; set; }
        public string ClientAccountGroupCode { get; set; }
        public string Carrier { get; set; }
        public string AccountIdentifier { get; set; }
        public string GroupIdentifier { get; set; }
        public string ClientAccountGroupAlias { get; set; }
        public string PlanCode { get; set; }
        public string PlanAlias { get; set; }
        public bool EligibilityFlag { get; set; }
        public bool OutOfPocketFlag { get; set; }
        public bool DeductibleFlag { get; set; }
    
        public virtual Client Client { get; set; }
        public virtual Network Network { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ClientAccountGroupRoutine> ClientAccountGroupRoutines { get; set; }
    }
}
