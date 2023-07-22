using System;
using System.Collections.Generic;

namespace RouteMasterUpOne.Models
{
    public partial class RoomImage
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public string Image { get; set; } = null!;

        public virtual Room Room { get; set; } = null!;
    }
}
