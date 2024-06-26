﻿using BookActivity.Infrastructure.Data.Intefaces;
using BookActivity.Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BookActivity.Initialization
{
    public sealed class ModuleConfiguration : IModuleConfiguration
    {
        public IServiceCollection ConfigureDI(IServiceCollection services, IConfiguration Configuration)
        {
            services.AddSingleton<IDbInitializer, DbInitializer>();

            return services;
        }
    }
}
