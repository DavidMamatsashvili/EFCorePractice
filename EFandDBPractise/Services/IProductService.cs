using EFandDBPractise.DTO;
using EFandDBPractise.Models;
using Microsoft.AspNetCore.Mvc;

namespace EFandDBPractise.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllProducts();
        Task<Product> GetProductById(int id);
        Task<ProductDto> PostProduct(ProductDto product);
        Task<bool> UpdateProduct(int id, ProductDto product);
        Task<bool> DeleteProduct(int id);
    }
}
