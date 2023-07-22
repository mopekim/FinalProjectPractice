using System;
using System.Collections.Generic;

namespace RouteMasterUpOne.Models
{
    public partial class PaymentMethod
    {
        public PaymentMethod()
        {
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public bool Status { get; set; }
        public string Description { get; set; } = null!;

        public virtual ICollection<Order> Orders { get; set; }
    }
}
