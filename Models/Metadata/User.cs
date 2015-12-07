using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LDTE_Web.Models
{
    [MetadataType(typeof(User_Metadata))]
    public partial class User
    {
        //[Display(Name ="Users")]
        //public string DisplayName { get { return FirstName + " " + LastName; } }

        public int GroupID { get; set; }

        public string FormView { get; set; }

        public IEnumerable<SelectListItem> UserList { get; set; }
        public IEnumerable<string> SelectedItemId { get; set; }
    }

    public class User_Metadata
    {

   
       

        [Display(Name ="Prefix")]
        public object PrefixName { get; set; }

        [Display(Name = "First Name"), Required]
        public object FirstName { get; set; }

        [Display(Name = "Last Name"), Required]
        public object LastName { get; set; }

        [Display(Name = "Middle Name")]
        public object MiddleName { get; set; }

        [Display(Name = "Suffix")]
        public object SuffixName { get; set; }

        [Display(Name = "Date Of Birth"), Required]
        public object DateOfBirth { get; set; }

        [Display(Name = "Login"), Required]
        public object Login { get; set; }

        [Required]
        public object Password { get; set; }

        [Display(Name = "Security Hint"), Required]
        public object SecurityHint { get; set; }

        [Display(Name = "Security Answer"), Required]
        public object SecurityAnswer { get; set; }

        [Display(Name = "Last Login Attempt")]
        public object PasswordDate { get; set; }

        [Display(Name = "Locked Out?")]
        public object LockoutFlag { get; set; }

        [Display(Name = "Inactive Date")]
        public object InactiveDate { get; set; }


    }
}