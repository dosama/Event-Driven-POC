using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace HotelService.Data
{
    public partial class HotelContext : DbContext
    {
        public HotelContext()
        {
        }

        public HotelContext(DbContextOptions<HotelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Reservation> Reservation { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=localhost;Database=Hotel;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Reservation>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CreatedDate).HasColumnType("date");

                entity.Property(e => e.Price).HasColumnType("money");

                entity.Property(e => e.ReservationDate).HasColumnType("date");

                entity.Property(e => e.ReservationStatus)
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
