using BusinessManagement.MVC.DTO.TransferDTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessManagement.MVC.Application.Interfaces
{
    public interface ITransferServices
    {
        Task<List<ResultTransferDto>> GetAllTransfersAsync();
        Task<AddTransferDto> AddTransferAsync(AddTransferDto addTransferDto);
        Task<UpdateTransferDto> UpdateTransferAsync(UpdateTransferDto updateTransferDto, int id);
        Task DeleteTransferAsync(int id);
    }
}
