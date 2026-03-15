using BusinessManagement.DTO.TransferDTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessManagement.Application.Interfaces.Repositories
{
    public interface ITransferRepository
    {
        Task<List<ResponseTransferDto>> GetAllAsync();
        Task<AddTransferDto> AddTransferAsync(AddTransferDto transferDto);
        Task<UpdateTransferDto> UpdateTransferAsync(int id, UpdateTransferDto transferDto);
        Task DeleteTransferAsync(int id);
    }
}
