using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using MuafiyetProjesi2024.Models;

namespace MuafiyetProjesi2024.Data;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }


    public virtual DbSet<Basvuru> Basvurular { get; set; }

    public virtual DbSet<Ders> Dersler { get; set; }

    public virtual DbSet<Evrak> Evraklar { get; set; }

    public virtual DbSet<Kullanici> Kullanicilar { get; set; }
    
    public virtual DbSet<AdminKullanici> AdminKullanicilar { get; set; }

    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AdminKullanici>(entity =>
        {

            entity.HasKey(e => e.AdminKullaniciId);

            entity.ToTable("AdminKullanicilar");

            entity.Property(e => e.AdSoyad).HasMaxLength(50);

            entity.Property(e => e.Sifre).HasMaxLength(100);

            entity.Property(e => e.BolumBilgisi).HasMaxLength(50);

            entity.Property(e => e.Yetkisi).HasMaxLength(50);

            entity.Property(e => e.Mail).HasMaxLength(50);
        });

        modelBuilder.Entity<Basvuru>(entity =>
        {
            entity.HasOne(d => d.Kullanici)
                .WithOne(p => p.Basvuru)
                .HasForeignKey<Basvuru>(d => d.Tckimlik)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Basvurular_Kullanicilar");
        });

        modelBuilder.Entity<Ders>(entity =>
        {
            entity.HasOne(d => d.Kullanici)
                .WithMany(p => p.Ders)
                .HasForeignKey(d => d.Tckimlik)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Dersler_Kullanicilar");
        });

        modelBuilder.Entity<Evrak>(entity =>
        {
            entity.HasOne(d => d.Kullanici)
                .WithOne(p => p.Evrak)
                .HasForeignKey<Evrak>(d => d.Tckimlik)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Evraklar_Kullanicilar");
        });

        modelBuilder.Entity<Kullanici>(entity =>
        {
            entity.HasKey(e => e.Tckimlik);
            entity.Property(e => e.Tckimlik).IsRequired();
        });
        
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
