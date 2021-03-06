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
    
    public partial class SystemModule
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SystemModule()
        {
            this.SystemDomainModules = new HashSet<SystemDomainModule>();
            this.SystemNavigations = new HashSet<SystemNavigation>();
        }
    
        public int SystemModuleID { get; set; }
        public string SystemModuleName { get; set; }
        public string SystemModuleCode { get; set; }
        public string SystemModuleAlias { get; set; }
        public string SystemModuleDescription { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SystemDomainModule> SystemDomainModules { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SystemNavigation> SystemNavigations { get; set; }
    }
}
