using System;
using System.Collections.Generic;

namespace RouteMasterUpOne.Models
{
    public partial class RoomProduct
    {
        public RoomProduct()
        {
            CartAccommodationDetails = new HashSet<CartAccommodationDetail>();
        }

        public int Id { get; set; }
        public int RoomId { get; set; }
        public DateTime Date { get; set; }
        public decimal? NewPrice { get; set; }
        public int Quantity { get; set; }

        public virtual Room Room { get; set; } = null!;
        public virtual ICollection<CartAccommodationDetail> CartAccommodationDetails { get; set; }
    }
}
