using System.Reflection.Metadata.Ecma335;
using EFandDBPractise.DTO;
using EFandDBPractise.Models;
using EFandDBPractise.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EFandDBPractise.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        public IProductService ProductService { get; set; }
        public ProductsController(IProductService productService)
        {
            this.ProductService = productService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllProducts()
        {
            var ans = await ProductService.GetAllProducts();
            if (ans == null)
                return NotFound();
            return Ok(ans);
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var product = await ProductService.GetProductById(id);
            if(product == null) return NotFound();
            return Ok(product);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateProduct([FromBody]ProductDto product)
        {
            var newproduct = await ProductService.PostProduct(product);
            if (newproduct == null) return NotFound();
            return CreatedAtAction(nameof(GetAllProducts), newproduct);
        }

        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var result = await ProductService.DeleteProduct(id);
            if(result==false) return NotFound();
            return NoContent();
        }

        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody]ProductDto product) 
        {
            try
            {
                await ProductService.UpdateProduct(id, product);
                return NoContent();
            }
            catch (Exception ex) 
            {
                return NotFound(ex.Message);
            }
        }
    }
}
