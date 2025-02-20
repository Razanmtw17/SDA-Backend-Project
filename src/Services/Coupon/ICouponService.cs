using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static SDA_Backend_Project.src.DTO.CouponDTO;

namespace SDA_Backend_Project.src.Services.Coupon
{
    public interface ICouponService
    {
         Task<CouponReadDto> CreateOneAsync(CouponCreateDto creaDto);
        Task<List<CouponReadDto>> GetAllAsync();

        Task<CouponReadDto> GetByIdAsync(Guid id);
        Task<bool> DeleteOneAsync(Guid id);
        Task<bool> UpdateOneAsync(Guid id, CouponUpdateDto updateDto);

    }
}