using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace TaxiOperator.BLL.DAL
{
    public partial class TaxiOperatorContext : DbContext
    {
        public TaxiOperatorContext()
        {
        }

        public TaxiOperatorContext(DbContextOptions<TaxiOperatorContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Cab> Cabs { get; set; }
        public virtual DbSet<CabDriver> CabDrivers { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Driver> Drivers { get; set; }
        public virtual DbSet<V_CabDriver> V_CabDrivers{ get; set; }
        public virtual DbSet<User> Users{ get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=ETGS-KAK\\SQL16;Database=TaxiOperator;MultipleActiveResultSets=true;Integrated Security=False;User=ES;Password=ES;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<V_CabDriver>(entity =>
            {
                entity.ToTable("V_CabDriver");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");
            });

            modelBuilder.Entity<Address>(entity =>
            {
                entity.ToTable("Address");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_Address_Customer");
            });

            modelBuilder.Entity<Cab>(entity =>
            {
                entity.ToTable("Cab");
                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<CabDriver>(entity =>
            {
                entity.ToTable("CabDriver");

                entity.HasOne(d => d.Cab)
                    .WithMany(p => p.CabDrivers)
                    .HasForeignKey(d => d.CabId)
                    .HasConstraintName("FK_CabDriver_Cab");

                entity.HasOne(d => d.Diver)
                    .WithMany(p => p.CabDrivers)
                    .HasForeignKey(d => d.DriverId)
                    .HasConstraintName("FK_CabDriver_Driver");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer");
            });

            modelBuilder.Entity<Driver>(entity =>
            {
                entity.ToTable("Driver");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
