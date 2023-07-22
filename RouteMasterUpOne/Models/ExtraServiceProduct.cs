﻿using System;
using System.Collections.Generic;

namespace RouteMasterUpOne.Models
{
    public partial class ExtraServiceProduct
    {
        public ExtraServiceProduct()
        {
            CartExtraServicesDetails = new HashSet<CartExtraServicesDetail>();
            OrderExtraServicesDetails = new HashSet<OrderExtraServicesDetail>();
            TravelPlans = new HashSet<TravelPlan>();
        }

        public int Id { get; set; }
        public int ExtraServiceId { get; set; }
        public DateTime Date { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }

        public virtual ExtraService ExtraService { get; set; } = null!;
        public virtual ICollection<CartExtraServicesDetail> CartExtraServicesDetails { get; set; }
        public virtual ICollection<OrderExtraServicesDetail> OrderExtraServicesDetails { get; set; }

        public virtual ICollection<TravelPlan> TravelPlans { get; set; }
    }
}
