using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace OrderServiceApi.Data
{
    public partial class OrderContext : DbContext
    {
        public OrderContext()
        {
        }

        public OrderContext(DbContextOptions<OrderContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Orders> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=localhost;Database=Order;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Orders>(entity =>
            {
                entity.HasKey(e => e.OrderNumber);

                entity.Property(e => e.CarRentId).HasColumnName("CarRentID");

                entity.Property(e => e.ConfirmationDate).HasColumnType("date");

                entity.Property(e => e.CreatedDate).HasColumnType("date");

                entity.Property(e => e.FlightBookingId).HasColumnName("FlightBookingID");

                entity.Property(e => e.HotelReservationId).HasColumnName("HotelReservationID");

                entity.Property(e => e.OrderStatus)
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
