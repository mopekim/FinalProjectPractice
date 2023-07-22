using System;
using System.Collections.Generic;

namespace RouteMasterUpOne.Models
{
    public partial class CartAccommodationDetail
    {
        public int Id { get; set; }
        public int CartId { get; set; }
        public int RoomProductId { get; set; }
        public int Quantity { get; set; }

        public virtual Cart Cart { get; set; } = null!;
        public virtual RoomProduct RoomProduct { get; set; } = null!;
    }
}
