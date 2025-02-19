using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SDA_Backend_Project.src.Entity
{
    public class Cart
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public List<CartDetails> CartDetails { get; set; }// a list contains all the products in the cart with their quantity and subtotal
        public int CartQuantity { get; set; }
        public decimal TotalPrice { get; set; }
    }
}