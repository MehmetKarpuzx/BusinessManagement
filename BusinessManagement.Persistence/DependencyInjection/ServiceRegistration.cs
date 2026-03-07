using BusinessManagement.Application.Interfaces.Repositories;
using BusinessManagement.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessManagement.Persistence.DependencyInjection
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services)
        {
            services.AddScoped<IBranchRepository,BranchRepository >();

            

            return services;
        }
    }
}
