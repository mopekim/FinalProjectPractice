using System;
using System.Collections.Generic;

namespace RouteMasterUpOne.Models
{
    public partial class AcommodationCategory
    {
        public AcommodationCategory()
        {
            Accommodations = new HashSet<Accommodation>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Accommodation> Accommodations { get; set; }
    }
}
