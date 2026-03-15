using BusinessManagement.Application.Interfaces.Repositories;
using BusinessManagement.Domain.Entities;
using BusinessManagement.DTO.ProductDTOs;
using BusinessManagement.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessManagement.Persistence.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly BusinessManagementDbContext _context;
        public ProductRepository(BusinessManagementDbContext context)
        {
            _context = context;
        }

        public async Task<AddProductDto> AddProductAsync(AddProductDto dto)
        {
            var entity = new Product
            {
                Name = dto.Name,
                PhotoUrl = dto.PhotoUrl,
                PersonelPrice = dto.PersonelPrice,
                CorporatePrice = dto.CorporatePrice,
                WholesalePrice = dto.WholesalePrice,
                Description = dto.Description
            };
            _context.Products.Add(entity);
            await _context.SaveChangesAsync();
            return dto;
        }

        public Task DeleteProductAsync(int id)
        {
            var entity = _context.Products.Find(id);
            if (entity == null)
            {
                throw new KeyNotFoundException($"Product bulunamadı ID = {id}  (404)");
            }
            _context.Products.Remove(entity);
            return _context.SaveChangesAsync();
        }

        public async Task<List<ResponseProductDto>> GetAllAsync()
        {
            var entities = await _context.Products
                .Select(b => new ResponseProductDto
                {
                    Id = b.Id,
                    Name = b.Name,
                    PhotoUrl = b.PhotoUrl,
                    PersonelPrice = b.PersonelPrice,
                    CorporatePrice = b.CorporatePrice,
                    WholesalePrice = b.WholesalePrice,
                    Description = b.Description
                })
                .ToListAsync();
            return entities;    
        }

        public async Task<UpdateProductDto> UpdateProductAsync(int id, UpdateProductDto dto)
        {
            var entity = await _context.Products.FindAsync(id);
            if (entity == null)
            {
                throw new KeyNotFoundException($"Product bulunamadı ID = {id}  (404)");
            }
            var updatedEntity = new Product
            {
                Id = id,
                Name = dto.Name,
                PhotoUrl = dto.PhotoUrl,
                PersonelPrice = dto.PersonelPrice,
                CorporatePrice = dto.CorporatePrice,
                WholesalePrice = dto.WholesalePrice,
                Description = dto.Description
            };
            _context.Entry(entity).CurrentValues.SetValues(updatedEntity);
            await _context.SaveChangesAsync();
            return dto;
        }
    }
}
