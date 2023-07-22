using System;
using System.Collections.Generic;

namespace RouteMasterUpOne.Models
{
    public partial class ActivityCategory
    {
        public ActivityCategory()
        {
            Activities = new HashSet<Activity>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Activity> Activities { get; set; }
    }
}
