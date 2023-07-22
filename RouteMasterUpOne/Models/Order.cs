﻿using System;
using System.Collections.Generic;

namespace RouteMasterUpOne.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderAccommodationDetails = new HashSet<OrderAccommodationDetail>();
            OrderActivitiesDetails = new HashSet<OrderActivitiesDetail>();
            OrderExtraServicesDetails = new HashSet<OrderExtraServicesDetail>();
        }

        public int Id { get; set; }
        public int MemberId { get; set; }
        public int TravelPlanId { get; set; }
        public int PaymentMethodId { get; set; }
        public int PaymentStatusId { get; set; }
        public int OrderHandleStatusId { get; set; }
        public int CouponsId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int Total { get; set; }

        public virtual Coupon Coupons { get; set; } = null!;
        public virtual Member Member { get; set; } = null!;
        public virtual OrderHandleStatus OrderHandleStatus { get; set; } = null!;
        public virtual PaymentMethod PaymentMethod { get; set; } = null!;
        public virtual PaymentStatus PaymentStatus { get; set; } = null!;
        public virtual TravelPlan TravelPlan { get; set; } = null!;
        public virtual ICollection<OrderAccommodationDetail> OrderAccommodationDetails { get; set; }
        public virtual ICollection<OrderActivitiesDetail> OrderActivitiesDetails { get; set; }
        public virtual ICollection<OrderExtraServicesDetail> OrderExtraServicesDetails { get; set; }
    }
}
