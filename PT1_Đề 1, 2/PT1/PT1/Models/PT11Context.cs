using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace PT1.Models
{
    public partial class PT11Context : DbContext
    {
        public PT11Context()
        {
        }

        public PT11Context(DbContextOptions<PT11Context> options)
            : base(options)
        {
        }

        public virtual DbSet<AssetType> AssetTypes { get; set; } = null!;
        public virtual DbSet<AssetTypeGroup> AssetTypeGroups { get; set; } = null!;
        public virtual DbSet<MaterialGroup> MaterialGroups { get; set; } = null!;
        public virtual DbSet<MaterialType> MaterialTypes { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
                              .SetBasePath(Directory.GetCurrentDirectory())
                              .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            IConfigurationRoot configuration = builder.Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("MyCnn"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AssetType>(entity =>
            {
                entity.HasIndex(e => e.AssetTypeCode, "UQ_AssetTypeCode")
                    .IsUnique();

                entity.Property(e => e.AssetTypeId).HasColumnName("AssetTypeID");

                entity.Property(e => e.AssetTypeCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.AssetTypeGroupId).HasColumnName("AssetTypeGroupID");

                entity.Property(e => e.AssetTypeName).HasMaxLength(100);
            });

            modelBuilder.Entity<AssetTypeGroup>(entity =>
            {
                entity.Property(e => e.AssetTypeGroupId).HasColumnName("AssetTypeGroupID");

                entity.Property(e => e.GroupName).HasMaxLength(50);
            });

            modelBuilder.Entity<MaterialGroup>(entity =>
            {
                entity.Property(e => e.MaterialGroupId).HasColumnName("MaterialGroupID");

                entity.Property(e => e.GroupName).HasMaxLength(50);
            });

            modelBuilder.Entity<MaterialType>(entity =>
            {
                entity.HasIndex(e => e.MaterialTypeCode, "UQ_MaterialCode")
                    .IsUnique();

                entity.Property(e => e.MaterialTypeId).HasColumnName("MaterialTypeID");

                entity.Property(e => e.MaterialGroupId).HasColumnName("MaterialGroupID");

                entity.Property(e => e.MaterialTypeCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MaterialTypeName).HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
