﻿using ETicaretAPI.Application.Respositories;
using ETicaretAPI.Persistance.Contexts;
using ETicaretAPI.Persistance.Respositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistance
{
    public static class ServiceRegistration
    {
        public static void AddPersistanceServis(this IServiceCollection services)
        {
            services.AddDbContext<ETicaretDbContext>(options => options.UseNpgsql("User ID=postgres;Password=123;Host=localhost;Port=5432;Database=ETicaretDb;"));
            services.AddScoped<ICustomerReadRepository, CustomerReadRepository>();
            services.AddScoped<ICustomerWriteRepository, CustomerWriteRepository>();
            services.AddScoped<IProductReadRepository, ProductReadRepository>();
            services.AddScoped<IProductWriteRepository, ProductWriteRepository>();
            services.AddScoped<IOrderReadRepository, OrderReadRepository>();
            services.AddScoped<IOrderWriteRepository, OrderWriteRepository>();

        }
    }
}
