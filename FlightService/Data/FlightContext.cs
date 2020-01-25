using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FlightService.Data
{
    public partial class FlightContext : DbContext
    {
        public FlightContext()
        {
        }

        public FlightContext(DbContextOptions<FlightContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Bookings> Bookings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=localhost;Database=Flight;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bookings>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BookingStatus)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CreatedDate).HasColumnType("date");

                entity.Property(e => e.TransactionId)
                    .IsRequired()
                    .HasColumnName("TransactionID")
                    .HasMaxLength(50);
            });
        }
    }
}
