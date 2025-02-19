using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SDA_Backend_Project.src.Entity;
using static SDA_Backend_Project.src.DTO.ProductDTO;

namespace SDA_Backend_Project.src.DTO
{
    public class SubCategoryDTO
    {
        public class SubCategoryCreateDto
        {
            public string Name { get ; set;}
            public Guid CategoryId { get ; set;}
            public List <Product>? Products { get; set; }
        }
  
        public class SubCategoryReadDto
        {
            public Guid SubCategoryId { get; set; }
            public string Name { get; set; }
            public Guid CategoryId{ get; set; }
            public string? CategoryName { get; set; }
            public List<GetProductDto>? Products { get; set; }
        }

        public class SubCategoryUpdateDto
        {
            public string Name{ get; set; }
            public List<UpdateProductInfoDto>? Products { get; set; }

        }
    }
}