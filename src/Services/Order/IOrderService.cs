using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SDA_Backend_Project.src.Utils;
using static SDA_Backend_Project.src.DTO.OrderDTO;

namespace SDA_Backend_Project.src.Services.Order
{
    public interface IOrderService
    {
         Task<OrderReadDTO> CreateOneAsync(OrderCreateDTO createDTO);
        Task<List<OrderReadDTO>> GetAllAsync(PaginationOptions paginationOptions);
        Task<OrderReadDTO> GetByIdAsync(Guid id);
        Task<List<OrderReadDTO>> GetByUserIdAsync(Guid userId, PaginationOptions paginationOptions);
        Task<List<OrderReadDTO>> GetHistoryByUserIdAsync(Guid userId, PaginationOptions paginationOptions);
        Task<bool> DeleteOneAsync(Guid id);

        Task<bool> UpdateOneAsync(Guid id, OrderUpdateDTO updateDTO);
    }
}