using System;
using Microsoft.Extensions.DependencyInjection;

using BADoc.UseCases.Interfaces;
using BADoc.UseCases.Services;

namespace BADoc.UseCases
{
    public static class DepentencyInjection
    {
        public static IServiceCollection AddUseCases(this IServiceCollection services)
        {
            services.AddScoped<IUserService, IdentityUserService>();
            services.AddScoped<ITreeViewService, TreeViewService>();
            services.AddScoped<IContactService, ContactService>();
            services.AddScoped<IPageService, PageService>();

            return services;
        } 
    }
}
