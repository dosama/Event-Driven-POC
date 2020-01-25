using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CarService.Data
{
    public partial class CarContext : DbContext
    {
        public CarContext()
        {
        }

        public CarContext(DbContextOptions<CarContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Rents> Rents { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=localhost;Database=Car;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Rents>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CarNumber)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasColumnType("date");

                entity.Property(e => e.RentPrice).HasColumnType("money");

                entity.Property(e => e.Staus)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.TransactionId)
                    .IsRequired()
                    .HasColumnName("TransactionID")
                    .HasMaxLength(50);
            });
        }
    }
}
