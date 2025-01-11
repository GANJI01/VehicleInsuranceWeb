using ABZProductLibrary.Models;
using ABZProductLibrary.Repos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace ABZProductWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
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
        [HttpPost("{token}")]
        public async Task<ActionResult> Insert(string token,Product product)
        {
            try
            {
                await proRepo.InsertProductAsync(product);
                HttpClient client = new HttpClient();

                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

                await client.PostAsJsonAsync("http://localhost:5273/api/Proposal/Product/", new { ProductID = product.ProductID });
                //await client.PostAsJsonAsync("http://abzproposalwebapi-chanad.azurewebsites.net/api/proposal/product/", new { ProductID = product.ProductID });
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