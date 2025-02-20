using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SDA_Backend_Project.src.Utils;
using static SDA_Backend_Project.src.DTO.SubCategoryDTO;

namespace SDA_Backend_Project.src.Services.SubCategory
{
    public interface ISubCategoryService
    {
          Task<SubCategoryReadDto> CreateOneAsync(SubCategoryCreateDto newSubCategory);
        Task<List<SubCategoryReadDto>> GetAllAsync();
        Task<List<SubCategoryReadDto>>GetAllBySearchAsync(PaginationOptions paginationOptions);
        Task<SubCategoryReadDto?> GetSubCategoryByIdAsync(Guid subCategoryId);
        Task<bool> DeleteOneAsync(Guid subCategoryId);
        Task<bool> UpdateOneAsync(Guid subCategoryId, SubCategoryUpdateDto updateDto);

    }
}