using System;
using System.Collections.Generic;

namespace RouteMasterUpOne.Models
{
    public partial class AttractionImage
    {
        public int Id { get; set; }
        public int AttractionId { get; set; }
        public string? Image { get; set; }

        public virtual Attraction Attraction { get; set; } = null!;
    }
}
