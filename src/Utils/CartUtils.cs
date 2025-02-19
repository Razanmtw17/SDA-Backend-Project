using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SDA_Backend_Project.src.Entity;

namespace SDA_Backend_Project.src.Utils
{
    public class CartUtils
    {
        public static string ThereIsLowStockProduct(Cart cart)
        {
            var lowStockProduct = cart.CartDetails.FirstOrDefault(p => p.Product.SKU < p.Quantity);
            if (lowStockProduct != null)
            {
                return lowStockProduct.Product.ProductName;
            }
            return "";
        }
        public static void CalculateCartFields(Cart cart)//must be called after adding or removing products
        {
            cart.CartQuantity = cart.CartDetails.Sum(cd => cd.Quantity);
            cart.TotalPrice = cart.CartDetails.Sum(cd => cd.Subtotal);
        }
    }
}