using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PropertyNow.Core.Domain.Interfaces;
using PropertyNow.Infrastructure.Identity.Entities;
using PropertyNow.Infrastructure.Persistence.Contexts;
using PropertyNow.Infrastructure.Persistence.Repositories;
//using PropertyNow.Infrastructure.Persistence.Seeders;

namespace PropertyNow.Infrastructure.Persistence
{
    public static class ServicesRegistration
    {
        public static void AddPersistenceLayerIoc(this IServiceCollection services, IConfiguration config)
        {
            #region contexts
            if (config.GetValue<bool>("UseInMemoryDatabase"))
            {
                services.AddDbContext<PropertyNowContext>(opt =>
                                              opt.UseInMemoryDatabase("AppDb"));
            }
            else
            {
                var connectionString = config.GetConnectionString("DefaultConnection");
                services.AddDbContext<PropertyNowContext>(
                    (serviceProvider, opt) =>
                    {
                        opt.EnableSensitiveDataLogging();
                        opt.UseSqlServer(connectionString,
                        m => m.MigrationsAssembly(typeof(PropertyNowContext).Assembly.FullName));
                    },
                    contextLifetime: ServiceLifetime.Scoped,
                    optionsLifetime: ServiceLifetime.Scoped
                    );
                #endregion

                #region repositories IOC
                services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
              
                services.AddScoped<IPropertyRepository, PropertyRepository>();
                services.AddScoped<IPropertyTypeRepository, PropertyTypeRepository>();
                services.AddScoped<ISalesTypeRepository, SalesTypeRepository>();
                services.AddScoped<IFeatureRepository, FeatureRepository>();
                services.AddScoped<IFavoritePropertyRepository, FavoritePropertyRepository>();
                services.AddScoped<IMessageRepository, MessageRepository>();
                services.AddScoped<IOfferRepository, OfferRepository>();
                #endregion
            }
        }
    }
}