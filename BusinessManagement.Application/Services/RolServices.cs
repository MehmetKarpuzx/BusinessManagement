using BusinessManagement.Application.Interfaces;
using BusinessManagement.Application.Interfaces.Repositories;
using BusinessManagement.DTO.RolDTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessManagement.Application.Services
{
    public class RolServices : IRolServices
    {
        private readonly IRolRepository _rolRepository;
        public RolServices(IRolRepository rolRepository)
        {
            _rolRepository = rolRepository;
        }

        public async Task<List<ResponseRolDto>> GetAllAsync()
        {
            return await _rolRepository.GetAllAsync();
        }

        public async Task<AddRolDto> AddAsync(AddRolDto dto)
        {
            dto.CreatedDate = DateTime.Now;
            dto.IsActive = true;
            return await _rolRepository.AddAsync(dto);
        }

        public async Task<UpdateRolDto> UpdateAsync(int id, UpdateRolDto dto)
        {
            return await _rolRepository.UpdateAsync(id, dto);
        }

        public async Task DeleteAsync(int id)
        {
            await _rolRepository.DeleteAsync(id);
        }
    }
}
