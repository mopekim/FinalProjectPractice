using System;
using System.Collections.Generic;

namespace RouteMasterUpOne.Models
{
    public partial class Permission
    {
        public Permission()
        {
            Administrators = new HashSet<Administrator>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Administrator> Administrators { get; set; }
    }
}
