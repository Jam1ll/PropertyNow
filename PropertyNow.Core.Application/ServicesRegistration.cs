using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using PropertyNow.Core.Application.Interfaces;
using PropertyNow.Core.Application.Mappings.DTOsAndViewModels;
using PropertyNow.Core.Application.Mappings.EntitiesAndDTOs;
using PropertyNow.Core.Application.Services;
using System.Reflection;

namespace PropertyNow.Core.Application
{
    public static class ServicesRegistration
    {
        //Extension method - Decorator pattern
        public static void AddApplicationLayerIoc(this IServiceCollection services)
        {
            #region Configurations
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(opt => opt.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            #endregion

            #region Services IOC

            services.AddScoped<IPropertyService, PropertyService>();
            services.AddScoped<IPropertyTypeService, PropertyTypeService>();
            services.AddScoped<ISalesTypeService, SalesTypeService>();
            services.AddScoped<IFeatureService, FeatureService>();
            services.AddScoped<IFavoriteService, FavoriteService>();
            services.AddScoped<IOfferService, OfferService>();
            services.AddScoped<IMessageService, MessageService>();
            #endregion
        }
    }
}
