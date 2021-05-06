using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;


using BADoc.Infrastructure.Interfaces;
using BADoc.Infrastructure.Implementation;

namespace BADoc.Infrastructure
{
    public static class DepentencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IDbContext, AppDbContext>();
            services.AddDbContext<AppDbContext>(context => 
                context.UseMySql("server=10.10.8.159;user=badoc;password=1qaz1qaz;database=badoc;", ServerVersion.AutoDetect("server=10.10.8.159;user=badoc;password=1qaz1qaz;database=badoc;"))
            , ServiceLifetime.Scoped);

            return services;
        } 
    }
}
