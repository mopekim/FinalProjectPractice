﻿using System;
using System.Collections.Generic;

namespace RouteMasterUpOne.Models
{
    public partial class ExtraServiceImage
    {
        public int Id { get; set; }
        public int ExtraServiceId { get; set; }
        public string? Image { get; set; }

        public virtual ExtraService ExtraService { get; set; } = null!;
    }
}
