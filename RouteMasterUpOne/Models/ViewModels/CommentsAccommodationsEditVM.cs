using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace RouteMasterUpOne.Models.ViewModels
{
    public class CommentsAccommodationsEditVM
    {
        public int Id { get; set; }

        [Display(Name = "分數")]
        [Required]
        public int Score { get; set; }

        [Display(Name = "標題")]
        [Required]
        public string? Title { get; set; }

        [Display(Name = "優點")]
        public string? Pros { get; set; }

        [Display(Name = "缺點")]
        public string? Cons { get; set; }
    }
}
