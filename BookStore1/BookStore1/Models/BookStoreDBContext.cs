using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BookStore1.Models
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

        public virtual DbSet<AuthorTable> AuthorTable { get; set; }
        public virtual DbSet<BookTable> BookTable { get; set; }
        public virtual DbSet<CategoryTable> CategoryTable { get; set; }
        public virtual DbSet<CouponTable> CouponTable { get; set; }
        public virtual DbSet<LogTable> LogTable { get; set; }
        public virtual DbSet<LoginCredentials> LoginCredentials { get; set; }
        public virtual DbSet<OrderDetailsTable> OrderDetailsTable { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<UserAddressesTable> UserAddressesTable { get; set; }
        public virtual DbSet<UserTable> UserTable { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=IND431;Database=BookStoreDB;Trusted_Connection=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AuthorTable>(entity =>
            {
                entity.HasKey(e => e.AId)
                    .HasName("PK__AuthorTa__DE518A06BF12AB5B");

                entity.Property(e => e.AId)
                    .HasColumnName("aId")
                    .ValueGeneratedNever();

                entity.Property(e => e.ACountry)
                    .IsRequired()
                    .HasColumnName("aCountry")
                    .HasMaxLength(50);

                entity.Property(e => e.AFname)
                    .IsRequired()
                    .HasColumnName("aFName")
                    .HasMaxLength(50);

                entity.Property(e => e.ASname)
                    .HasColumnName("aSName")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<BookTable>(entity =>
            {
                entity.HasKey(e => e.BId)
                    .HasName("PK__BookTabl__DE9988FF445B49E5");

                entity.HasIndex(e => e.BName)
                    .HasName("UQ__BookTabl__07B7904E14A406ED")
                    .IsUnique();

                entity.Property(e => e.BId)
                    .HasColumnName("bId")
                    .ValueGeneratedNever();

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
                    .WithMany(p => p.BookTable)
                    .HasForeignKey(d => d.AId)
                    .HasConstraintName("FK__BookTable__aId__4D94879B");

                entity.HasOne(d => d.C)
                    .WithMany(p => p.BookTable)
                    .HasForeignKey(d => d.CId)
                    .HasConstraintName("FK__BookTable__cId__4CA06362");
            });

            modelBuilder.Entity<CategoryTable>(entity =>
            {
                entity.HasKey(e => e.CId)
                    .HasName("PK__Category__D830D4772487FFE8");

                entity.HasIndex(e => e.CName)
                    .HasName("UQ__Category__829A49F6D2089CA7")
                    .IsUnique();

                entity.Property(e => e.CId)
                    .HasColumnName("cId")
                    .ValueGeneratedNever();

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

            modelBuilder.Entity<CouponTable>(entity =>
            {
                entity.HasKey(e => e.CoId)
                    .HasName("PK__CouponTa__35724175F8F29504");

                entity.HasIndex(e => e.CoName)
                    .HasName("UQ__CouponTa__6AA48E4E44FA91AA")
                    .IsUnique();

                entity.Property(e => e.CoId)
                    .HasColumnName("coId")
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

            modelBuilder.Entity<LogTable>(entity =>
            {
                entity.HasKey(e => e.LId)
                    .HasName("PK__LogTable__DE11596F570090F4");

                entity.Property(e => e.LId)
                    .HasColumnName("lId")
                    .ValueGeneratedNever();

                entity.Property(e => e.LDateAndTime)
                    .HasColumnName("lDateAndTime")
                    .HasColumnType("date");

                entity.Property(e => e.LUserType)
                    .HasColumnName("lUserType")
                    .HasMaxLength(10);

                entity.Property(e => e.UId).HasColumnName("uId");

                entity.HasOne(d => d.U)
                    .WithMany(p => p.LogTable)
                    .HasForeignKey(d => d.UId)
                    .HasConstraintName("FK__LogTable__uId__5AEE82B9");
            });

            modelBuilder.Entity<LoginCredentials>(entity =>
            {
                entity.HasNoKey();

                entity.HasIndex(e => e.UserName)
                    .HasName("UQ__LoginCre__66DCF95C55DD0CCC")
                    .IsUnique();

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasColumnName("userName")
                    .HasMaxLength(50);

                entity.Property(e => e.UserPassword)
                    .IsRequired()
                    .HasColumnName("userPassword")
                    .HasMaxLength(50);

                entity.Property(e => e.UserRole)
                    .IsRequired()
                    .HasColumnName("userRole")
                    .HasMaxLength(10);

                entity.HasOne(d => d.User)
                    .WithMany()
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__LoginCred__userI__3F466844");
            });

            modelBuilder.Entity<OrderDetailsTable>(entity =>
            {
                entity.HasKey(e => e.OId)
                    .HasName("PK__OrderDet__C2FECB3B742144AF");

                entity.Property(e => e.OId)
                    .HasColumnName("oId")
                    .ValueGeneratedNever();

                entity.Property(e => e.BId).HasColumnName("bId");

                entity.Property(e => e.OBillingAddress)
                    .IsRequired()
                    .HasColumnName("oBillingAddress")
                    .HasMaxLength(250);

                entity.Property(e => e.OIsbn)
                    .IsRequired()
                    .HasColumnName("oISBN")
                    .HasMaxLength(17)
                    .IsUnicode(false);

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
                    .WithMany(p => p.OrderDetailsTable)
                    .HasForeignKey(d => d.BId)
                    .HasConstraintName("FK__OrderDetail__bId__52593CB8");

                entity.HasOne(d => d.U)
                    .WithMany(p => p.OrderDetailsTable)
                    .HasForeignKey(d => d.UId)
                    .HasConstraintName("FK__OrderDetail__uId__5165187F");
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.OrCouponId)
                    .HasColumnName("orCouponId")
                    .HasMaxLength(10);

                entity.Property(e => e.OrDateAndTime)
                    .HasColumnName("orDateAndTime")
                    .HasColumnType("date");

                entity.Property(e => e.OrId).HasColumnName("orId");

                entity.Property(e => e.UId).HasColumnName("uId");

                entity.HasOne(d => d.OrCoupon)
                    .WithMany()
                    .HasForeignKey(d => d.OrCouponId)
                    .HasConstraintName("FK__Orders__orCoupon__5812160E");

                entity.HasOne(d => d.Or)
                    .WithMany()
                    .HasForeignKey(d => d.OrId)
                    .HasConstraintName("FK__Orders__orId__571DF1D5");
            });

            modelBuilder.Entity<UserAddressesTable>(entity =>
            {
                entity.HasNoKey();

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
                    .HasMaxLength(50);

                entity.Property(e => e.UPincode)
                    .IsRequired()
                    .HasColumnName("uPincode")
                    .HasMaxLength(50);

                entity.Property(e => e.UState)
                    .IsRequired()
                    .HasColumnName("uState")
                    .HasMaxLength(50);

                entity.HasOne(d => d.U)
                    .WithMany()
                    .HasForeignKey(d => d.UId)
                    .HasConstraintName("FK__UserAddress__uId__4222D4EF");
            });

            modelBuilder.Entity<UserTable>(entity =>
            {
                entity.HasKey(e => e.UId)
                    .HasName("PK__UserTabl__DD771E5CEA9DF61B");

                entity.HasIndex(e => e.UMailId)
                    .HasName("UQ__UserTabl__2AD8EB148BDA7EFC")
                    .IsUnique();

                entity.HasIndex(e => e.UPhone)
                    .HasName("UQ__UserTabl__08A8972914ACF5EE")
                    .IsUnique();

                entity.Property(e => e.UId)
                    .HasColumnName("uId")
                    .ValueGeneratedNever();

                entity.Property(e => e.UAccountStatus)
                    .IsRequired()
                    .HasColumnName("uAccountStatus")
                    .HasMaxLength(10);

                entity.Property(e => e.UFname)
                    .IsRequired()
                    .HasColumnName("uFName")
                    .HasMaxLength(50);

                entity.Property(e => e.UMailId)
                    .IsRequired()
                    .HasColumnName("uMailId")
                    .HasMaxLength(50);

                entity.Property(e => e.UPhone)
                    .IsRequired()
                    .HasColumnName("uPhone")
                    .HasMaxLength(10);

                entity.Property(e => e.URole)
                    .IsRequired()
                    .HasColumnName("uRole")
                    .HasMaxLength(10);

                entity.Property(e => e.USname)
                    .IsRequired()
                    .HasColumnName("uSName")
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
