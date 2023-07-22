using System;
using System.Collections.Generic;

namespace RouteMasterUpOne.Models
{
    public partial class Room
    {
        public Room()
        {
            RoomImages = new HashSet<RoomImage>();
            RoomProducts = new HashSet<RoomProduct>();
            RoomServiceInfos = new HashSet<RoomServiceInfo>();
        }

        public int Id { get; set; }
        public int AccommodationId { get; set; }
        public int RoomTypeId { get; set; }
        public string Name { get; set; } = null!;
        public int Price { get; set; }
        public int Quantity { get; set; }
        public string? Description { get; set; }

        public virtual Accommodation Accommodation { get; set; } = null!;
        public virtual RoomType RoomType { get; set; } = null!;
        public virtual ICollection<RoomImage> RoomImages { get; set; }
        public virtual ICollection<RoomProduct> RoomProducts { get; set; }

        public virtual ICollection<RoomServiceInfo> RoomServiceInfos { get; set; }
    }
}
