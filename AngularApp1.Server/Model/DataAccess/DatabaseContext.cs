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
            string connectionString = "Server=localhost;Database=warehouse;User Id=WarehouseNetappUser;Password=340$Uuxwp7Mcxo7Khy;";
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
