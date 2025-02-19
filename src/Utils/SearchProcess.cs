using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace SDA_Backend_Project.src.Utils
{
    public class SearchProcess
    {
        /*first: user will search on a product name:
        NOTE : It'll also shows the result based on the products descreption
        */
        public string Search { get; set; } = string.Empty;

        //second: user will filter the product based on specific criteria


        public string? Name { get; set; }

        // public string? Color { get; set; }
        public List<string>? Colors { get; set; } = new List<string>();

        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }

        //third: user will sort the prodcut based on sku,price,added date,and high reviews,by asc or desc

        public SortOrder SortOrder { get; set; } = SortOrder.Ascending; // the enum is defined in sortOptions class
        public string SortBy { get; set; } = "price";

        //fourth: user will implmenet pagination

        public int Limit { get; set; } = 100;

        public int Offset { get; set; } = 0;
    }
}