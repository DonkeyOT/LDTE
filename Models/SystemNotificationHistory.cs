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
    
    public partial class SystemNotificationHistory
    {
        public int SystemNotificationHistoryID { get; set; }
        public int SystemNotificationID { get; set; }
        public System.DateTime SystemNotificationDate { get; set; }
    
        public virtual SystemNotification SystemNotification { get; set; }
    }
}
