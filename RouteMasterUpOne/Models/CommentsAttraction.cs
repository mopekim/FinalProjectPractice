using System;
using System.Collections.Generic;

namespace RouteMasterUpOne.Models
{
    public partial class CommentsAttraction
    {
        public CommentsAttraction()
        {
            ReportedAttractionComments = new HashSet<ReportedAttractionComment>();
        }

        public int Id { get; set; }
        public int MemberId { get; set; }
        public int AttractionId { get; set; }
        public int Score { get; set; }
        public string? Content { get; set; }
        public int? StayHours { get; set; }
        public int? Price { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsHidden { get; set; }

        public virtual Attraction Attraction { get; set; } = null!;
        public virtual Member Member { get; set; } = null!;
        public virtual ICollection<ReportedAttractionComment> ReportedAttractionComments { get; set; }
    }
}
