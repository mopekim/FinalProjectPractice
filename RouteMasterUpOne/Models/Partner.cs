using System;
using System.Collections.Generic;

namespace RouteMasterUpOne.Models
{
    public partial class Partner
    {
        public Partner()
        {
            Accommodations = new HashSet<Accommodation>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string EncryptedPassword { get; set; } = null!;
        public string Email { get; set; } = null!;
        public DateTime CreateDate { get; set; }
        public bool IsConfirmed { get; set; }
        public string? ConfirmCode { get; set; }
        public string? GoogleAccessCode { get; set; }
        public string? FaceBookAccessCode { get; set; }
        public string? LineAccessCode { get; set; }
        public bool IsSuspended { get; set; }

        public virtual ICollection<Accommodation> Accommodations { get; set; }
    }
}
