using System;
using System.Collections.Generic;

namespace RouteMasterUpOne.Models
{
    public partial class OrderExtraServicesDetail
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ExtraServiceProductId { get; set; }
        public string ExtraServiceName { get; set; } = null!;
        public DateTime Date { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }

        public virtual ExtraServiceProduct ExtraServiceProduct { get; set; } = null!;
        public virtual Order Order { get; set; } = null!;
    }
}
