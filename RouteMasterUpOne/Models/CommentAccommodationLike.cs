using System;
using System.Collections.Generic;

namespace RouteMasterUpOne.Models
{
    public partial class CommentAccommodationLike
    {
        public int Id { get; set; }
        public int MemberId { get; set; }
        public int CommentsAccommodationId { get; set; }
        public DateTime CreateDate { get; set; }

        public virtual CommentsAccommodation CommentsAccommodation { get; set; } = null!;
        public virtual Member Member { get; set; } = null!;
    }
}
