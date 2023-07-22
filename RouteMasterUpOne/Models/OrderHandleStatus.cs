using System;
using System.Collections.Generic;

namespace RouteMasterUpOne.Models
{
    public partial class OrderHandleStatus
    {
        public OrderHandleStatus()
        {
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Order> Orders { get; set; }
    }
}
