using System;
using System.Collections.Generic;

namespace RouteMasterUpOne.Models
{
    public partial class TravelPlan
    {
        public TravelPlan()
        {
            Orders = new HashSet<Order>();
            ActivityProducts = new HashSet<ActivityProduct>();
            Attractions = new HashSet<Attraction>();
            ExtraServiceProducts = new HashSet<ExtraServiceProduct>();
        }

        public int Id { get; set; }
        public int MemberId { get; set; }
        public int TravelDays { get; set; }
        public DateTime CreateDate { get; set; }

        public virtual Member Member { get; set; } = null!;
        public virtual ICollection<Order> Orders { get; set; }

        public virtual ICollection<ActivityProduct> ActivityProducts { get; set; }
        public virtual ICollection<Attraction> Attractions { get; set; }
        public virtual ICollection<ExtraServiceProduct> ExtraServiceProducts { get; set; }
    }
}
