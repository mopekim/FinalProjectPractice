using System;
using System.Collections.Generic;

namespace RouteMasterUpOne.Models
{
    public partial class AccommodationImage
    {
        public int Id { get; set; }
        public int AccommodationId { get; set; }
        public string Name { get; set; } = null!;
        public string Image { get; set; } = null!;
        public int DisplayOrder { get; set; }

        public virtual Accommodation Accommodation { get; set; } = null!;
    }
}
