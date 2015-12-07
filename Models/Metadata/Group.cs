using System.ComponentModel.DataAnnotations;

namespace LDTE_Web.Models
{
    [MetadataType(typeof(Group_Metadata))]
    public partial class Group
    {
        [Display(Name = "User")]
        public int UserID { get; set; }

        public string FormView { get; set; }

        public string BackControl { get; set; }
        public string BackAction { get; set; }

        public string SearchObject { get; set; }

        public string SearchValue { get; set; }


    }

    public class Group_Metadata
    {

        [Display(Name = "Name"), Required]
        public object GroupName { get; set; }

        [Display(Name = "Code"), Required]
        public object GroupCode { get; set; }

        [Display(Name = "Alias")]
        public object GroupAlias { get; set; }

        [Display(Name = "Description")]
        public object GroupDescription { get; set; }


    }

}