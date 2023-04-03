using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoeStore.Entities
{
    public class CartProduct
    {
        public int Quantity = 1;
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double? Price { get; set; }
        public byte[] Image { get; set; }

        public CartProduct(int quantity, int productId, string productName, byte[] image, double price =0)
        {
            Quantity = quantity;
            ProductId = productId;
            ProductName = productName;
            Price = price;
            Image = image;
        }
        public static bool operator ==(CartProduct first,CartProduct second)
        {
            if (first.ProductId == second.ProductId) return true;
            return false;
        }
        public static bool operator !=(CartProduct first, CartProduct second)
        {
            return first == second;
        }

    }
}