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
            services.AddScoped<ICargoCompanyRepository,CargoCompanyRepository >();
            services.AddScoped<ICustomerRepository,CustomerRepository >();
            services.AddScoped<ICustomerTypeRepository,CustomerTypeRepository >();
            services.AddScoped<IMaterialProcurementRepository,MaterialProcurementRepository >();
            services.AddScoped<IMaterialRepository,MaterialRepository >();
            services.AddScoped<IOrderRepository,OrderRepository >();
            services.AddScoped<IPaymentMethodRepository,PaymentMethodRepository >();
            services.AddScoped<IPaymentRepository,PaymentRepository >();
            services.AddScoped<IProcessTypeRepository,ProcessTypeRepository >();
            services.AddScoped<IProductionRepository,ProductionRepository >();
            services.AddScoped<IProductRepository,ProductRepository >();
            services.AddScoped<ISupplierRepository,SupplierRepository >();
            services.AddScoped<ITransferRepository,TransferRepository >();
            services.AddScoped<IUnitRepository,UnitRepository >();
            services.AddScoped<IWarehouseMovementRepository,WarehouseMovementRepository >();
            services.AddScoped<IUserRepository,UserRepository >();
            services.AddScoped<IRolRepository,RolRepository >();

            

            return services;
        }
    }
}
