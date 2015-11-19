using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LDTE_Web.Models
{
    public partial class Group
    {
        [Display(Name = "User")]
        public int UserID { get; set; }
    }

}