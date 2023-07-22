using System;
using System.Collections.Generic;

namespace RouteMasterUpOne.Models
{
    public partial class AttractionCategory
    {
        public AttractionCategory()
        {
            Attractions = new HashSet<Attraction>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Attraction> Attractions { get; set; }
    }
}
