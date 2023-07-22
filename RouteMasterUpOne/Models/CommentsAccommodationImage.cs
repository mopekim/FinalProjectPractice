using System;
using System.Collections.Generic;

namespace RouteMasterUpOne.Models
{
    public partial class CommentsAccommodationImage
    {
        public int Id { get; set; }
        public int CommentsAccommodationId { get; set; }
        public string Image { get; set; } = null!;
    }
}
