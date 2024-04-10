using App.Infra.Database.SQLServer.EF.Configurations;
using Core.CarEntity;
using Core.LogEntity;
using Core.RequestEntity;
using Core.UserEnitiy;
using Microsoft.EntityFrameworkCore;
using System.Drawing;

namespace App.Infra.Database.SQLServer.EF
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CW22;Integrated Security=True;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new AdminEntityConfiguration());
            modelBuilder.ApplyConfiguration(new CarModelEntitiyConfiguration());
            modelBuilder.Entity<Car>()
                .HasOne(c => c.CarBrand)
                .WithMany(b => b.Cars)
                .HasForeignKey(c => c.CarBrandId);
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<CarRequest> Requests { get; set; }
        public DbSet<CarBrand> Brands { get; set; }
    }
}
