using System;
using System.Collections.Generic;

namespace RouteMasterUpOne.Models
{
    public partial class CommentsAttractionImage
    {
        public int Id { get; set; }
        public int CommentsAttractionId { get; set; }
        public string Image { get; set; } = null!;
    }
}
