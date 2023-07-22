using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using RouteMasterUpOne.Models.ViewModels;

namespace RouteMasterUpOne.Models
{
    public partial class CoreRouteMasterContext : DbContext
    {
        public CoreRouteMasterContext()
        {
        }

        public CoreRouteMasterContext(DbContextOptions<CoreRouteMasterContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Accommodation> Accommodations { get; set; } = null!;
        public virtual DbSet<AccommodationImage> AccommodationImages { get; set; } = null!;
        public virtual DbSet<AcommodationCategory> AcommodationCategories { get; set; } = null!;
        public virtual DbSet<Activity> Activities { get; set; } = null!;
        public virtual DbSet<ActivityCategory> ActivityCategories { get; set; } = null!;
        public virtual DbSet<ActivityImage> ActivityImages { get; set; } = null!;
        public virtual DbSet<ActivityProduct> ActivityProducts { get; set; } = null!;
        public virtual DbSet<Administrator> Administrators { get; set; } = null!;
        public virtual DbSet<Attraction> Attractions { get; set; } = null!;
        public virtual DbSet<AttractionCategory> AttractionCategories { get; set; } = null!;
        public virtual DbSet<AttractionClick> AttractionClicks { get; set; } = null!;
        public virtual DbSet<AttractionImage> AttractionImages { get; set; } = null!;
        public virtual DbSet<AttractionTag> AttractionTags { get; set; } = null!;
        public virtual DbSet<Cart> Carts { get; set; } = null!;
        public virtual DbSet<CartAccommodationDetail> CartAccommodationDetails { get; set; } = null!;
        public virtual DbSet<CartActivitiesDetail> CartActivitiesDetails { get; set; } = null!;
        public virtual DbSet<CartExtraServicesDetail> CartExtraServicesDetails { get; set; } = null!;
        public virtual DbSet<CommentAccommodationLike> CommentAccommodationLikes { get; set; } = null!;
        public virtual DbSet<CommentsAccommodation> CommentsAccommodations { get; set; } = null!;
        public virtual DbSet<CommentsAccommodationImage> CommentsAccommodationImages { get; set; } = null!;
        public virtual DbSet<CommentsAttraction> CommentsAttractions { get; set; } = null!;
        public virtual DbSet<CommentsAttractionImage> CommentsAttractionImages { get; set; } = null!;
        public virtual DbSet<Coupon> Coupons { get; set; } = null!;
        public virtual DbSet<ExtraService> ExtraServices { get; set; } = null!;
        public virtual DbSet<ExtraServiceImage> ExtraServiceImages { get; set; } = null!;
        public virtual DbSet<ExtraServiceProduct> ExtraServiceProducts { get; set; } = null!;
        public virtual DbSet<Faq> Faqs { get; set; } = null!;
        public virtual DbSet<Faqcategory> Faqcategories { get; set; } = null!;
        public virtual DbSet<Member> Members { get; set; } = null!;
        public virtual DbSet<MemberImage> MemberImages { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<OrderAccommodationDetail> OrderAccommodationDetails { get; set; } = null!;
        public virtual DbSet<OrderActivitiesDetail> OrderActivitiesDetails { get; set; } = null!;
        public virtual DbSet<OrderExtraServicesDetail> OrderExtraServicesDetails { get; set; } = null!;
        public virtual DbSet<OrderHandleStatus> OrderHandleStatuses { get; set; } = null!;
        public virtual DbSet<PackageCoupon> PackageCoupons { get; set; } = null!;
        public virtual DbSet<PackageTour> PackageTours { get; set; } = null!;
        public virtual DbSet<Partner> Partners { get; set; } = null!;
        public virtual DbSet<PaymentMethod> PaymentMethods { get; set; } = null!;
        public virtual DbSet<PaymentStatus> PaymentStatuses { get; set; } = null!;
        public virtual DbSet<Permission> Permissions { get; set; } = null!;
        public virtual DbSet<Region> Regions { get; set; } = null!;
        public virtual DbSet<ReportReason> ReportReasons { get; set; } = null!;
        public virtual DbSet<ReportedAttractionComment> ReportedAttractionComments { get; set; } = null!;
        public virtual DbSet<Room> Rooms { get; set; } = null!;
        public virtual DbSet<RoomImage> RoomImages { get; set; } = null!;
        public virtual DbSet<RoomProduct> RoomProducts { get; set; } = null!;
        public virtual DbSet<RoomServiceInfo> RoomServiceInfos { get; set; } = null!;
        public virtual DbSet<RoomType> RoomTypes { get; set; } = null!;
        public virtual DbSet<Schedule> Schedules { get; set; } = null!;
        public virtual DbSet<ServiceInfo> ServiceInfos { get; set; } = null!;
        public virtual DbSet<SystemImage> SystemImages { get; set; } = null!;
        public virtual DbSet<Town> Towns { get; set; } = null!;
        public virtual DbSet<Transportation> Transportations { get; set; } = null!;
        public virtual DbSet<TravelPlan> TravelPlans { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot config =new ConfigurationBuilder()
                    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                    .AddJsonFile("appsettings.json")
                    .Build();
                optionsBuilder.UseSqlServer(config.GetConnectionString("CoreRouteMaster"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Accommodation>(entity =>
            {
                entity.Property(e => e.Address).HasMaxLength(300);

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description).HasMaxLength(2000);

                entity.Property(e => e.Image).HasMaxLength(200);

                entity.Property(e => e.IndustryEmail).HasMaxLength(255);

                entity.Property(e => e.Name).HasMaxLength(30);

                entity.Property(e => e.Website).HasMaxLength(2000);

                entity.HasOne(d => d.AcommodationCategory)
                    .WithMany(p => p.Accommodations)
                    .HasForeignKey(d => d.AcommodationCategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Accommoda__Creat__4F7CD00D");

                entity.HasOne(d => d.Partner)
                    .WithMany(p => p.Accommodations)
                    .HasForeignKey(d => d.PartnerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Accommoda__Partn__5070F446");

                entity.HasOne(d => d.Region)
                    .WithMany(p => p.Accommodations)
                    .HasForeignKey(d => d.RegionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Accommoda__Regio__5165187F");

                entity.HasOne(d => d.Town)
                    .WithMany(p => p.Accommodations)
                    .HasForeignKey(d => d.TownId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Accommoda__TownI__52593CB8");

                entity.HasMany(d => d.ServiceInfos)
                    .WithMany(p => p.Accommodations)
                    .UsingEntity<Dictionary<string, object>>(
                        "ServiceInfosAccommodation",
                        l => l.HasOne<ServiceInfo>().WithMany().HasForeignKey("ServiceInfoId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__ServiceIn__Servi__6383C8BA"),
                        r => r.HasOne<Accommodation>().WithMany().HasForeignKey("AccommodationId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__ServiceIn__Servi__628FA481"),
                        j =>
                        {
                            j.HasKey("AccommodationId", "ServiceInfoId").HasName("PK__ServiceI__33AF472BBC406364");

                            j.ToTable("ServiceInfos_Accommodations");
                        });
            });

            modelBuilder.Entity<AccommodationImage>(entity =>
            {
                entity.Property(e => e.Image).HasMaxLength(200);

                entity.Property(e => e.Name).HasMaxLength(30);

                entity.HasOne(d => d.Accommodation)
                    .WithMany(p => p.AccommodationImages)
                    .HasForeignKey(d => d.AccommodationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Accommoda__Accom__5535A963");
            });

            modelBuilder.Entity<AcommodationCategory>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(30);
            });

            modelBuilder.Entity<Activity>(entity =>
            {
                entity.Property(e => e.Description).HasMaxLength(2000);

                entity.Property(e => e.Image).HasMaxLength(200);

                entity.Property(e => e.Name).HasMaxLength(30);

                entity.HasOne(d => d.ActivityCategory)
                    .WithMany(p => p.Activities)
                    .HasForeignKey(d => d.ActivityCategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Activitie__Image__1F98B2C1");

                entity.HasOne(d => d.Attraction)
                    .WithMany(p => p.Activities)
                    .HasForeignKey(d => d.AttractionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Activitie__Attra__2180FB33");

                entity.HasOne(d => d.Region)
                    .WithMany(p => p.Activities)
                    .HasForeignKey(d => d.RegionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Activitie__Regio__208CD6FA");
            });

            modelBuilder.Entity<ActivityCategory>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(30);
            });

            modelBuilder.Entity<ActivityImage>(entity =>
            {
                entity.Property(e => e.Image).HasMaxLength(200);

                entity.HasOne(d => d.Activity)
                    .WithMany(p => p.ActivityImages)
                    .HasForeignKey(d => d.ActivityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ActivityI__Activ__2739D489");
            });

            modelBuilder.Entity<ActivityProduct>(entity =>
            {
                entity.Property(e => e.Date).HasColumnType("date");

                entity.HasOne(d => d.Activity)
                    .WithMany(p => p.ActivityProducts)
                    .HasForeignKey(d => d.ActivityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ActivityP__Quant__245D67DE");
            });

            modelBuilder.Entity<Administrator>(entity =>
            {
                entity.Property(e => e.ConfirmCode).HasMaxLength(300);

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email).HasMaxLength(255);

                entity.Property(e => e.EncryptedPassword).HasMaxLength(255);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.HasOne(d => d.Permission)
                    .WithMany(p => p.Administrators)
                    .HasForeignKey(d => d.PermissionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Administr__Permi__3A81B327");
            });

            modelBuilder.Entity<Attraction>(entity =>
            {
                entity.Property(e => e.Address).HasMaxLength(300);

                entity.Property(e => e.Description).HasMaxLength(2000);

                entity.Property(e => e.Image).HasMaxLength(200);

                entity.Property(e => e.Name).HasMaxLength(30);

                entity.Property(e => e.Website).HasMaxLength(2000);

                entity.HasOne(d => d.AttractionCategory)
                    .WithMany(p => p.Attractions)
                    .HasForeignKey(d => d.AttractionCategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Attractio__Posit__7C4F7684");

                entity.HasOne(d => d.Region)
                    .WithMany(p => p.Attractions)
                    .HasForeignKey(d => d.RegionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Attractio__Regio__7D439ABD");

                entity.HasOne(d => d.Town)
                    .WithMany(p => p.Attractions)
                    .HasForeignKey(d => d.TownId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Attractio__TownI__7E37BEF6");

                entity.HasMany(d => d.Tags)
                    .WithMany(p => p.Attractions)
                    .UsingEntity<Dictionary<string, object>>(
                        "TagsAttraction",
                        l => l.HasOne<AttractionTag>().WithMany().HasForeignKey("TagId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__Tags_Attr__TagId__0A9D95DB"),
                        r => r.HasOne<Attraction>().WithMany().HasForeignKey("AttractionId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__Tags_Attr__TagId__09A971A2"),
                        j =>
                        {
                            j.HasKey("AttractionId", "TagId").HasName("PK__Tags_Att__0CB582C0EDD29777");

                            j.ToTable("Tags_Attractions");
                        });
            });

            modelBuilder.Entity<AttractionCategory>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(30);
            });

            modelBuilder.Entity<AttractionClick>(entity =>
            {
                entity.ToTable("AttractionClick");

                entity.Property(e => e.ClickDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Attraction)
                    .WithMany(p => p.AttractionClicks)
                    .HasForeignKey(d => d.AttractionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Attractio__Click__02084FDA");
            });

            modelBuilder.Entity<AttractionImage>(entity =>
            {
                entity.Property(e => e.Image).HasMaxLength(200);

                entity.HasOne(d => d.Attraction)
                    .WithMany(p => p.AttractionImages)
                    .HasForeignKey(d => d.AttractionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Attractio__Attra__04E4BC85");
            });

            modelBuilder.Entity<AttractionTag>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Cart>(entity =>
            {
                entity.HasOne(d => d.Member)
                    .WithMany(p => p.Carts)
                    .HasForeignKey(d => d.MemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Carts__MemberId__56E8E7AB");
            });

            modelBuilder.Entity<CartAccommodationDetail>(entity =>
            {
                entity.ToTable("Cart_AccommodationDetails");

                entity.HasOne(d => d.Cart)
                    .WithMany(p => p.CartAccommodationDetails)
                    .HasForeignKey(d => d.CartId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Cart_Acco__CartI__6166761E");

                entity.HasOne(d => d.RoomProduct)
                    .WithMany(p => p.CartAccommodationDetails)
                    .HasForeignKey(d => d.RoomProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Cart_Acco__RoomP__625A9A57");
            });

            modelBuilder.Entity<CartActivitiesDetail>(entity =>
            {
                entity.ToTable("Cart_ActivitiesDetails");

                entity.HasOne(d => d.ActivityProduct)
                    .WithMany(p => p.CartActivitiesDetails)
                    .HasForeignKey(d => d.ActivityProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Cart_Acti__Activ__5E8A0973");

                entity.HasOne(d => d.Cart)
                    .WithMany(p => p.CartActivitiesDetails)
                    .HasForeignKey(d => d.CartId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Cart_Acti__CartI__5D95E53A");
            });

            modelBuilder.Entity<CartExtraServicesDetail>(entity =>
            {
                entity.ToTable("Cart_ExtraServicesDetails");

                entity.HasOne(d => d.Cart)
                    .WithMany(p => p.CartExtraServicesDetails)
                    .HasForeignKey(d => d.CartId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Cart_Extr__CartI__59C55456");

                entity.HasOne(d => d.ExtraServiceProduct)
                    .WithMany(p => p.CartExtraServicesDetails)
                    .HasForeignKey(d => d.ExtraServiceProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Cart_Extr__Extra__5AB9788F");
            });

            modelBuilder.Entity<CommentAccommodationLike>(entity =>
            {
                entity.ToTable("Comment_Accommodation_Likes");

                entity.Property(e => e.CommentsAccommodationId).HasColumnName("Comments_AccommodationId");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.CommentsAccommodation)
                    .WithMany(p => p.CommentAccommodationLikes)
                    .HasForeignKey(d => d.CommentsAccommodationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Comment_A__Comme__778AC167");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.CommentAccommodationLikes)
                    .HasForeignKey(d => d.MemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Comment_A__Membe__76969D2E");
            });

            modelBuilder.Entity<CommentsAccommodation>(entity =>
            {
                entity.ToTable("Comments_Accommodations");

                entity.Property(e => e.Cons).HasMaxLength(2000);

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Pros).HasMaxLength(2000);

                entity.Property(e => e.Reply).HasMaxLength(2000);

                entity.Property(e => e.ReplyAt).HasColumnType("datetime");

                entity.Property(e => e.Title).HasMaxLength(50);

                entity.HasOne(d => d.Accommodation)
                    .WithMany(p => p.CommentsAccommodations)
                    .HasForeignKey(d => d.AccommodationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Comments___Accom__70DDC3D8");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.CommentsAccommodations)
                    .HasForeignKey(d => d.MemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Comments___Membe__6FE99F9F");
            });

            modelBuilder.Entity<CommentsAccommodationImage>(entity =>
            {
                entity.ToTable("Comments_AccommodationImages");

                entity.Property(e => e.CommentsAccommodationId).HasColumnName("Comments_AccommodationId");

                entity.Property(e => e.Image).HasMaxLength(200);
            });

            modelBuilder.Entity<CommentsAttraction>(entity =>
            {
                entity.ToTable("Comments_Attractions");

                entity.Property(e => e.Content).HasMaxLength(2000);

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Attraction)
                    .WithMany(p => p.CommentsAttractions)
                    .HasForeignKey(d => d.AttractionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Comments___Attra__0F624AF8");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.CommentsAttractions)
                    .HasForeignKey(d => d.MemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Comments___Membe__0E6E26BF");
            });

            modelBuilder.Entity<CommentsAttractionImage>(entity =>
            {
                entity.ToTable("Comments_AttractionImages");

                entity.Property(e => e.CommentsAttractionId).HasColumnName("Comments_AttractionId");

                entity.Property(e => e.Image).HasMaxLength(200);
            });

            modelBuilder.Entity<Coupon>(entity =>
            {
                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.StartDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<ExtraService>(entity =>
            {
                entity.Property(e => e.Description).HasMaxLength(2000);

                entity.Property(e => e.Image).HasMaxLength(200);

                entity.Property(e => e.Name).HasMaxLength(30);

                entity.HasOne(d => d.Attraction)
                    .WithMany(p => p.ExtraServices)
                    .HasForeignKey(d => d.AttractionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ExtraServ__Image__2A164134");
            });

            modelBuilder.Entity<ExtraServiceImage>(entity =>
            {
                entity.Property(e => e.Image).HasMaxLength(200);

                entity.HasOne(d => d.ExtraService)
                    .WithMany(p => p.ExtraServiceImages)
                    .HasForeignKey(d => d.ExtraServiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ExtraServ__Extra__2FCF1A8A");
            });

            modelBuilder.Entity<ExtraServiceProduct>(entity =>
            {
                entity.Property(e => e.Date).HasColumnType("date");

                entity.HasOne(d => d.ExtraService)
                    .WithMany(p => p.ExtraServiceProducts)
                    .HasForeignKey(d => d.ExtraServiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ExtraServ__Quant__2CF2ADDF");
            });

            modelBuilder.Entity<Faq>(entity =>
            {
                entity.ToTable("FAQs");

                entity.Property(e => e.Answer).HasMaxLength(30);

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Image).HasMaxLength(200);

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Question).HasMaxLength(30);
            });

            modelBuilder.Entity<Faqcategory>(entity =>
            {
                entity.ToTable("FAQCategories");

                entity.Property(e => e.Name).HasMaxLength(30);
            });

            modelBuilder.Entity<Member>(entity =>
            {
                entity.Property(e => e.Account).HasMaxLength(30);

                entity.Property(e => e.Address).HasMaxLength(255);

                entity.Property(e => e.Birthday).HasColumnType("datetime");

                entity.Property(e => e.CellPhoneNumber).HasMaxLength(10);

                entity.Property(e => e.ConfirmCode).HasMaxLength(300);

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email).HasMaxLength(255);

                entity.Property(e => e.EncryptedPassword).HasMaxLength(255);

                entity.Property(e => e.FaceBookAccessCode).HasMaxLength(300);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.GoogleAccessCode).HasMaxLength(300);

                entity.Property(e => e.Image).HasMaxLength(200);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.LineAccessCode).HasMaxLength(300);

                entity.Property(e => e.LoginTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<MemberImage>(entity =>
            {
                entity.Property(e => e.Image).HasMaxLength(200);

                entity.Property(e => e.Name).HasMaxLength(30);

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.MemberImages)
                    .HasForeignKey(d => d.MemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__MemberIma__Membe__403A8C7D");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Coupons)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CouponsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Orders__CouponsI__72910220");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.MemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Orders__MemberId__6DCC4D03");

                entity.HasOne(d => d.OrderHandleStatus)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.OrderHandleStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Orders__OrderHan__719CDDE7");

                entity.HasOne(d => d.PaymentMethod)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.PaymentMethodId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Orders__PaymentM__6FB49575");

                entity.HasOne(d => d.PaymentStatus)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.PaymentStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Orders__PaymentS__70A8B9AE");

                entity.HasOne(d => d.TravelPlan)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.TravelPlanId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Orders__TravelPl__6EC0713C");
            });

            modelBuilder.Entity<OrderAccommodationDetail>(entity =>
            {
                entity.Property(e => e.AccommodationName).HasMaxLength(50);

                entity.Property(e => e.CheckIn).HasColumnType("datetime");

                entity.Property(e => e.CheckOut).HasColumnType("datetime");

                entity.Property(e => e.RoomName).HasMaxLength(50);

                entity.Property(e => e.RoomType).HasMaxLength(50);

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderAccommodationDetails)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OrderAcco__Quant__756D6ECB");
            });

            modelBuilder.Entity<OrderActivitiesDetail>(entity =>
            {
                entity.Property(e => e.ActivityName).HasMaxLength(100);

                entity.Property(e => e.Date).HasColumnType("date");

                entity.HasOne(d => d.ActivityProduct)
                    .WithMany(p => p.OrderActivitiesDetails)
                    .HasForeignKey(d => d.ActivityProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OrderActi__Activ__793DFFAF");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderActivitiesDetails)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OrderActi__Quant__7849DB76");
            });

            modelBuilder.Entity<OrderExtraServicesDetail>(entity =>
            {
                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.ExtraServiceName).HasMaxLength(100);

                entity.HasOne(d => d.ExtraServiceProduct)
                    .WithMany(p => p.OrderExtraServicesDetails)
                    .HasForeignKey(d => d.ExtraServiceProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OrderExtr__Extra__7D0E9093");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderExtraServicesDetails)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OrderExtr__Quant__7C1A6C5A");
            });

            modelBuilder.Entity<OrderHandleStatus>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(30);
            });

            modelBuilder.Entity<PackageCoupon>(entity =>
            {
                entity.ToTable("PackageCoupon");
            });

            modelBuilder.Entity<PackageTour>(entity =>
            {
                entity.Property(e => e.Description).HasMaxLength(2000);

                entity.HasMany(d => d.Activities)
                    .WithMany(p => p.PackageTours)
                    .UsingEntity<Dictionary<string, object>>(
                        "PackageActivity",
                        l => l.HasOne<Activity>().WithMany().HasForeignKey("ActivityId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__PackageAc__Activ__3B40CD36"),
                        r => r.HasOne<PackageTour>().WithMany().HasForeignKey("PackageTourId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__PackageAc__Activ__3A4CA8FD"),
                        j =>
                        {
                            j.HasKey("PackageTourId", "ActivityId").HasName("PK__PackageA__95FB0D54C1821298");

                            j.ToTable("PackageActivities");
                        });

                entity.HasMany(d => d.Attractions)
                    .WithMany(p => p.PackageTours)
                    .UsingEntity<Dictionary<string, object>>(
                        "PackageAttraction",
                        l => l.HasOne<Attraction>().WithMany().HasForeignKey("AttractionId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__PackageAt__Attra__3F115E1A"),
                        r => r.HasOne<PackageTour>().WithMany().HasForeignKey("PackageTourId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__PackageAt__Attra__3E1D39E1"),
                        j =>
                        {
                            j.HasKey("PackageTourId", "AttractionId").HasName("PK__PackageA__2C0A63F871B72891");

                            j.ToTable("PackageAttractions");
                        });

                entity.HasMany(d => d.ExtraServices)
                    .WithMany(p => p.PackageTours)
                    .UsingEntity<Dictionary<string, object>>(
                        "PackageExtraService",
                        l => l.HasOne<ExtraService>().WithMany().HasForeignKey("ExtraServiceId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__PackageEx__Extra__37703C52"),
                        r => r.HasOne<PackageTour>().WithMany().HasForeignKey("PackageTourId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__PackageEx__Extra__367C1819"),
                        j =>
                        {
                            j.HasKey("PackageTourId", "ExtraServiceId").HasName("PK__PackageE__0943AA62C4DCF458");

                            j.ToTable("PackageExtraServices");
                        });
            });

            modelBuilder.Entity<Partner>(entity =>
            {
                entity.Property(e => e.ConfirmCode).HasMaxLength(300);

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email).HasMaxLength(255);

                entity.Property(e => e.EncryptedPassword).HasMaxLength(255);

                entity.Property(e => e.FaceBookAccessCode).HasMaxLength(300);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.GoogleAccessCode).HasMaxLength(300);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.LineAccessCode).HasMaxLength(300);
            });

            modelBuilder.Entity<PaymentMethod>(entity =>
            {
                entity.Property(e => e.Description).HasMaxLength(2000);

                entity.Property(e => e.Name).HasMaxLength(30);
            });

            modelBuilder.Entity<PaymentStatus>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(30);
            });

            modelBuilder.Entity<Permission>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(30);
            });

            modelBuilder.Entity<Region>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(30);
            });

            modelBuilder.Entity<ReportReason>(entity =>
            {
                entity.Property(e => e.Reason).HasMaxLength(50);
            });

            modelBuilder.Entity<ReportedAttractionComment>(entity =>
            {
                entity.HasOne(d => d.CommentAttraction)
                    .WithMany(p => p.ReportedAttractionComments)
                    .HasForeignKey(d => d.CommentAttractionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ReportedA__Comme__160F4887");
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.Property(e => e.Description).HasMaxLength(2000);

                entity.Property(e => e.Name).HasMaxLength(30);

                entity.HasOne(d => d.Accommodation)
                    .WithMany(p => p.Rooms)
                    .HasForeignKey(d => d.AccommodationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Rooms__Accommoda__59FA5E80");

                entity.HasOne(d => d.RoomType)
                    .WithMany(p => p.Rooms)
                    .HasForeignKey(d => d.RoomTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Rooms__RoomTypeI__5AEE82B9");

                entity.HasMany(d => d.RoomServiceInfos)
                    .WithMany(p => p.Rooms)
                    .UsingEntity<Dictionary<string, object>>(
                        "RoomServiceInfosRoom",
                        l => l.HasOne<RoomServiceInfo>().WithMany().HasForeignKey("RoomServiceInfoId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__RoomServi__RoomS__693CA210"),
                        r => r.HasOne<Room>().WithMany().HasForeignKey("RoomId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__RoomServi__RoomS__68487DD7"),
                        j =>
                        {
                            j.HasKey("RoomId", "RoomServiceInfoId").HasName("PK__RoomServ__B47A761300FBF6DB");

                            j.ToTable("RoomServiceInfos_Rooms");
                        });
            });

            modelBuilder.Entity<RoomImage>(entity =>
            {
                entity.Property(e => e.Image).HasMaxLength(200);

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.RoomImages)
                    .HasForeignKey(d => d.RoomId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__RoomImage__Image__5DCAEF64");
            });

            modelBuilder.Entity<RoomProduct>(entity =>
            {
                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.NewPrice).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.RoomProducts)
                    .HasForeignKey(d => d.RoomId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__RoomProdu__RoomI__6C190EBB");
            });

            modelBuilder.Entity<RoomServiceInfo>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(30);
            });

            modelBuilder.Entity<RoomType>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(30);
            });

            modelBuilder.Entity<Schedule>(entity =>
            {
                entity.Property(e => e.Content).HasMaxLength(2000);

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.EndTime).HasColumnType("datetime");

                entity.Property(e => e.StartTime).HasColumnType("datetime");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.Schedules)
                    .HasForeignKey(d => d.MemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Schedules__Membe__5224328E");
            });

            modelBuilder.Entity<ServiceInfo>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(30);
            });

            modelBuilder.Entity<SystemImage>(entity =>
            {
                entity.Property(e => e.Image).HasMaxLength(200);
            });

            modelBuilder.Entity<Town>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(30);

                entity.HasOne(d => d.Region)
                    .WithMany(p => p.Towns)
                    .HasForeignKey(d => d.RegionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Towns__Name__49C3F6B7");
            });

            modelBuilder.Entity<Transportation>(entity =>
            {
                entity.ToTable("Transportation");

                entity.Property(e => e.Arrival).HasMaxLength(200);

                entity.Property(e => e.Departure).HasMaxLength(200);

                entity.Property(e => e.Vehicle).HasMaxLength(50);
            });

            modelBuilder.Entity<TravelPlan>(entity =>
            {
                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.TravelPlans)
                    .HasForeignKey(d => d.MemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TravelPla__Membe__42E1EEFE");

                entity.HasMany(d => d.ActivityProducts)
                    .WithMany(p => p.TravelPlans)
                    .UsingEntity<Dictionary<string, object>>(
                        "PlanActivity",
                        l => l.HasOne<ActivityProduct>().WithMany().HasForeignKey("ActivityProductId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__PlanActiv__Activ__4A8310C6"),
                        r => r.HasOne<TravelPlan>().WithMany().HasForeignKey("TravelPlanId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__PlanActiv__Activ__498EEC8D"),
                        j =>
                        {
                            j.HasKey("TravelPlanId", "ActivityProductId").HasName("PK__PlanActi__EB02F9A0F26F50BF");

                            j.ToTable("PlanActivities");
                        });

                entity.HasMany(d => d.Attractions)
                    .WithMany(p => p.TravelPlans)
                    .UsingEntity<Dictionary<string, object>>(
                        "PlanAttraction",
                        l => l.HasOne<Attraction>().WithMany().HasForeignKey("AttractionId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__PlanAttra__Attra__4E53A1AA"),
                        r => r.HasOne<TravelPlan>().WithMany().HasForeignKey("TravelPlanId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__PlanAttra__Attra__4D5F7D71"),
                        j =>
                        {
                            j.HasKey("TravelPlanId", "AttractionId").HasName("PK__PlanAttr__99DDD1EEBACFA1CB");

                            j.ToTable("PlanAttractions");
                        });

                entity.HasMany(d => d.ExtraServiceProducts)
                    .WithMany(p => p.TravelPlans)
                    .UsingEntity<Dictionary<string, object>>(
                        "PlanExtraService",
                        l => l.HasOne<ExtraServiceProduct>().WithMany().HasForeignKey("ExtraServiceProductId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__PlanExtra__Extra__46B27FE2"),
                        r => r.HasOne<TravelPlan>().WithMany().HasForeignKey("TravelPlanId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__PlanExtra__Extra__45BE5BA9"),
                        j =>
                        {
                            j.HasKey("TravelPlanId", "ExtraServiceProductId").HasName("PK__PlanExtr__4FFE2B654150F67B");

                            j.ToTable("PlanExtraServices");
                        });
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        public DbSet<RouteMasterUpOne.Models.ViewModels.CommentsAccommodationsIndexVM>? CommentsAccommodationsIndexVM { get; set; }

        public DbSet<RouteMasterUpOne.Models.ViewModels.CommentsAccommodationsEditVM>? CommentsAccommodationsEditVM { get; set; }
    }
}
