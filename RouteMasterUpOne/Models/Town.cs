using System;
using System.Collections.Generic;

namespace RouteMasterUpOne.Models
{
    public partial class Town
    {
        public Town()
        {
            Accommodations = new HashSet<Accommodation>();
            Attractions = new HashSet<Attraction>();
        }

        public int Id { get; set; }
        public int RegionId { get; set; }
        public string Name { get; set; } = null!;

        public virtual Region Region { get; set; } = null!;
        public virtual ICollection<Accommodation> Accommodations { get; set; }
        public virtual ICollection<Attraction> Attractions { get; set; }
    }
}
