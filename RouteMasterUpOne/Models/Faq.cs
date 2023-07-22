using System;
using System.Collections.Generic;

namespace RouteMasterUpOne.Models
{
    public partial class Faq
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Question { get; set; } = null!;
        public string Answer { get; set; } = null!;
        public int Helpful { get; set; }
        public DateTime CreateDate { get; set; }
        public string Image { get; set; } = null!;
        public DateTime? ModifiedDate { get; set; }
    }
}
