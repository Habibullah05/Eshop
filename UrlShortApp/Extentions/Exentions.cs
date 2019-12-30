using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UrlShortApp.Models.Abstractions;
using UrlShortApp.Models.Services;

namespace UrlShortApp.Extentions
{
    public static class Exentions
    {
        public static IServiceCollection AddUrlManager(this IServiceCollection services)
        {
            services.AddScoped<IUrlManager, UrlManager>();
            return services;
        }
        public static IServiceCollection AddHashService(this IServiceCollection services)
        {
            services.AddScoped<IHashGenerationService, HashGenerationService>();
            return services;
        }

    }
}
