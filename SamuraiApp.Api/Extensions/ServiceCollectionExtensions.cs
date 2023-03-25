using Microsoft.Extensions.DependencyInjection;
using SamuraiApp.Service.Interfaces;
using SamuraiApp.Service.Services;

namespace SamuraiApp.Shared.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDepencyInjection(this IServiceCollection services)
        {
            services.AddScoped<ISamuraisService, SamuraisService>();
        }
    }
}