using BusinessManagement.DTO.UnitDTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessManagement.Application.Interfaces.Repositories
{
    public interface IUnitRepository
    {
        Task<List<ResponseUnitDto>> GetAllAsync();
        Task<AddUnitDto> AddUnitAsync(AddUnitDto unitDto);
        Task<UpdateUnitDto> UpdateUnitAsync(int id, UpdateUnitDto unitDto);
        Task DeleteUnitAsync(int id);
    }
}
