using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BookStoreAPIv1.Models
{
    public partial class BookStoreDBContext : DbContext
    {
        public BookStoreDBContext()
        {
        }

        public BookStoreDBContext(DbContextOptions<BookStoreDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Authors> Authors { get; set; }
        public virtual DbSet<Books> Books { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Coupons> Coupons { get; set; }
        public virtual DbSet<LoginCredentials> LoginCredentials { get; set; }
        public virtual DbSet<Logs> Logs { get; set; }
        public virtual DbSet<OrderDetails> OrderDetails { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<UserAddresses> UserAddresses { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=IND365;Database=BookStoreDB;Trusted_Connection=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Authors>(entity =>
            {
                entity.HasKey(e => e.AId)
                    .HasName("PK__Authors__DE518A06BAD9CE7F");

                entity.Property(e => e.AId).HasColumnName("aId");

                entity.Property(e => e.ACountry)
                    .IsRequired()
                    .HasColumnName("aCountry")
                    .HasMaxLength(50);

                entity.Property(e => e.AFname)
                    .IsRequired()
                    .HasColumnName("aFName")
                    .HasMaxLength(50);

                entity.Property(e => e.ALname)
                    .HasColumnName("aLName")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Books>(entity =>
            {
                entity.HasKey(e => e.BId)
                    .HasName("PK__Books__DE9988FF8D5D359D");

                entity.HasIndex(e => e.BName)
                    .HasName("UQ__Books__07B7904E3C824046")
                    .IsUnique();

                entity.Property(e => e.BId).HasColumnName("bId");

                entity.Property(e => e.AId).HasColumnName("aId");

                entity.Property(e => e.BDescription)
                    .IsRequired()
                    .HasColumnName("bDescription")
                    .HasMaxLength(300);

                entity.Property(e => e.BImage)
                    .IsRequired()
                    .HasColumnName("bImage")
                    .HasMaxLength(50);

                entity.Property(e => e.BIsbn)
                    .IsRequired()
                    .HasColumnName("bISBN")
                    .HasMaxLength(17)
                    .IsUnicode(false);

                entity.Property(e => e.BName)
                    .IsRequired()
                    .HasColumnName("bName")
                    .HasMaxLength(50);

                entity.Property(e => e.BPosition).HasColumnName("bPosition");

                entity.Property(e => e.BPrice).HasColumnName("bPrice");

                entity.Property(e => e.BQuantity).HasColumnName("bQuantity");

                entity.Property(e => e.BStatus)
                    .IsRequired()
                    .HasColumnName("bStatus")
                    .HasMaxLength(10);

                entity.Property(e => e.CId).HasColumnName("cId");

                entity.HasOne(d => d.A)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.AId)
                    .HasConstraintName("FK__Books__aId__282DF8C2");

                entity.HasOne(d => d.C)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.CId)
                    .HasConstraintName("FK__Books__cId__2739D489");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.CId)
                    .HasName("PK__Category__D830D4774C48E60E");

                entity.HasIndex(e => e.CName)
                    .HasName("UQ__Category__829A49F6D8E779B5")
                    .IsUnique();

                entity.Property(e => e.CId).HasColumnName("cId");

                entity.Property(e => e.CCreatedAt)
                    .HasColumnName("cCreatedAt")
                    .HasColumnType("date");

                entity.Property(e => e.CDescription)
                    .IsRequired()
                    .HasColumnName("cDescription")
                    .HasMaxLength(300);

                entity.Property(e => e.CImage)
                    .IsRequired()
                    .HasColumnName("cImage")
                    .HasMaxLength(50);

                entity.Property(e => e.CName)
                    .IsRequired()
                    .HasColumnName("cName")
                    .HasMaxLength(50);

                entity.Property(e => e.CPosition).HasColumnName("cPosition");

                entity.Property(e => e.CStatus)
                    .IsRequired()
                    .HasColumnName("cStatus")
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<Coupons>(entity =>
            {
                entity.HasKey(e => e.CoId)
                    .HasName("PK__Coupons__3572417542C0BD9B");

                entity.HasIndex(e => e.CoName)
                    .HasName("UQ__Coupons__6AA48E4EA0442373")
                    .IsUnique();

                entity.Property(e => e.CoId)
                    .HasColumnName("coId")
                    .ValueGeneratedNever();

                entity.Property(e => e.CoCode)
                    .IsRequired()
                    .HasColumnName("coCode")
                    .HasMaxLength(10);

                entity.Property(e => e.CoDiscount).HasColumnName("coDiscount");

                entity.Property(e => e.CoExpiryDate)
                    .HasColumnName("coExpiryDate")
                    .HasColumnType("date");

                entity.Property(e => e.CoName)
                    .IsRequired()
                    .HasColumnName("coName")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<LoginCredentials>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("LoginCredentials");

                entity.Property(e => e.UId)
                    .HasColumnName("uId")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.UMailId)
                    .IsRequired()
                    .HasColumnName("uMailId")
                    .HasMaxLength(50);

                entity.Property(e => e.UPassword)
                    .IsRequired()
                    .HasColumnName("uPassword")
                    .HasMaxLength(50);

                entity.Property(e => e.URole)
                    .IsRequired()
                    .HasColumnName("uRole")
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<Logs>(entity =>
            {
                entity.HasKey(e => e.LId)
                    .HasName("PK__Logs__DE11596F900FD258");

                entity.Property(e => e.LId).HasColumnName("lId");

                entity.Property(e => e.LDateAndTime)
                    .HasColumnName("lDateAndTime")
                    .HasColumnType("date");

                entity.Property(e => e.LLogType)
                    .HasColumnName("lLogType")
                    .HasMaxLength(20);

                entity.Property(e => e.LUserType)
                    .HasColumnName("lUserType")
                    .HasMaxLength(10);

                entity.Property(e => e.UId).HasColumnName("uId");

                entity.HasOne(d => d.U)
                    .WithMany(p => p.Logs)
                    .HasForeignKey(d => d.UId)
                    .HasConstraintName("FK__Logs__uId__37703C52");
            });

            modelBuilder.Entity<OrderDetails>(entity =>
            {
                entity.HasKey(e => e.OrdrId)
                    .HasName("PK__OrderDet__D7F9A2CEBA1B7954");

                entity.Property(e => e.OrdrId).HasColumnName("ordrId");

                entity.Property(e => e.BId).HasColumnName("bId");

                entity.Property(e => e.BIsbn)
                    .IsRequired()
                    .HasColumnName("bISBN")
                    .HasMaxLength(17)
                    .IsUnicode(false);

                entity.Property(e => e.BPrice).HasColumnName("bPrice");

                entity.Property(e => e.BQuantity).HasColumnName("bQuantity");

                entity.Property(e => e.OBillingAddress)
                    .IsRequired()
                    .HasColumnName("oBillingAddress")
                    .HasMaxLength(250);

                entity.Property(e => e.OId).HasColumnName("oId");

                entity.Property(e => e.OPaymentMode)
                    .IsRequired()
                    .HasColumnName("oPaymentMode")
                    .HasMaxLength(10);

                entity.Property(e => e.OShippingAddress)
                    .IsRequired()
                    .HasColumnName("oShippingAddress")
                    .HasMaxLength(250);

                entity.Property(e => e.OTotalPrice).HasColumnName("oTotalPrice");

                entity.Property(e => e.UId).HasColumnName("uId");

                entity.HasOne(d => d.B)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.BId)
                    .HasConstraintName("FK__OrderDetail__bId__3493CFA7");

                entity.HasOne(d => d.O)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.OId)
                    .HasConstraintName("FK__OrderDetail__oId__32AB8735");

                entity.HasOne(d => d.U)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.UId)
                    .HasConstraintName("FK__OrderDetail__uId__339FAB6E");
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.HasKey(e => e.OId)
                    .HasName("PK__Orders__C2FECB3B428D593F");

                entity.Property(e => e.OId).HasColumnName("oId");

                entity.Property(e => e.OrCouponId).HasColumnName("orCouponId");

                entity.Property(e => e.OrDateAndTime)
                    .HasColumnName("orDateAndTime")
                    .HasColumnType("date");

                entity.Property(e => e.UId).HasColumnName("uId");

                entity.HasOne(d => d.OrCoupon)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.OrCouponId)
                    .HasConstraintName("FK__Orders__orCoupon__2FCF1A8A");

                entity.HasOne(d => d.U)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.UId)
                    .HasConstraintName("FK__Orders__uId__2EDAF651");
            });

            modelBuilder.Entity<UserAddresses>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.UAddressLineOne)
                    .IsRequired()
                    .HasColumnName("uAddressLineOne")
                    .HasMaxLength(100);

                entity.Property(e => e.UAddressLineTwo)
                    .HasColumnName("uAddressLineTwo")
                    .HasMaxLength(100);

                entity.Property(e => e.UCity)
                    .IsRequired()
                    .HasColumnName("uCity")
                    .HasMaxLength(50);

                entity.Property(e => e.UCountry)
                    .IsRequired()
                    .HasColumnName("uCountry")
                    .HasMaxLength(50);

                entity.Property(e => e.UId).HasColumnName("uId");

                entity.Property(e => e.ULandMark)
                    .HasColumnName("uLandMark")
                    .HasMaxLength(100);

                entity.Property(e => e.UPincode)
                    .IsRequired()
                    .HasColumnName("uPincode")
                    .HasMaxLength(50);

                entity.Property(e => e.UState)
                    .IsRequired()
                    .HasColumnName("uState")
                    .HasMaxLength(50);

                entity.HasOne(d => d.U)
                    .WithMany(p => p.UserAddresses)
                    .HasForeignKey(d => d.UId)
                    .HasConstraintName("FK__UserAddress__uId__1CBC4616");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UId)
                    .HasName("PK__Users__DD771E5CF1120A03");

                entity.HasIndex(e => e.UMailId)
                    .HasName("UQ__Users__2AD8EB1447CA09FA")
                    .IsUnique();

                entity.HasIndex(e => e.UPhone)
                    .HasName("UQ__Users__08A89729ABC7507C")
                    .IsUnique();

                entity.Property(e => e.UId).HasColumnName("uId");

                entity.Property(e => e.UAccountStatus)
                    .IsRequired()
                    .HasColumnName("uAccountStatus")
                    .HasMaxLength(10);

                entity.Property(e => e.UFname)
                    .IsRequired()
                    .HasColumnName("uFName")
                    .HasMaxLength(50);

                entity.Property(e => e.ULname)
                    .IsRequired()
                    .HasColumnName("uLName")
                    .HasMaxLength(50);

                entity.Property(e => e.UMailId)
                    .IsRequired()
                    .HasColumnName("uMailId")
                    .HasMaxLength(50);

                entity.Property(e => e.UPassword)
                    .IsRequired()
                    .HasColumnName("uPassword")
                    .HasMaxLength(50);

                entity.Property(e => e.UPhone)
                    .IsRequired()
                    .HasColumnName("uPhone")
                    .HasMaxLength(10);

                entity.Property(e => e.URole)
                    .IsRequired()
                    .HasColumnName("uRole")
                    .HasMaxLength(10);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
