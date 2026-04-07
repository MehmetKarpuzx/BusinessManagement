using BusinessManagement.MVC.Application.Interfaces;
using BusinessManagement.MVC.Application.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace BusinessManagement.MVC.Application.DependencyInjection
{
    public static class ServiceRegistration
    {
        public static void AddMvcApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ILoadDropdownServices, LoadDropdownServices>();

            var baseUrl = configuration["ApiSettings:BaseUrl"];

            services.AddHttpClient<IBranchServices, BranchServices>(c => c.BaseAddress = new Uri(baseUrl));
            services.AddHttpClient<ICargoCompanyServices, CargoCompanyServices>(c => c.BaseAddress = new Uri(baseUrl));
            services.AddHttpClient<ICustomerServices, CustomerServices>(c => c.BaseAddress = new Uri(baseUrl));
            services.AddHttpClient<ICustomerTypeServices, CustomerTypeServices>(c => c.BaseAddress = new Uri(baseUrl));
            services.AddHttpClient<IMaterialServices, MaterialServices>(c => c.BaseAddress = new Uri(baseUrl));
            services.AddHttpClient<IMaterialProcurementServices, MaterialProcurementServices>(c => c.BaseAddress = new Uri(baseUrl));
            services.AddHttpClient<IOrderServices, OrderServices>(c => c.BaseAddress = new Uri(baseUrl));
            services.AddHttpClient<IPaymentServices, PaymentServices>(c => c.BaseAddress = new Uri(baseUrl));
            services.AddHttpClient<IPaymentMethodServices, PaymentMethodServices>(c => c.BaseAddress = new Uri(baseUrl));
            services.AddHttpClient<IPaymentServices, PaymentServices>(c => c.BaseAddress = new Uri(baseUrl));
            services.AddHttpClient<IProcessTypeServices, ProcessTypeServices>(c => c.BaseAddress = new Uri(baseUrl));
            services.AddHttpClient<IProductServices, ProductServices>(c => c.BaseAddress = new Uri(baseUrl));
            services.AddHttpClient<IProductionServices, ProductionServices>(c => c.BaseAddress = new Uri(baseUrl));
            services.AddHttpClient<ISupplierServices, SupplierServices>(c => c.BaseAddress = new Uri(baseUrl));
            services.AddHttpClient<ITransferServices, TransferServices>(c => c.BaseAddress = new Uri(baseUrl));
            services.AddHttpClient<IUnitServices, UnitServices>(c => c.BaseAddress = new Uri(baseUrl));
            services.AddHttpClient<IWarehouseMovementServices, WarehouseMovementServices>(c => c.BaseAddress = new Uri(baseUrl));
            services.AddHttpClient<IUserServices, UserServices>(c => c.BaseAddress = new Uri(baseUrl));
            services.AddHttpClient<IRolServices, RolServices>(c => c.BaseAddress = new Uri(baseUrl));
        }
    }
}
