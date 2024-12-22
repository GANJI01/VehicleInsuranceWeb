using ABZProductLibrary.Models;
using ABZProductLibrary.Repos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ABZProductWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ProductController : ControllerBase
    {
        IProductRepoAsync proRepo;
        public ProductController(IProductRepoAsync repo)
        {
            proRepo = repo;
        }
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            List<Product> products = await proRepo.GetAllProductsAsync();
            return Ok(products);
        }
        [HttpGet("{productID}")]
        public async Task<ActionResult> GetOne(string productID)
        {
            try
            {
                Product product = await proRepo.GetProductAsync(productID);
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
                await proRepo.InsertProductAsync(product);
                HttpClient client = new HttpClient();
                //await client.PostAsJsonAsync("http://localhost:5273/api/Proposal/Product/", new { ProductID = product.ProductID });
                await client.PostAsJsonAsync("http://abzproposalwebapi.azurewebsites.net/api/proposal/product", new { ProductID = product.ProductID });
                return Created($"api/Product/{product.ProductID}", product);

            }
            catch (Exception ex)
            {
                {
                    return BadRequest(ex.Message);
                }
            }

        }
        [HttpPut("{productID}")]
        public async Task<ActionResult> Update(string productID, Product product)
        {
            try
            {
                await proRepo.UpdateProductAsync(productID, product);
                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{productID}")]
        public async Task<ActionResult> Delete(string productID)
        {
            try
            {
                await proRepo.DeleteProductAsync(productID);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}