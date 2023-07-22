using System;
using System.Collections.Generic;

namespace RouteMasterUpOne.Models
{
    public partial class Administrator
    {
        public int Id { get; set; }
        public int PermissionId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string EncryptedPassword { get; set; } = null!;
        public string Email { get; set; } = null!;
        public DateTime CreateDate { get; set; }
        public string? ConfirmCode { get; set; }
        public bool IsSuspended { get; set; }

        public virtual Permission Permission { get; set; } = null!;
    }
}
