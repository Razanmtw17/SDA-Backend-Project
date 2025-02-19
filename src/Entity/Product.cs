using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SDA_Backend_Project.src.Entity
{
    public class Product
    {
        public Guid SubCategoryId { get; set; }
        
        public string? SubCategoryName { get; set; }

        public Guid ProductId { get; set; }
        public string? ProductName { get; set; }

        public DateTime AddedDate {get;set;} = DateTime.UtcNow; // An error will occur in post man if the timestamp not in utc

        public string? ProductImage { get; set; } //, It will be added during front-end 

        public string? ProductColor { get; set; }

        public string? Description { get; set; }

        public int SKU { get; set; }

        public decimal ProductPrice { get; set; }


        public decimal Weight { get; set; }


        public decimal? AverageRating { get; set; }
    }
}