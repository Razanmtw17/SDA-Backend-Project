using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SDA_Backend_Project.src.Utils
{
    public class PaginationOptions
    {
        public int Limit { get; set; }

        public int Offset { get; set; } = 0;

        public string Search { get; set; } = string.Empty;
        public decimal MinPrice { get; set; } = 0;
        public decimal MaxPrice { get; set; } = 10000;
    }
}