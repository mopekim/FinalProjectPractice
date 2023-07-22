using System;
using System.Collections.Generic;

namespace RouteMasterUpOne.Models
{
    public partial class PackageTour
    {
        public PackageTour()
        {
            Activities = new HashSet<Activity>();
            Attractions = new HashSet<Attraction>();
            ExtraServices = new HashSet<ExtraService>();
        }

        public int Id { get; set; }
        public string Description { get; set; } = null!;
        public bool Status { get; set; }
        public int PackageCouponId { get; set; }

        public virtual ICollection<Activity> Activities { get; set; }
        public virtual ICollection<Attraction> Attractions { get; set; }
        public virtual ICollection<ExtraService> ExtraServices { get; set; }
    }
}
