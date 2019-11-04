using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BookClassSimple.Models
{
    public partial class bookclassContext : IdentityDbContext
    {
        public bookclassContext()
        {
        }

        public bookclassContext(DbContextOptions<bookclassContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categorys> Categorys { get; set; }
        public virtual DbSet<CourseDate> CourseDate { get; set; }
        public virtual DbSet<Courses> Courses { get; set; }
        public virtual DbSet<CourseTime> CourseTime { get; set; }
        public virtual DbSet<Images> Images { get; set; }
        public virtual DbSet<Location> Location { get; set; }
        public virtual DbSet<Providers> Providers { get; set; }
        public virtual DbSet<UserComments> UserComments { get; set; }
        public virtual DbSet<UserRegister> UserRegister { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Categorys>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreateDate)
                    .HasColumnName("createDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Icon)
                    .IsRequired()
                    .HasColumnName("icon")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.LastModifty)
                    .HasColumnName("lastModifty")
                    .HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(10);

                entity.Property(e => e.RecordTs)
                    .IsRequired()
                    .HasColumnName("recordTS")
                    .IsRowVersion();
            });

            modelBuilder.Entity<CourseDate>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CourseId).HasColumnName("courseId");

                entity.Property(e => e.CreateDate)
                    .HasColumnName("createDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("datetime");

                entity.Property(e => e.LastModifty)
                    .HasColumnName("lastModifty")
                    .HasColumnType("date");

                entity.Property(e => e.RecordTs)
                    .IsRequired()
                    .HasColumnName("recordTS")
                    .IsRowVersion();

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.CourseDate)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CourseDat__cours__3C69FB99");
            });

            modelBuilder.Entity<Courses>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CategoryId).HasColumnName("categoryId");

                entity.Property(e => e.CreateDate)
                    .HasColumnName("createDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(2000);

                entity.Property(e => e.Price)
                   .IsRequired()
                   .HasColumnName("price")
                   .HasColumnType("decimal(7, 2)");

                entity.Property(e => e.ImageId).HasColumnName("imageId");

                entity.Property(e => e.LastModifty)
                    .HasColumnName("lastModifty")
                    .HasColumnType("datetime");

                entity.Property(e => e.LocationId).HasColumnName("locationId");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(255);

                entity.Property(e => e.RecordTs)
                    .IsRequired()
                    .HasColumnName("recordTS")
                    .IsRowVersion();

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Courses__categor__36B12243");

                entity.HasOne(d => d.Image)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.ImageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Courses__imageId__37A5467C");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Courses__locatio__38996AB5");
            });

            modelBuilder.Entity<CourseTime>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CourseDateId).HasColumnName("courseDateId");

                entity.Property(e => e.CreateDate)
                    .HasColumnName("createDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.LastModifty)
                    .HasColumnName("lastModifty")
                    .HasColumnType("datetime");

                entity.Property(e => e.RecordTs)
                    .IsRequired()
                    .HasColumnName("recordTS")
                    .IsRowVersion();

                entity.Property(e => e.Time).HasColumnName("time");

                entity.HasOne(d => d.CourseDate)
                    .WithMany(p => p.CourseTime)
                    .HasForeignKey(d => d.CourseDateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CourseTim__cours__403A8C7D");
            });

            modelBuilder.Entity<Images>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreateDate)
                    .HasColumnName("createDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.LastModifty)
                    .HasColumnName("lastModifty")
                    .HasColumnType("datetime");

                entity.Property(e => e.Path)
                    .IsRequired()
                    .HasColumnName("path")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.RecordTs)
                    .IsRequired()
                    .HasColumnName("recordTS")
                    .IsRowVersion();
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnName("address")
                    .HasMaxLength(1000);

                entity.Property(e => e.CreateDate)
                    .HasColumnName("createDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.LastModifty)
                    .HasColumnName("lastModifty")
                    .HasColumnType("datetime");

                entity.Property(e => e.Lat)
                    .HasColumnName("lat")
                    .HasColumnType("decimal(9, 6)");

                entity.Property(e => e.Lng)
                    .HasColumnName("lng")
                    .HasColumnType("decimal(9, 6)");

                entity.Property(e => e.RecordTs)
                    .IsRequired()
                    .HasColumnName("recordTS")
                    .IsRowVersion();
            });

            modelBuilder.Entity<Providers>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreateDate)
                    .HasColumnName("createDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(2000);

                entity.Property(e => e.LastModifty)
                    .HasColumnName("lastModifty")
                    .HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(255);

                entity.Property(e => e.RecordTs)
                    .IsRequired()
                    .HasColumnName("recordTS")
                    .IsRowVersion();
            });

            modelBuilder.Entity<UserComments>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Comment)
                    .IsRequired()
                    .HasColumnName("comment")
                    .HasMaxLength(2000);

                entity.Property(e => e.CreateDate)
                    .HasColumnName("createDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.LastModifty)
                    .HasColumnName("lastModifty")
                    .HasColumnType("datetime");

                entity.Property(e => e.RecordTs)
                    .IsRequired()
                    .HasColumnName("recordTS")
                    .IsRowVersion();

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.Property(e => e.UserRateing).HasColumnName("userRateing");

                entity.Property(e => e.CourseId).HasColumnName("courseId");

                entity.HasOne(d => d.Courses)
                .WithMany(p => p.UserComments)
                .HasForeignKey(d => d.CourseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__UserComme__cours__14270015");
            });

            modelBuilder.Entity<UserRegister>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CourseTimeId).HasColumnName("courseTimeId");

                entity.Property(e => e.CreateDate)
                    .HasColumnName("createDate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.LastModifty)
                    .HasColumnName("lastModifty")
                    .HasColumnType("datetime");

                entity.Property(e => e.RecordTs)
                    .IsRequired()
                    .HasColumnName("recordTS")
                    .IsRowVersion();

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.HasOne(d => d.CourseTime)
                    .WithMany(p => p.UserRegister)
                    .HasForeignKey(d => d.CourseTimeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UserRegis__cours__71D1E811");

            });
        }
    }
}
