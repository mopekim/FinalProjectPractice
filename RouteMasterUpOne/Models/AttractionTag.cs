using System;
using System.Collections.Generic;

namespace RouteMasterUpOne.Models
{
    public partial class AttractionTag
    {
        public AttractionTag()
        {
            Attractions = new HashSet<Attraction>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<Attraction> Attractions { get; set; }
    }
}
