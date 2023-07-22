using System;
using System.Collections.Generic;

namespace RouteMasterUpOne.Models
{
    public partial class CartActivitiesDetail
    {
        public int Id { get; set; }
        public int CartId { get; set; }
        public int ActivityProductId { get; set; }
        public int Quantity { get; set; }

        public virtual ActivityProduct ActivityProduct { get; set; } = null!;
        public virtual Cart Cart { get; set; } = null!;
    }
}
