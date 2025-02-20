using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static SDA_Backend_Project.src.DTO.PaymentDTO;

namespace SDA_Backend_Project.src.Services.Payment
{
    public interface IPaymentService
    {
          Task<PaymentReadDto> CreateOneAsync(PaymentCreateDto createDto);
        Task<List<PaymentReadDto>> GetAllAsync();
        Task<PaymentReadDto> GetByIdAsync(Guid PaymentId);
        Task<bool> DeleteOneAsync(Guid PaymentId);
        Task<bool> UpdateOneAsync(Guid PaymentId, PaymentUpdateDto updateDto);
    }
}