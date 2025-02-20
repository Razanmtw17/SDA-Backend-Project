using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SDA_Backend_Project.src.Entity;
using SDA_Backend_Project.src.Services.product;
using SDA_Backend_Project.src.Utils;
using static SDA_Backend_Project.src.DTO.ProductDTO;

namespace SDA_Backend_Project.src.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]

    public class ProductsController : ControllerBase
    {
         protected readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        //get all products by using the search by name & pagination & filer & sort
        [HttpGet]
        public async Task<ActionResult<List<GetProductDto>>> GetAllProducts(
            [FromQuery] SearchProcess to_search
        )
        {
            var products = await _productService.GetAllAsync(to_search);
            return Ok(products);
        }
        [HttpGet("productsBySubcategory/{subCategoryName}")]
        public async Task<ActionResult<List<GetProductDto>>> GetProductsBySubCategoryIdAsync(string subCategoryName)
        {
            var products = await _productService.GetProductsBySubCategoryIdAsync(subCategoryName);
            return Ok(products);
        }
        //get all products by using fiter feature
        [HttpGet("filter")]
        public async Task<ActionResult<List<Product>>> FilterProducts(
            [FromQuery] FilterationOptions pf
        )
        {
            var products = await _productService.GetAllByFilterationAsync(pf);
            return Ok(products);
        }

        //get all products using the search by name & pagination
        [HttpGet("search")]
        public async Task<ActionResult<List<GetProductDto>>> GetAllProductsBySearch(
            [FromQuery] PaginationOptions paginationOptions
        )
        {
            var productsList = await _productService.GetAllBySearchAsync(paginationOptions);
            return Ok(productsList);
        }

        //get all products by using sort feature
        [HttpGet("sort")]
        public async Task<ActionResult<List<GetProductDto>>> GetAllBySort(
            [FromQuery] SortOptions sortOption
        )
        {
            var products = await _productService.GetAllBySortAsync(sortOption);
            return Ok(products);
        }

        //get product by id

        [HttpGet("{productId}")]
        public async Task<ActionResult<GetProductDto>> GetProductById(Guid productId)
        {
            return Ok(await _productService.GetProductByIdAsync(productId));
        }

        //add product, probably will be deleted in the future, the endpoint in the subcategory will be used instead
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<GetProductDto>> CreateProduct(CreateProductDto productDto)
        {
            var newProduct = await _productService.CreateProductAsync(productDto);
            return CreatedAtAction(
                nameof(CreateProduct),
                new { id = newProduct.ProductId },
                newProduct
            );
        }

        //delete a product,probably will be deleted in the future, the endpoint in the subcategory will be used instead

        [HttpDelete("{productId}")]
        [Authorize(Roles = "Admin")] //didn't test it yet
        public async Task<ActionResult> DeleteProductById([FromRoute] Guid productId)
        {
            var toDelete = await _productService.DeleteProductByIdAsync(productId);
            return Ok(toDelete);
        }

        //update product info, probably will be deleted in the future, the endpoint in the subcategory will be used instead
        [HttpPut("{productId}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<GetProductDto>> UpdateProductInfo(
            Guid productId,
            UpdateProductInfoDto productInfoDto
        )
        {
            var updatedInfo = await _productService.UpdateProductInfoAsync(
                productId,
                productInfoDto
            );
            return Ok(updatedInfo);
        }
    }
}
