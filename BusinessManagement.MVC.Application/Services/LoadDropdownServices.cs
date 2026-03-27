using BusinessManagement.DTO.BranchDTOs;
using BusinessManagement.DTO.CargoCompanyDTOs;
using BusinessManagement.DTO.CustomerDTOs;
using BusinessManagement.DTO.CustomerTypeDTOs;
using BusinessManagement.DTO.MaterialDTOs;
using BusinessManagement.DTO.MaterialProcurementDTOs;
using BusinessManagement.DTO.OrderDTOs;
using BusinessManagement.DTO.PaymentDTOs;
using BusinessManagement.DTO.PaymentMethodDTOs;
using BusinessManagement.DTO.ProcessTypeDTOs;
using BusinessManagement.DTO.ProductDTOs;
using BusinessManagement.DTO.ProductionDTOs;
using BusinessManagement.DTO.SupplierDTOs;
using BusinessManagement.DTO.TransferDTOs;
using BusinessManagement.DTO.UnitDTOs;
using BusinessManagement.DTO.WarehouseMovementDTOs;
using BusinessManagement.MVC.Application.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;

namespace BusinessManagement.MVC.Application.Services
{
    public class LoadDropdownServices : ILoadDropdownServices
    {
        private readonly IConfiguration _cfg;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public LoadDropdownServices(IConfiguration cfg,IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor)
        {
            _cfg = cfg;
            _httpClientFactory = httpClientFactory;
             _httpContextAccessor = httpContextAccessor;
        }
        public async Task<List<SelectListItem>> GetBranchesSelectListAsync()
        {
            var baseUrl = _cfg["ApiSettings:BaseUrl"];
            if(string.IsNullOrWhiteSpace(baseUrl))
                throw new Exception("API Url tanımlı değil");
            var url = $"{baseUrl.TrimEnd('/')}/Branch/GetAll";
            using var client = _httpClientFactory.CreateClient();

            var httpContext = _httpContextAccessor.HttpContext;
            if (httpContext != null)
            {
                var accessToken = await httpContext.GetTokenAsync("access_token");
                if (!string.IsNullOrEmpty(accessToken))
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                }
            }

            var response = await client.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                return new List<SelectListItem>();
            }

            var json = await response.Content.ReadAsStringAsync();
            var branchList = JsonConvert.DeserializeObject<List<ResponseBranchDto>>(json)
                              ?? new List<ResponseBranchDto>();
            return branchList
                .Select(b => new SelectListItem { Value = b.Id.ToString(), Text = b.Name })
                .ToList();
        }

        public async Task<List<SelectListItem>> GetCargoCompaniesSelectListAsync()
        {
            var baseUrl = _cfg["ApiSettings:BaseUrl"];
            if (string.IsNullOrWhiteSpace(baseUrl))
                throw new Exception("API Url tanımlı değil");
            var url = $"{baseUrl.TrimEnd('/')}/CargoCompany/GetAll";
            using var client = _httpClientFactory.CreateClient();

            var httpContext = _httpContextAccessor.HttpContext;
            if (httpContext != null)
            {
                var accessToken = await httpContext.GetTokenAsync("access_token");
                if (!string.IsNullOrEmpty(accessToken))
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                }
            }

            var response = await client.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                return new List<SelectListItem>();
            }

            var json = await response.Content.ReadAsStringAsync();
            var cargoCompanyList = JsonConvert.DeserializeObject<List<ResponseCargoCompanyDto>>(json)
                              ?? new List<ResponseCargoCompanyDto>();
            return cargoCompanyList
                .Select(b => new SelectListItem { Value = b.Id.ToString(), Text = b.Name })
                .ToList();
        }

        public async Task<List<SelectListItem>> GetCustomersSelectListAsync()
        {
            var baseUrl = _cfg["ApiSettings:BaseUrl"];
            if (string.IsNullOrWhiteSpace(baseUrl))
                throw new Exception("API Url tanımlı değil");
            var url = $"{baseUrl.TrimEnd('/')}/Customer/GetAll";
            using var client = _httpClientFactory.CreateClient();

            var httpContext = _httpContextAccessor.HttpContext;
            if (httpContext != null)
            {
                var accessToken = await httpContext.GetTokenAsync("access_token");
                if (!string.IsNullOrEmpty(accessToken))
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                }
            }

            var response = await client.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                return new List<SelectListItem>();
            }

            var json = await response.Content.ReadAsStringAsync();
            var customerList = JsonConvert.DeserializeObject<List<ResponseCustomerDto>>(json)
                              ?? new List<ResponseCustomerDto>();
            return customerList
                .Select(b => new SelectListItem { Value = b.Id.ToString(), Text = b.Name })
                .ToList();
        }

        public async Task<List<SelectListItem>> GetCustomerTypesSelectListAsync()
        {
            var baseUrl = _cfg["ApiSettings:BaseUrl"];
            if (string.IsNullOrWhiteSpace(baseUrl))
                throw new Exception("API Url tanımlı değil");
            var url = $"{baseUrl.TrimEnd('/')}/CustomerTypes/GetAll";
            using var client = _httpClientFactory.CreateClient();

            var httpContext = _httpContextAccessor.HttpContext;
            if (httpContext != null)
            {
                var accessToken = await httpContext.GetTokenAsync("access_token");
                if (!string.IsNullOrEmpty(accessToken))
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                }
            }

            var response = await client.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                return new List<SelectListItem>();
            }

            var json = await response.Content.ReadAsStringAsync();
            var customerTypesList = JsonConvert.DeserializeObject<List<ResponseCustomerTypeDto>>(json)
                              ?? new List<ResponseCustomerTypeDto>();
            return customerTypesList
                .Select(b => new SelectListItem { Value = b.Id.ToString(), Text = b.Name })
                .ToList();
        }

      
        public async Task<List<SelectListItem>> GetMaterialsSelectListAsync()
        {
            var baseUrl = _cfg["ApiSettings:BaseUrl"];
            if (string.IsNullOrWhiteSpace(baseUrl))
                throw new Exception("API Url tanımlı değil");
            var url = $"{baseUrl.TrimEnd('/')}/Material/GetAll";
            using var client = _httpClientFactory.CreateClient();

            var httpContext = _httpContextAccessor.HttpContext;
            if (httpContext != null)
            {
                var accessToken = await httpContext.GetTokenAsync("access_token");
                if (!string.IsNullOrEmpty(accessToken))
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                }
            }

            var response = await client.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                return new List<SelectListItem>();
            }

            var json = await response.Content.ReadAsStringAsync();
            var materialList = JsonConvert.DeserializeObject<List<ResponseMaterialDto>>(json)
                              ?? new List<ResponseMaterialDto>();
            return materialList
                .Select(b => new SelectListItem { Value = b.Id.ToString(), Text = b.Name })
                .ToList();
        }

        public async Task<List<SelectListItem>> GetOrdersSelectListAsync()
        {
            var baseUrl = _cfg["ApiSettings:BaseUrl"];
            if (string.IsNullOrWhiteSpace(baseUrl))
                throw new Exception("API Url tanımlı değil");
            var url = $"{baseUrl.TrimEnd('/')}/Order/GetAll";
            using var client = _httpClientFactory.CreateClient();

            var httpContext = _httpContextAccessor.HttpContext;
            if (httpContext != null)
            {
                var accessToken = await httpContext.GetTokenAsync("access_token");
                if (!string.IsNullOrEmpty(accessToken))
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                }
            }

            var response = await client.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                return new List<SelectListItem>();
            }

            var json = await response.Content.ReadAsStringAsync();
            var orderList = JsonConvert.DeserializeObject<List<ResponseOrderDto>>(json)
                              ?? new List<ResponseOrderDto>();
            return orderList
                .Select(b => new SelectListItem { Value = b.Id.ToString(), Text = "Sipariş - " + b.Id })
                .ToList();
        }

        public async Task<List<SelectListItem>> GetPaymentMethodsSelectListAsync()
        {
            var baseUrl = _cfg["ApiSettings:BaseUrl"];
            if (string.IsNullOrWhiteSpace(baseUrl))
                throw new Exception("API Url tanımlı değil");
            var url = $"{baseUrl.TrimEnd('/')}/PaymentMethod/GetAll";
            using var client = _httpClientFactory.CreateClient();

            var httpContext = _httpContextAccessor.HttpContext;
            if (httpContext != null)
            {
                var accessToken = await httpContext.GetTokenAsync("access_token");
                if (!string.IsNullOrEmpty(accessToken))
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                }
            }

            var response = await client.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                return new List<SelectListItem>();
            }

            var json = await response.Content.ReadAsStringAsync();
            var paymentMethodList = JsonConvert.DeserializeObject<List<ResponsePaymentMethodDto>>(json)
                              ?? new List<ResponsePaymentMethodDto>();
            return paymentMethodList
                .Select(b => new SelectListItem { Value = b.Id.ToString(), Text = b.Name })
                .ToList();
        }

        public async Task<List<SelectListItem>> GetPaymentsSelectListAsync()
        {
            var baseUrl = _cfg["ApiSettings:BaseUrl"];
            if (string.IsNullOrWhiteSpace(baseUrl))
                throw new Exception("API Url tanımlı değil");
            var url = $"{baseUrl.TrimEnd('/')}/Payment/GetAll";
            using var client = _httpClientFactory.CreateClient();

            var httpContext = _httpContextAccessor.HttpContext;
            if (httpContext != null)
            {
                var accessToken = await httpContext.GetTokenAsync("access_token");
                if (!string.IsNullOrEmpty(accessToken))
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                }
            }

            var response = await client.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                return new List<SelectListItem>();
            }

            var json = await response.Content.ReadAsStringAsync();
            var paymentMethodList = JsonConvert.DeserializeObject<List<ResponsePaymentDto>>(json)
                              ?? new List<ResponsePaymentDto>();
            return paymentMethodList
                .Select(b => new SelectListItem { Value = b.Id.ToString(), Text = "Ödeme - " + b.Id })
                .ToList();
        }

        public async Task<List<SelectListItem>> GetProcessTypesSelectListAsync()
        {
            var baseUrl = _cfg["ApiSettings:BaseUrl"];
            if (string.IsNullOrWhiteSpace(baseUrl))
                throw new Exception("API Url tanımlı değil");
            var url = $"{baseUrl.TrimEnd('/')}/ProcessType/GetAll";
            using var client = _httpClientFactory.CreateClient();

            var httpContext = _httpContextAccessor.HttpContext;
            if (httpContext != null)
            {
                var accessToken = await httpContext.GetTokenAsync("access_token");
                if (!string.IsNullOrEmpty(accessToken))
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                }
            }

            var response = await client.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                return new List<SelectListItem>();
            }

            var json = await response.Content.ReadAsStringAsync();
            var list = JsonConvert.DeserializeObject<List<ResponseProcessTypeDto>>(json)
                              ?? new List<ResponseProcessTypeDto>();
            return list
                .Select(b => new SelectListItem { Value = b.Id.ToString(), Text = b.Name })
                .ToList();
        }

        public async Task<List<SelectListItem>> GetProductionsSelectListAsync()
        {
            var baseUrl = _cfg["ApiSettings:BaseUrl"];
            if (string.IsNullOrWhiteSpace(baseUrl))
                throw new Exception("API Url tanımlı değil");
            var url = $"{baseUrl.TrimEnd('/')}/Production/GetAll";
            using var client = _httpClientFactory.CreateClient();

            var httpContext = _httpContextAccessor.HttpContext;
            if (httpContext != null)
            {
                var accessToken = await httpContext.GetTokenAsync("access_token");
                if (!string.IsNullOrEmpty(accessToken))
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                }
            }

            var response = await client.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                return new List<SelectListItem>();
            }

            var json = await response.Content.ReadAsStringAsync();
            var list = JsonConvert.DeserializeObject<List<ResponseProductionDto>>(json)
                              ?? new List<ResponseProductionDto>();
            return list
                .Select(b => new SelectListItem { Value = b.Id.ToString(), Text = "Üretim - " + b.Id })
                .ToList();
        }

        public async Task<List<SelectListItem>> GetProductsSelectListAsync()
        {
            var baseUrl = _cfg["ApiSettings:BaseUrl"];
            if (string.IsNullOrWhiteSpace(baseUrl))
                throw new Exception("API Url tanımlı değil");
            var url = $"{baseUrl.TrimEnd('/')}/Product/GetAll";
            using var client = _httpClientFactory.CreateClient();

            var httpContext = _httpContextAccessor.HttpContext;
            if (httpContext != null)
            {
                var accessToken = await httpContext.GetTokenAsync("access_token");
                if (!string.IsNullOrEmpty(accessToken))
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                }
            }

            var response = await client.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                return new List<SelectListItem>();
            }

            var json = await response.Content.ReadAsStringAsync();
            var list = JsonConvert.DeserializeObject<List<ResponseProductDto>>(json)
                              ?? new List<ResponseProductDto>();
            return list
                .Select(b => new SelectListItem { Value = b.Id.ToString(), Text = b.Name })
                .ToList();
        }

        public async Task<List<SelectListItem>> GetSuppliersSelectListAsync()
        {
            var baseUrl = _cfg["ApiSettings:BaseUrl"];
            if (string.IsNullOrWhiteSpace(baseUrl))
                throw new Exception("API Url tanımlı değil");
            var url = $"{baseUrl.TrimEnd('/')}/Supplier/GetAll";
            using var client = _httpClientFactory.CreateClient();

            var httpContext = _httpContextAccessor.HttpContext;
            if (httpContext != null)
            {
                var accessToken = await httpContext.GetTokenAsync("access_token");
                if (!string.IsNullOrEmpty(accessToken))
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                }
            }

            var response = await client.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                return new List<SelectListItem>();
            }

            var json = await response.Content.ReadAsStringAsync();
            var list = JsonConvert.DeserializeObject<List<ResponseSupplierDto>>(json)
                              ?? new List<ResponseSupplierDto>();
            return list
                .Select(b => new SelectListItem { Value = b.Id.ToString(), Text = b.Name })
                .ToList();
        }

        public async Task<List<SelectListItem>> GetTransfersSelectListAsync()
        {
            var baseUrl = _cfg["ApiSettings:BaseUrl"];
            if (string.IsNullOrWhiteSpace(baseUrl))
                throw new Exception("API Url tanımlı değil");
            var url = $"{baseUrl.TrimEnd('/')}/Transfer/GetAll";
            using var client = _httpClientFactory.CreateClient();

            var httpContext = _httpContextAccessor.HttpContext;
            if (httpContext != null)
            {
                var accessToken = await httpContext.GetTokenAsync("access_token");
                if (!string.IsNullOrEmpty(accessToken))
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                }
            }

            var response = await client.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                return new List<SelectListItem>();
            }

            var json = await response.Content.ReadAsStringAsync();
            var list = JsonConvert.DeserializeObject<List<ResponseTransferDto>>(json)
                              ?? new List<ResponseTransferDto>();
            return list
                .Select(b => new SelectListItem { Value = b.Id.ToString(), Text = "Transfer - " + b.Id })
                .ToList();
        }

        public async Task<List<SelectListItem>> GetUnitsSelectListAsync()
        {
            var baseUrl = _cfg["ApiSettings:BaseUrl"];
            if (string.IsNullOrWhiteSpace(baseUrl))
                throw new Exception("API Url tanımlı değil");
            var url = $"{baseUrl.TrimEnd('/')}/Unit/GetAll";
            using var client = _httpClientFactory.CreateClient();

            var httpContext = _httpContextAccessor.HttpContext;
            if (httpContext != null)
            {
                var accessToken = await httpContext.GetTokenAsync("access_token");
                if (!string.IsNullOrEmpty(accessToken))
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                }
            }

            var response = await client.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                return new List<SelectListItem>();
            }

            var json = await response.Content.ReadAsStringAsync();
            var list = JsonConvert.DeserializeObject<List<ResponseUnitDto>>(json)
                              ?? new List<ResponseUnitDto>();
            return list
                .Select(b => new SelectListItem { Value = b.Id.ToString(), Text = b.Name })
                .ToList();
        }

        public async Task<List<SelectListItem>> GetWarehouseMovementsSelectListAsync()
        {
            var baseUrl = _cfg["ApiSettings:BaseUrl"];
            if (string.IsNullOrWhiteSpace(baseUrl))
                throw new Exception("API Url tanımlı değil");
            var url = $"{baseUrl.TrimEnd('/')}/WarehouseMovement/GetAll";
            using var client = _httpClientFactory.CreateClient();

            var httpContext = _httpContextAccessor.HttpContext;
            if (httpContext != null)
            {
                var accessToken = await httpContext.GetTokenAsync("access_token");
                if (!string.IsNullOrEmpty(accessToken))
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                }
            }

            var response = await client.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                return new List<SelectListItem>();
            }

            var json = await response.Content.ReadAsStringAsync();
            var list = JsonConvert.DeserializeObject<List<ResponseWarehouseMovementDto>>(json)
                              ?? new List<ResponseWarehouseMovementDto>();
            return list
                .Select(b => new SelectListItem { Value = b.Id.ToString(), Text = "Hareket - " + b.Id })
                .ToList();
        }

        public async Task<List<SelectListItem>> GetMaterialProcurementsSelectListAsync()
        {
            var baseUrl = _cfg["ApiSettings:BaseUrl"];
            if (string.IsNullOrWhiteSpace(baseUrl))
                throw new Exception("API Url tanımlı değil");
            var url = $"{baseUrl.TrimEnd('/')}/MaterialProcurement/GetAll";
            using var client = _httpClientFactory.CreateClient();

            var httpContext = _httpContextAccessor.HttpContext;
            if (httpContext != null)
            {
                var accessToken = await httpContext.GetTokenAsync("access_token");
                if (!string.IsNullOrEmpty(accessToken))
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                }
            }

            var response = await client.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                return new List<SelectListItem>();
            }

            var json = await response.Content.ReadAsStringAsync();
            var list = JsonConvert.DeserializeObject<List<ResponseMaterialProcurementDto>>(json)
                              ?? new List<ResponseMaterialProcurementDto>();
            return list
                .Select(b => new SelectListItem { Value = b.Id.ToString(), Text = "Tedarik - " + b.Id })
                .ToList();
        }
    }
}
