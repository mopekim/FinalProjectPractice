using System;
using System.Collections.Generic;

namespace RouteMasterUpOne.Models
{
    public partial class ActivityImage
    {
        public int Id { get; set; }
        public int ActivityId { get; set; }
        public string? Image { get; set; }

        public virtual Activity Activity { get; set; } = null!;
    }
}
