using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SDA_Backend_Project.src.Utils;
using static SDA_Backend_Project.src.DTO.ProductDTO;

namespace SDA_Backend_Project.src.Services.product
{
    public interface IProductService
    {
          //create product
        Task<GetProductDto> CreateProductAsync(CreateProductDto createProductDto);

        //get all products
        Task<List<GetProductDto>> GetAllProductsAsync();

        //get all products in specific subcategory
        Task<List<GetProductDto>> GetProductsBySubCategoryIdAsync(string subCategoryName);

        //get all products by using the search by name & pagination
        Task<List<GetProductDto>> GetAllBySearchAsync(PaginationOptions paginationOptions);

        //get all products by using filter feature
        Task<List<GetProductDto>> GetAllByFilterationAsync(FilterationOptions productf);

        //get all products by using sort feature
        Task<List<GetProductDto>> GetAllBySortAsync(SortOptions sortOption);

        //get all products by using the search by name & pagination & filer & sort
        Task<List<GetProductDto>> GetAllAsync(SearchProcess to_search,Guid? SubCategoryId=null);

        //get product by id
        Task<GetProductDto> GetProductByIdAsync(Guid id);

        //update product info
        Task<GetProductDto> UpdateProductInfoAsync(Guid id, UpdateProductInfoDto product);

        //delete product by id
        Task<bool> DeleteProductByIdAsync(Guid id);
    }
}
