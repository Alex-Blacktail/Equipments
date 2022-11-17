using Equipments.Domain;
using Equipments.Domain.Components;
using Equipments.Domain.Equipments;
using Equipments.Domain.Inspections;
using Microsoft.EntityFrameworkCore;

namespace Equipments.Infrastructure
{
    public class EquipmentsDbContext : DbContext
    {
        public DbSet<DataType> DataTypes { get; set; }
        public DbSet<MeasureUnit> MeasureUnits { get; set; }

        public DbSet<Component> Components { get; set; }
        public DbSet<ComponentProperty> ComponentProperties { get; set; }
        public DbSet<ComponentType> ComponentTypes { get; set; }
        public DbSet<ComponentTypeProperty> ComponentTypeProperties { get; set; }

        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<EquipmentProperty> EquipmentProperties { get; set; }
        public DbSet<EquipmentType> EquipmentTypes { get; set; }
        public DbSet<EquipmentTypeProperty> EquipmentTypeProperties { get; set; }

        public DbSet<Inspection> EInspections { get; set; }
        public DbSet<InspectionEquipmentFact> InspectionEquipmentFacts { get; set; }
        public DbSet<InspectionComponentFact> InspectionComponentFacts { get; set; }
        public DbSet<InspectionType> InspectionTypes { get; set; }

        public DbSet<StateType> StateTypes { get; set; }
        public DbSet<EquipmentState> EquipmentStates { get; set; }
        public DbSet<ComponentState> ComponentStates { get; set; }

        public EquipmentsDbContext(DbContextOptions<EquipmentsDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            ConfigureCommon(builder);
            ConfigureComponents(builder);
            ConfigureEquipments(builder);
            ConfigureInspections(builder);
        }

        private void ConfigureCommon(ModelBuilder builder)
        {
            builder.Entity<StateType>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Name).HasMaxLength(50);
            });

            builder.Entity<DataType>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Name).HasMaxLength(50);
                entity.Property(e => e.CodeName).HasMaxLength(25);
            });

            builder.Entity<MeasureUnit>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Name).HasMaxLength(50);
                entity.Property(e => e.ShortName).HasMaxLength(10);
                entity
                    .HasOne(e => e.DataType)
                    .WithMany(e => e.MeasureUnits)
                    .HasForeignKey(e => e.DataTypeId);
            });

            builder.Entity<EquipmentState>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity
                    .HasOne(e => e.StateType)
                    .WithMany(e => e.EquipmentStates)
                    .HasForeignKey(e => e.StateTypeId);
                entity
                    .HasOne(e => e.Equipment)
                    .WithOne(e => e.EquipmentState)
                    .HasForeignKey<EquipmentState>(e => e.EquipmentId);
            });

            builder.Entity<ComponentState>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity
                    .HasOne(e => e.StateType)
                    .WithMany(e => e.ComponentStates)
                    .HasForeignKey(e => e.StateTypeId);
                entity
                    .HasOne(e => e.Component)
                    .WithOne(e => e.ComponentState)
                    .HasForeignKey<ComponentState>(e => e.ComponentId);
            });
        }

        private void ConfigureComponents(ModelBuilder builder)
        {
            builder.Entity<ComponentType>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Name).HasMaxLength(50);
            });

            builder.Entity<ComponentTypeProperty>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Name).HasMaxLength(100);
                entity
                    .HasOne(e => e.MeasureUnit)
                    .WithMany(e => e.ComponentTypeProperties)
                    .HasForeignKey(e => e.MeasureUnitId);
                entity
                    .HasOne(e => e.ComponentType)
                    .WithMany(e => e.ComponentTypeProperties)
                    .HasForeignKey(e => e.ComponentTypeId);
            });

            builder.Entity<ComponentProperty>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.StringValue).HasMaxLength(100);
                entity
                    .HasOne(e => e.ComponentTypeProperty)
                    .WithMany(e => e.ComponentProperties)
                    .HasForeignKey(e => e.ComponentTypePropertyId);
                entity
                    .HasOne(e => e.Component)
                    .WithMany(e => e.ComponentProperties)
                    .HasForeignKey(e => e.ComponentId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<Component>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.ModelName).HasMaxLength(100);
                entity.Property(e => e.ModelNumber).HasMaxLength(60);
                entity.Property(e => e.InventoryNumber).HasMaxLength(30);
                entity
                    .HasOne(e => e.ComponentType)
                    .WithMany(e => e.Components)
                    .HasForeignKey(e => e.ComponentTypeId);
                entity
                    .HasOne(e => e.Equipment)
                    .WithMany(e => e.Components)
                    .HasForeignKey(e => e.EquipmentId);
            });
        }

        private void ConfigureEquipments(ModelBuilder builder)
        {
            builder.Entity<EquipmentType>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Name).HasMaxLength(50);
            });

            builder.Entity<EquipmentTypeProperty>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Name).HasMaxLength(100);
                entity
                    .HasOne(e => e.MeasureUnit)
                    .WithMany(e => e.EquipmentTypeProperties)
                    .HasForeignKey(e => e.MeasureUnitId);
                entity
                    .HasOne(e => e.EquipmentType)
                    .WithMany(e => e.EquipmentTypeProperties)
                    .HasForeignKey(e => e.EquipmentTypeId);
            });

            builder.Entity<EquipmentProperty>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.StringValue).HasMaxLength(100);
                entity
                    .HasOne(e => e.EquipmentTypeProperty)
                    .WithMany(e => e.EquipmentProperties)
                    .HasForeignKey(e => e.EquipmentTypePropertyId)
                    .OnDelete(DeleteBehavior.Restrict);
                entity
                   .HasOne(e => e.Equipment)
                   .WithMany(e => e.EquipmentProperties)
                   .HasForeignKey(e => e.EquipmentId);
            });

            builder.Entity<Equipment>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.ModelName).HasMaxLength(100);
                entity.Property(e => e.ModelNumber).HasMaxLength(60);
                entity.Property(e => e.InventoryNumber).HasMaxLength(30);
                entity
                    .HasOne(e => e.EquipmentType)
                    .WithMany(e => e.Equipments)
                    .HasForeignKey(e => e.EquipmentTypeId);
            });
        }

        private void ConfigureInspections(ModelBuilder builder)
        {
            builder.Entity<InspectionType>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Name).HasMaxLength(40);
            });

            builder.Entity<Inspection>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Comment).HasMaxLength(250);
                entity
                    .HasOne(e => e.InspectionType)
                    .WithMany(e => e.Inspections)
                    .HasForeignKey(e => e.InspectionTypeId);
            });

            builder.Entity<InspectionEquipmentFact>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Comment).HasMaxLength(60);
                entity
                    .HasOne(e => e.Inspection)
                    .WithMany(e => e.InspectionEquipmentFacts)
                    .HasForeignKey(e => e.InspectionId);
                entity
                    .HasOne(e => e.EquipmentState)
                    .WithMany(e => e.InspectionEquipmentFacts)
                    .HasForeignKey(e => e.EquipmentStateId);
            });

            builder.Entity<InspectionComponentFact>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity
                    .HasOne(e => e.InspectionEquipmentFact)
                    .WithMany(e => e.InspectionComponentFacts)
                    .HasForeignKey(e => e.InspectionEquipmentFactId)
                    .OnDelete(DeleteBehavior.Restrict);
                entity
                    .HasOne(e => e.ComponentState)
                    .WithMany(e => e.InspectionComponentFacts)
                    .HasForeignKey(e => e.ComponentStateId);
            });
        }
    }
}
