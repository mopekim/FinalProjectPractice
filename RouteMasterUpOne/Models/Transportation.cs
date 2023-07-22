using System;
using System.Collections.Generic;

namespace RouteMasterUpOne.Models
{
    public partial class Transportation
    {
        public int Id { get; set; }
        public int TravelPlanId { get; set; }
        public string? Vehicle { get; set; }
        public string? Departure { get; set; }
        public string? Arrival { get; set; }
        public TimeSpan? TimeSpent { get; set; }
    }
}
