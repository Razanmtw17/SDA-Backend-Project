using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static SDA_Backend_Project.src.DTO.SubCategoryDTO;

namespace SDA_Backend_Project.src.DTO
{
    public class CategoryDTO
    {
         public class CategoryCreateDto
        {
            public string CategoryName { get ; set;}
        }
        
        public class CategoryReadDto
        {
            public Guid Id { get; set; }
            public string CategoryName { get; set; }        
            public List<SubCategoryReadDto>? SubCategory { get; set; }
        }

        public class CategoryUpdateDto
        {
            public string CategoryName { get; set; }        
        }
    }
}