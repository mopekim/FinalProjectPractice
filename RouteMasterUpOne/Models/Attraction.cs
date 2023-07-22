﻿using System;
using System.Collections.Generic;

namespace RouteMasterUpOne.Models
{
    public partial class Attraction
    {
        public Attraction()
        {
            Activities = new HashSet<Activity>();
            AttractionClicks = new HashSet<AttractionClick>();
            AttractionImages = new HashSet<AttractionImage>();
            CommentsAttractions = new HashSet<CommentsAttraction>();
            ExtraServices = new HashSet<ExtraService>();
            PackageTours = new HashSet<PackageTour>();
            Tags = new HashSet<AttractionTag>();
            TravelPlans = new HashSet<TravelPlan>();
        }

        public int Id { get; set; }
        public int AttractionCategoryId { get; set; }
        public string Name { get; set; } = null!;
        public int RegionId { get; set; }
        public int TownId { get; set; }
        public string Address { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string? Image { get; set; }
        public string? Website { get; set; }
        public double? PositionX { get; set; }
        public double? PositionY { get; set; }

        public virtual AttractionCategory AttractionCategory { get; set; } = null!;
        public virtual Region Region { get; set; } = null!;
        public virtual Town Town { get; set; } = null!;
        public virtual ICollection<Activity> Activities { get; set; }
        public virtual ICollection<AttractionClick> AttractionClicks { get; set; }
        public virtual ICollection<AttractionImage> AttractionImages { get; set; }
        public virtual ICollection<CommentsAttraction> CommentsAttractions { get; set; }
        public virtual ICollection<ExtraService> ExtraServices { get; set; }

        public virtual ICollection<PackageTour> PackageTours { get; set; }
        public virtual ICollection<AttractionTag> Tags { get; set; }
        public virtual ICollection<TravelPlan> TravelPlans { get; set; }
    }
}
