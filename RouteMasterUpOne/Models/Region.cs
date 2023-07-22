using System;
using System.Collections.Generic;

namespace RouteMasterUpOne.Models
{
    public partial class Region
    {
        public Region()
        {
            Accommodations = new HashSet<Accommodation>();
            Activities = new HashSet<Activity>();
            Attractions = new HashSet<Attraction>();
            Towns = new HashSet<Town>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Accommodation> Accommodations { get; set; }
        public virtual ICollection<Activity> Activities { get; set; }
        public virtual ICollection<Attraction> Attractions { get; set; }
        public virtual ICollection<Town> Towns { get; set; }
    }
}
