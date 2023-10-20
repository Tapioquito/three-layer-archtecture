﻿using ProductsRegister.Business.Interfaces;
using ProductsRegister.Business.Notifications;
using ProductsRegister.Data.Context;
using ProductsRegister.Data.Repository;

namespace ProductsRegister.API.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            //Data
            services.AddScoped<MyDbContext>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ISupplierRepository, SupplierRepository>();

            //Business
            services.AddScoped<ISupplierRepository, SupplierRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<INotifier, Notifier>();
            return services;
        }
    }
}
