using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SGSWebApp.Application.Common.Interfaces.Repositories;
using SGSWebApp.Infrastructure.Data;
using SGSWebApp.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGSWebApp.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureService(this IServiceCollection services, IConfiguration configuration)
        {

            string connectionString = configuration.GetConnectionString("DevConnection");

            services.AddDbContext<ApplicationDbContext>((sp, options) =>
            {
                options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());

                options.UseSqlServer(connectionString, b => b.MigrationsAssembly("SGSWebApp.Infrastructure"));
            });

            services.AddScoped<IContainerRepository, ContainerRepository>();
            services.AddScoped<IOperationRepository, OperationRepository>();

            return services;
        }
    }
}
