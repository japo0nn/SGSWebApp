using Microsoft.Extensions.DependencyInjection;
using Mapster;
using SGSWebApp.Application.Common.Helpers;

namespace SGSWebApp.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services) {
            return services;
        }
    }
}
