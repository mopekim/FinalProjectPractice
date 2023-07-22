using System;
using System.Collections.Generic;

namespace RouteMasterUpOne.Models
{
    public partial class ServiceInfo
    {
        public ServiceInfo()
        {
            Accommodations = new HashSet<Accommodation>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Accommodation> Accommodations { get; set; }
    }
}
