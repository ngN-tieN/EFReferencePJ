﻿using EFGetStarted.Models;
using Spectre.Console;

namespace EFGetStarted
{
    internal class ProductController
    {
        internal static void AddProduct(Product product)
        {
            
            using var db = new ProductsContext();
            db.Add(product);
            db.SaveChanges();
        }

        internal static void DeleteProduct(Product product)
        {
            using var db = new ProductsContext();
            db.Remove(product);
            db.SaveChanges();
        }

        internal static void UpdateProduct(Product product)
        {
            using var db = new ProductsContext();
            db.Update(product);
            db.SaveChanges();
        }

        internal static List<Product> GetProducts()
        {

            using var db =  new ProductsContext();
            var products = db.Products.ToList();
            return products;
        }

        internal static Product GetProductById(int id)
        {
            using var db = new ProductsContext();
            var product = db.Products.SingleOrDefault(product => product.ProductId.Equals(id));
            return product;

        }

       
    }
}
