using System;
using System.Collections.Generic;

namespace RouteMasterUpOne.Models
{
    public partial class CommentsAccommodation
    {
        public CommentsAccommodation()
        {
            CommentAccommodationLikes = new HashSet<CommentAccommodationLike>();
        }

        public int Id { get; set; }
        public int MemberId { get; set; }
        public int AccommodationId { get; set; }
        public int Score { get; set; }
        public string? Title { get; set; }
        public string? Pros { get; set; }
        public string? Cons { get; set; }
        public DateTime CreateDate { get; set; }
        public string? Reply { get; set; }
        public DateTime? ReplyAt { get; set; }

        public virtual Accommodation Accommodation { get; set; } = null!;
        public virtual Member Member { get; set; } = null!;
        public virtual ICollection<CommentAccommodationLike> CommentAccommodationLikes { get; set; }
    }
}
