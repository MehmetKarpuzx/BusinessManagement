using BusinessManagement.Application.Interfaces;
using BusinessManagement.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessManagement.Application.DependencyInjection
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IBranchServices, BranchServices>(); 
            services.AddScoped<ICargoCompanyServices, CargoCompanyServices>(); 
            services.AddScoped<ICustomerServices, CustomerServices>(); 
            services.AddScoped<ICustomerTypeServices, CustomerTypeServices>(); 
            services.AddScoped<IMaterialProcurementServices, MaterialProcurementServices>(); 
            services.AddScoped<IMaterialServices, MaterialServices>(); 
            services.AddScoped<IOrderServices, OrderServices>(); 
            services.AddScoped<IPaymentMethodServices, PaymentMethodServices>(); 
            services.AddScoped<IProcessTypeServices, ProcessTypeServices>(); 
            services.AddScoped<IProductionServices, ProductionServices>(); 
            services.AddScoped<IProductServices, ProductServices>(); 
            services.AddScoped<ISupplierServices, SupplierServices>(); 
            services.AddScoped<ITransferServices, TransferServices>(); 
            services.AddScoped<IUnitServices, UnitServices>(); 
            services.AddScoped<IWarehouseMovementServices, WarehouseMovementServices>(); 
            return services;
        }
    }
}
