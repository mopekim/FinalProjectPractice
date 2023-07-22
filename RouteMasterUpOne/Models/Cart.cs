﻿using System;
using System.Collections.Generic;

namespace RouteMasterUpOne.Models
{
    public partial class Cart
    {
        public Cart()
        {
            CartAccommodationDetails = new HashSet<CartAccommodationDetail>();
            CartActivitiesDetails = new HashSet<CartActivitiesDetail>();
            CartExtraServicesDetails = new HashSet<CartExtraServicesDetail>();
        }

        public int Id { get; set; }
        public int MemberId { get; set; }

        public virtual Member Member { get; set; } = null!;
        public virtual ICollection<CartAccommodationDetail> CartAccommodationDetails { get; set; }
        public virtual ICollection<CartActivitiesDetail> CartActivitiesDetails { get; set; }
        public virtual ICollection<CartExtraServicesDetail> CartExtraServicesDetails { get; set; }
    }
}
