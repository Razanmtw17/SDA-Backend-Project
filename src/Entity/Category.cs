using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SDA_Backend_Project.src.Entity
{
    public class Category
    {
        public Guid Id { get; set; }
        public string CategoryName { get; set; }
        public List<SubCategory>? SubCategory { get; set; }
    }
}