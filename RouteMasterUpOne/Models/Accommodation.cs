using System;
using System.Collections.Generic;

namespace RouteMasterUpOne.Models
{
    public partial class Accommodation
    {
        public Accommodation()
        {
            AccommodationImages = new HashSet<AccommodationImage>();
            CommentsAccommodations = new HashSet<CommentsAccommodation>();
            Rooms = new HashSet<Room>();
            ServiceInfos = new HashSet<ServiceInfo>();
        }

        public int Id { get; set; }
        public int AcommodationCategoryId { get; set; }
        public int PartnerId { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public double? Grade { get; set; }
        public int RegionId { get; set; }
        public int TownId { get; set; }
        public string Address { get; set; } = null!;
        public double? PositionX { get; set; }
        public double? PositionY { get; set; }
        public string? Website { get; set; }
        public string? IndustryEmail { get; set; }
        public int? ParkingSpace { get; set; }
        public TimeSpan? CheckIn { get; set; }
        public TimeSpan? CheckOut { get; set; }
        public bool? Status { get; set; }
        public string Image { get; set; } = null!;
        public DateTime CreateDate { get; set; }

        public virtual AcommodationCategory AcommodationCategory { get; set; } = null!;
        public virtual Partner Partner { get; set; } = null!;
        public virtual Region Region { get; set; } = null!;
        public virtual Town Town { get; set; } = null!;
        public virtual ICollection<AccommodationImage> AccommodationImages { get; set; }
        public virtual ICollection<CommentsAccommodation> CommentsAccommodations { get; set; }
        public virtual ICollection<Room> Rooms { get; set; }

        public virtual ICollection<ServiceInfo> ServiceInfos { get; set; }
    }
}
