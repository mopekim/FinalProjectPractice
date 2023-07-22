using System;
using System.Collections.Generic;

namespace RouteMasterUpOne.Models
{
    public partial class ReportedAttractionComment
    {
        public int Id { get; set; }
        public int CommentAttractionId { get; set; }
        public int ReportReasonId { get; set; }
        public bool IsHandled { get; set; }

        public virtual CommentsAttraction CommentAttraction { get; set; } = null!;
    }
}
