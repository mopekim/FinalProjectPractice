using System;
using System.Collections.Generic;

namespace RouteMasterUpOne.Models
{
    public partial class AttractionClick
    {
        public int Id { get; set; }
        public int AttractionId { get; set; }
        public DateTime ClickDate { get; set; }

        public virtual Attraction Attraction { get; set; } = null!;
    }
}
