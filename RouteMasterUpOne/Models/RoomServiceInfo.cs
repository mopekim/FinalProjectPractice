using System;
using System.Collections.Generic;

namespace RouteMasterUpOne.Models
{
    public partial class RoomServiceInfo
    {
        public RoomServiceInfo()
        {
            Rooms = new HashSet<Room>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Room> Rooms { get; set; }
    }
}
