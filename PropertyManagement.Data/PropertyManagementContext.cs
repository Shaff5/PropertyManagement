using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PropertyManagement.Data
{
    public partial class PropertyManagementContext : DbContext
    {
        public PropertyManagementContext()
        {
        }

        public PropertyManagementContext(DbContextOptions<PropertyManagementContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Building> Buildings { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<HistoryDetail> HistoryDetail { get; set; }
        public virtual DbSet<HistoryHeader> HistoryHeader { get; set; }
        public virtual DbSet<PhoneType> PhoneTypes { get; set; }
        public virtual DbSet<RentPayment> RentPayments { get; set; }
        public virtual DbSet<Rent> Rents { get; set; }
        public virtual DbSet<Unit> Units { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Vendor> Vendors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("data source=(local);initial catalog=PropertyManagement;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.3-servicing-35854");

            modelBuilder.Entity<Building>(entity =>
            {
                entity.HasKey(e => e.BuildingId);

                entity.Property(e => e.AddressLine1)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AddressLine2)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AddressLine3)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BuildingName)
                    .IsRequired()
                    .HasMaxLength(75)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");

                entity.Property(e => e.NumberOfUnits).HasColumnType("decimal(6, 1)");

                entity.Property(e => e.PurchaseDate).HasColumnType("datetime");

                entity.Property(e => e.PurchasePrice).HasColumnType("decimal(11, 2)");

                entity.Property(e => e.SellDate).HasColumnType("datetime");

                entity.Property(e => e.SellPrice).HasColumnType("decimal(11, 2)");

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.Ts)
                    .IsRequired()
                    .IsRowVersion();

                entity.Property(e => e.ZipCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.BuildingsCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BuildingsCreatedBy_Users");

                entity.HasOne(d => d.LastUpdatedByNavigation)
                    .WithMany(p => p.BuildingsLastUpdatedByNavigation)
                    .HasForeignKey(d => d.LastUpdatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BuildingsLastUpdatedBy_Users");
            });

            modelBuilder.Entity<Contact>(entity =>
            {
                entity.HasKey(e => e.ContactId);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Email1)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email2)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email3)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");

                entity.Property(e => e.MiddleName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Phone1)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Phone2)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Phone3)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Ts)
                    .IsRequired()
                    .IsRowVersion();
            });

            modelBuilder.Entity<HistoryDetail>(entity =>
            {
                entity.Property(e => e.ColumnName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NewValue).IsUnicode(false);

                entity.Property(e => e.OldValue).IsUnicode(false);

                entity.HasOne(d => d.HistoryHeader)
                    .WithMany(p => p.HistoryDetail)
                    .HasForeignKey(d => d.HistoryHeaderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HistoryDetail_HistoryHeader");
            });

            modelBuilder.Entity<HistoryHeader>(entity =>
            {
                entity.Property(e => e.Action)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.TableName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PhoneType>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RentPayment>(entity =>
            {
                entity.HasKey(e => e.RentPaymentId);

                entity.Property(e => e.Amount).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.Ts)
                    .IsRequired()
                    .IsRowVersion();

                entity.HasOne(d => d.Unit)
                    .WithMany(p => p.RentPayments)
                    .HasForeignKey(d => d.UnitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RentPayments_Units");
            });

            modelBuilder.Entity<Rent>(entity =>
            {
                entity.HasKey(e => e.RentId);

                entity.Property(e => e.Amount).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.Ts)
                    .IsRequired()
                    .IsRowVersion();

                entity.HasOne(d => d.Unit)
                    .WithMany(p => p.Rents)
                    .HasForeignKey(d => d.UnitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Rents_Units");
            });

            modelBuilder.Entity<Unit>(entity =>
            {
                entity.HasKey(e => e.UnitId);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");

                entity.Property(e => e.NumberOfBathrooms).HasColumnType("decimal(3, 1)");

                entity.Property(e => e.NumberOfBedrooms).HasColumnType("decimal(3, 1)");

                entity.Property(e => e.SquareFootage).HasColumnType("decimal(6, 1)");

                entity.Property(e => e.Ts)
                    .IsRequired()
                    .IsRowVersion();

                entity.Property(e => e.UnitName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Building)
                    .WithMany(p => p.Units)
                    .HasForeignKey(d => d.BuildingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Units_Buildings");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");

                entity.Property(e => e.Ts)
                    .IsRequired()
                    .IsRowVersion();

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Vendor>(entity =>
            {
                entity.HasKey(e => e.VendorId);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");

                entity.Property(e => e.Ts)
                    .IsRequired()
                    .IsRowVersion();

                entity.Property(e => e.VendorName)
                    .IsRequired()
                    .HasMaxLength(75)
                    .IsUnicode(false);
            });
        }
    }
}
