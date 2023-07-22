using System;
using System.Collections.Generic;

namespace RouteMasterUpOne.Models
{
    public partial class Schedule
    {
        public int Id { get; set; }
        public int MemberId { get; set; }
        public string Content { get; set; } = null!;
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime CreateDate { get; set; }

        public virtual Member Member { get; set; } = null!;
    }
}
