using AngularApp1.Server.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace AngularApp1.Server.Model.DataAccess
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Resource> Resources { get; set; } = null!;
        public DbSet<Measure> Measures { get; set; } = null!;
        public DbSet<Client> Clients { get; set; } = null!;
        public DbSet<Balance> Balances { get; set; } = null!;
        public DbSet<IncomeResource> IncomeResources { get; set; } = null!;
        public DbSet<Income> Incomes { get; set; } = null!;

        public DbSet<ShipmentResource> ShipmentResources { get; set; } = null!;
        public DbSet<Shipment> Shipments { get; set; } = null!;

        public DatabaseContext()
        {
            Database.EnsureCreated();
        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=warehouselocal.db");
            // string connectionString = "Server=localhost;Database=warehouse;User Id=WarehouseNetappUser;Password=340$Uuxwp7Mcxo7Khy;";
            // optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // TODO: Define Nullables and Non-Nullables
            // TODO: Define String Types for some fields like Number varchar 50
            modelBuilder.Entity<Client>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.HasIndex(e => e.Name).IsUnique();
            });

            modelBuilder.Entity<Measure>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.HasIndex(e => e.Name).IsUnique();
            });

            modelBuilder.Entity<Resource>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.HasIndex(e => e.Name).IsUnique();
            });

            modelBuilder.Entity<Shipment>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.HasIndex(e => e.Number).IsUnique();
                entity.HasMany(e => e.ShipmentResources).WithOne(ir => ir.Shipment).HasForeignKey(ir => ir.ShipmentId);
            });

            modelBuilder.Entity<Income>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.HasIndex(e => e.Number).IsUnique();
                entity.HasMany(e => e.IncomeResources).WithOne(ir => ir.Income).HasForeignKey(ir => ir.IncomeId);
            });

            modelBuilder.Entity<Balance>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.HasOne(e => e.Resource).WithMany(r => r.Balances).HasForeignKey(e => e.ResourceId);
                entity.HasOne(e => e.Measure).WithMany(r => r.Balances).HasForeignKey(e => e.MeasureId);
            });

            modelBuilder.Entity<ShipmentResource>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.HasOne(e => e.Resource).WithMany(r => r.ShipmentResources).HasForeignKey(e => e.ResourceId);
                entity.HasOne(e => e.Measure).WithMany(m => m.ShipmentResources).HasForeignKey(e => e.MeasureId);
            });

            modelBuilder.Entity<IncomeResource>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.HasOne(e => e.Resource).WithMany(r => r.IncomeResources).HasForeignKey(e => e.ResourceId);
                entity.HasOne(e => e.Measure).WithMany(m => m.IncomeResources).HasForeignKey(e => e.MeasureId);
            });
            
            base.OnModelCreating(modelBuilder);
        }
    }
}
