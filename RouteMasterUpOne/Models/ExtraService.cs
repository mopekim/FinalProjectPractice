using System;
using System.Collections.Generic;

namespace RouteMasterUpOne.Models
{
    public partial class ExtraService
    {
        public ExtraService()
        {
            ExtraServiceImages = new HashSet<ExtraServiceImage>();
            ExtraServiceProducts = new HashSet<ExtraServiceProduct>();
            PackageTours = new HashSet<PackageTour>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int AttractionId { get; set; }
        public string Description { get; set; } = null!;
        public bool Status { get; set; }
        public string Image { get; set; } = null!;

        public virtual Attraction Attraction { get; set; } = null!;
        public virtual ICollection<ExtraServiceImage> ExtraServiceImages { get; set; }
        public virtual ICollection<ExtraServiceProduct> ExtraServiceProducts { get; set; }

        public virtual ICollection<PackageTour> PackageTours { get; set; }
    }
}
