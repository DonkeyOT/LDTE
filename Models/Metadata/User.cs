using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LDTE_Web.Models
{
    [MetadataType(typeof(User_Metadata))]
    public partial class User
    {
        [Display(Name ="Users")]
        public string DisplayName { get { return FirstName + " " + LastName; } }
    }

    public class User_Metadata
    {

        [Display(Name ="First Name"),Required]
        public object FirstName { get; set; }
        [Display(Name = "Last Name"), Required]
        public object LastName { get; set; }
        [Required]
        public object Password { get; set; }
        [Display(Name = "Work Phone")]
        public object PhoneWork { get; set; }
        [Display(Name = "Mobile Phone")]
        public object PhoneMobile { get; set; }

    }
}