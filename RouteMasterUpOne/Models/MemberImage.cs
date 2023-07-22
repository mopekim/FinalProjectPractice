using System;
using System.Collections.Generic;

namespace RouteMasterUpOne.Models
{
    public partial class MemberImage
    {
        public int Id { get; set; }
        public int MemberId { get; set; }
        public string Name { get; set; } = null!;
        public string Image { get; set; } = null!;

        public virtual Member Member { get; set; } = null!;
    }
}
