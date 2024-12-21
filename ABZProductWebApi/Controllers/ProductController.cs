using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ABZProductLibrary.Models;
using ABZProductLibrary.Repos;

namespace ABZProductWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        IProductRepoAsync productRepo;
        public ProductController(IProductRepoAsync repo)
        {
            productRepo = repo;
        }
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            List<Product> products = await productRepo.GetAllProductsAsync();
            return Ok(products);
        }
        [HttpGet("{productId}")]
        public async Task<ActionResult> GetOne(string productId)
        {
            try
            {
                Product product = await productRepo.GetProductAsync(productId);
                return Ok(product);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpPost]
        public async Task<ActionResult> Insert(Product product)
        {
            try
            {
                await productRepo.InsertProductAsync(product);
                return Created($"api/Product/{product.ProductID}", product);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpPut("{productId}")]
        public async Task<ActionResult> Update(string productId, Product product)
        {
            try
            {
                await productRepo.UpdateProductAsync(productId, product);
                return Ok(product);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{productId}")]
        public async Task<ActionResult> Delete(string productId)
        {
            try
            {
                await productRepo.DeleteProductAsync(productId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
