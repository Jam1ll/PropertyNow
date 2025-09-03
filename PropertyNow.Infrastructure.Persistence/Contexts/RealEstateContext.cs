using Microsoft.EntityFrameworkCore;
using PropertyNow.Core.Domain.Entities;
using PropertyNow.Infrastructure.Identity.Entities;
using System.Reflection;

namespace PropertyNow.Infrastructure.Persistence.Contexts
{
    public class PropertyNowContext : DbContext
    {
        public PropertyNowContext(DbContextOptions<PropertyNowContext> options) : base(options) { }

        //
        // DB SETS
        //
        
        public DbSet<AppUser> Users { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<PropertyType> PropertyTypes { get; set; }
        public DbSet<SalesType> SalesTypes { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<FavoriteProperty> FavoriteProperties { get; set; }

        //
        // ENTITY CONFIGURATIONS APPLICATION
        //

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}