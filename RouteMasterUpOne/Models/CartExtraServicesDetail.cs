using System;
using System.Collections.Generic;

namespace RouteMasterUpOne.Models
{
    public partial class CartExtraServicesDetail
    {
        public int Id { get; set; }
        public int CartId { get; set; }
        public int ExtraServiceProductId { get; set; }
        public int Quantity { get; set; }

        public virtual Cart Cart { get; set; } = null!;
        public virtual ExtraServiceProduct ExtraServiceProduct { get; set; } = null!;
    }
}
