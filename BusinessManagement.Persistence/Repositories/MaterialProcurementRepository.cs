using BusinessManagement.Application.Interfaces.Repositories;
using BusinessManagement.Domain.Entities;
using BusinessManagement.DTO.MaterialProcurementDTOs;
using BusinessManagement.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessManagement.Persistence.Repositories
{
    public class MaterialProcurementRepository : IMaterialProcurementRepository
    {
        private readonly BusinessManagementDbContext _context;
        public MaterialProcurementRepository(BusinessManagementDbContext context)
        {
            _context = context;
        }

        public async Task<AddMaterialProcurementDto> AddMaterialProcurementAsync(AddMaterialProcurementDto dto)
        {
            var entity = new MaterialProcurement
            {
                SupplierId = dto.SupplierId,
                ProcurementDate = dto.ProcurementDate,
                InvoiceNo = dto.InvoiceNo,
                MaterialId = dto.MaterialId,
                Amount = dto.Amount,
                UnitPrice = dto.UnitPrice,
                TotalPrice = dto.TotalPrice,
                PaidPrice = dto.PaidPrice,
                RemainderPrice = dto.RemainderPrice,
                Description = dto.Description
            };
            _context.MaterialProcurements.Add(entity);
            await _context.SaveChangesAsync();
            return dto;
        }

        public Task DeleteMaterialProcurementAsync(int id)
        {
            var entity = _context.MaterialProcurements.Find(id);
            if (entity == null)
            {
                throw new KeyNotFoundException($"MaterialProcurement bulunamadı ID = {id}  (404)");
            }
            _context.MaterialProcurements.Remove(entity);
            return _context.SaveChangesAsync();
        }

        public async Task<List<ResponseMaterialProcurementDto>> GetAllAsync()
        {
            var entities = await _context.MaterialProcurements
                .Select(b => new ResponseMaterialProcurementDto
                {
                    Id = b.Id,
                    SupplierId = b.SupplierId,
                    ProcurementDate = b.ProcurementDate,
                    InvoiceNo = b.InvoiceNo,
                    MaterialId = b.MaterialId,
                    Amount = b.Amount,
                    UnitPrice = b.UnitPrice,
                    TotalPrice = b.TotalPrice,
                    PaidPrice = b.PaidPrice,
                    RemainderPrice = b.RemainderPrice,
                    Description = b.Description
                })
                .ToListAsync();
            return entities;    
        }

        public async Task<UpdateMaterialProcurementDto> UpdateMaterialProcurementAsync(int id, UpdateMaterialProcurementDto dto)
        {
            var entity = await _context.MaterialProcurements.FindAsync(id);
            if (entity == null)
            {
                throw new KeyNotFoundException($"MaterialProcurement bulunamadı ID = {id}  (404)");
            }
            var updatedEntity = new MaterialProcurement
            {
                Id = id,
                SupplierId = dto.SupplierId,
                ProcurementDate = dto.ProcurementDate,
                InvoiceNo = dto.InvoiceNo,
                MaterialId = dto.MaterialId,
                Amount = dto.Amount,
                UnitPrice = dto.UnitPrice,
                TotalPrice = dto.TotalPrice,
                PaidPrice = dto.PaidPrice,
                RemainderPrice = dto.RemainderPrice,
                Description = dto.Description
            };
            _context.Entry(entity).CurrentValues.SetValues(updatedEntity);
            await _context.SaveChangesAsync();
            return dto;
        }
    }
}
