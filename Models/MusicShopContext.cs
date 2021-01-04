using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using MusicShop.Models;

namespace MusicShop.Models
{
    public partial class MusicShopContext : DbContext
    {
        public MusicShopContext()
        {
        }

        public MusicShopContext(DbContextOptions<MusicShopContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Colors> Colors { get; set; }
        public virtual DbSet<Instrument> Instrument { get; set; }
        public virtual DbSet<InstrumentRating> InstrumentRating { get; set; }
        public virtual DbSet<InstrumentType> InstrumentType { get; set; }
        public virtual DbSet<Manufacturer> Manufacturer { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Colors>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Instrument>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsFixedLength();

                entity.Property(e => e.Price).HasColumnType("money");

                entity.HasOne(d => d.Color)
                    .WithMany(p => p.Instrument)
                    .HasForeignKey(d => d.ColorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Instrument_Colors");

                entity.HasOne(d => d.Manufacturer)
                    .WithMany(p => p.Instrument)
                    .HasForeignKey(d => d.ManufacturerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Instrument_Manufacturer");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.Instrument)
                    .HasForeignKey(d => d.TypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Instrument_InstrumentType");
            });

            modelBuilder.Entity<InstrumentRating>(entity =>
            {
                entity.HasOne(d => d.Instrument)
                    .WithMany(p => p.InstrumentRating)
                    .HasForeignKey(d => d.InstrumentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_InstrumentRating_Instrument");
            });

            modelBuilder.Entity<InstrumentType>(entity =>
            {
                entity.Property(e => e.Name)
                    .HasMaxLength(128)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Manufacturer>(entity =>
            {
                entity.Property(e => e.Adress)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsFixedLength();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(128)
                    .IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        public DbSet<MusicShop.Models.Cart> Cart { get; set; }
    }
}
