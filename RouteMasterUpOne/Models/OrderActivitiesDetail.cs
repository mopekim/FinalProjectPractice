﻿using System;
using System.Collections.Generic;

namespace RouteMasterUpOne.Models
{
    public partial class OrderActivitiesDetail
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ActivityProductId { get; set; }
        public string ActivityName { get; set; } = null!;
        public DateTime Date { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }

        public virtual ActivityProduct ActivityProduct { get; set; } = null!;
        public virtual Order Order { get; set; } = null!;
    }
}
