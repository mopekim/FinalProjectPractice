using System;
using System.Collections.Generic;

namespace RouteMasterUpOne.Models
{
    public partial class Activity
    {
        public Activity()
        {
            ActivityImages = new HashSet<ActivityImage>();
            ActivityProducts = new HashSet<ActivityProduct>();
            PackageTours = new HashSet<PackageTour>();
        }

        public int Id { get; set; }
        public int ActivityCategoryId { get; set; }
        public string Name { get; set; } = null!;
        public int RegionId { get; set; }
        public int AttractionId { get; set; }
        public string Description { get; set; } = null!;
        public bool Status { get; set; }
        public string Image { get; set; } = null!;

        public virtual ActivityCategory ActivityCategory { get; set; } = null!;
        public virtual Attraction Attraction { get; set; } = null!;
        public virtual Region Region { get; set; } = null!;
        public virtual ICollection<ActivityImage> ActivityImages { get; set; }
        public virtual ICollection<ActivityProduct> ActivityProducts { get; set; }

        public virtual ICollection<PackageTour> PackageTours { get; set; }
    }
}
