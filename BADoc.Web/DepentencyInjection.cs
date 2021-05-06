using System;
using Microsoft.Extensions.DependencyInjection;

using BADoc.UseCases.Interfaces;
using BADoc.Infrastructure;
using BADoc.UseCases;
using BADoc.Web.Utils;

using Microsoft.AspNetCore.Identity;
using BADoc.Infrastructure.Implementation;

namespace BADoc.Web
{
    public static class DepentencyInjection
    {
        
        public static IServiceCollection AddWeb(this IServiceCollection services)
        {

            services.AddInfrastructure();
            services.AddIdentity<IdentityUser, IdentityRole>()
                    .AddEntityFrameworkStores<AppDbContext>();
            services.AddUseCases();

            services.AddScoped<IJwtGenerator, JwtGenerator>();

            return services;
        } 
    }
}
