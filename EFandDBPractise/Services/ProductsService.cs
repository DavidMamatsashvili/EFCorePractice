using System.Reflection.Metadata.Ecma335;
using EFandDBPractise.Data;
using EFandDBPractise.DTO;
using EFandDBPractise.Models;
using EFandDBPractise.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFandDBPractise.Services
{
    public class ProductsService : IProductService
    {
        public EFContext context { get; set; }
        public ProductsService(EFContext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await context.Products.ToListAsync();
        }

        public async Task<Product> GetProductById(int id)
        {
            var product = await context.Products.FirstOrDefaultAsync(product => product.ProductId== id);
            return product!;
        }

        public async Task<ProductDto> PostProduct(ProductDto product)
        {
            Product newproduct = new Product()
            {
                ProductName = product.ProductName,
                BrandId = product.BrandId,
                CategoryId = product.CategoryId,
                ModelYear = product.ModelYear,
                Price = product.Price,
            };
            context.Products.Add(newproduct);
            await context.SaveChangesAsync();
            return product;
        }

        public async Task UpdateProduct(int id, ProductDto newproduct)
        {
            var ans = await context.Products.FindAsync(id);
            Product updatedproduct = new Product()
            {
                ProductId = id,
                ProductName = newproduct.ProductName,
                BrandId = newproduct.BrandId,
                CategoryId = newproduct.CategoryId,
                ModelYear = newproduct.ModelYear,
                Price = newproduct.Price,
            };

            context.Products.Update(updatedproduct);
            await context.SaveChangesAsync();
        }

        public async Task<bool> DeleteProduct(int id) 
        {
            var product = await context.Products.FindAsync(id);
            if (product == null) return false;
            context.Remove(product);
            context.SaveChanges();
            return true;
        }
    }
}
