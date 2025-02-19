using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SDA_Backend_Project.src.DTO
{
    public class ProductDTO
    {
        //CREATE PRODUCT

        public class CreateProductDto
        {
            public string ProductName { get; set; }
            public string ProductColor { get; set; }
            public string? Description { get; set; }
            public int SKU { get; set; }
            public decimal ProductPrice { get; set; }
            public decimal Weight { get; set; }
            public Guid SubCategoryId { get; set; }
            public string? SubCategoryName { get; set; }
            public string? ProductImage { get; set; }
        }

        //GET ALL RPODUCTS

        public class GetProductDto
        {
            public Guid? SubCategoryId { get; set; }
            public string? SubCategoryName { get; set; }
            public Guid ProductId { get; set; }
            public string ProductName { get; set; }
            public DateTime AddedDate { get; set; }
            public string ProductColor { get; set; }
            public string Description { get; set; }
            public int SKU { get; set; }
            public decimal ProductPrice { get; set; }
            public decimal Weight { get; set; }
            public decimal? AverageRating { get; set; }
            public string? ProductImage { get; set; }
        }

        //UPDATE PRODUCT INFO

        public class UpdateProductInfoDto
        {
            public string ProductName { get; set; }
            public string ProductColor { get; set; }
            public string Description { get; set; }
            public int SKU { get; set; }
            public decimal ProductPrice { get; set; }
            public decimal Weight { get; set; }
            public string? ProductImage { get; set; }
        }
    }
}