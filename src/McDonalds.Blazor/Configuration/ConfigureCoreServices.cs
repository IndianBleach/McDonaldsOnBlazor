using McDonaldsOnWeb.Application.Data;
using McDonaldsOnWeb.Application.Interfaces;
using McDonaldsOnWeb.Application.Services.MenuItemService;
using Microsoft.Extensions.DependencyInjection;

namespace McDonaldsOnWeb.Web.Configuration
{
    public static class ConfigureCoreServicesExtension
    {
        public static void UseTransientDbContext(this IServiceCollection services,
            string sqlConnectionString)
        {
            services.AddSingleton<IApplicationContext, ApplicationContext>(x =>
                new ApplicationContext(sqlConnectionString));
        }

        public static void ConfigureCoreServices(this IServiceCollection services)
        {
            services.AddTransient<IMenuItemService, MenuItemService>();
        }
    }
}
