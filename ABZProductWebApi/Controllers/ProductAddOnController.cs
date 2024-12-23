using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ABZProductLibrary.Models;
using ABZProductLibrary.Repos;

namespace ABZProductWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductAddOnController : ControllerBase
    {
        IProductAddonRepoAsync productaddRepo;
        public ProductAddOnController(IProductAddonRepoAsync repo)
        {
            productaddRepo = repo;
        }
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            List<ProductAddon> productAddons = await productaddRepo.GetAllProductAddonAsync();
            return Ok(productAddons);
        }
        [HttpGet("{productID}/{addonId}")]
        public async Task<ActionResult> Getone(string productID, string addonId)
        {
            try
            {
                ProductAddon productAddon = await productaddRepo.GetProductAddonAsync(productID, addonId);
                return Ok(productAddon);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpPost]
        public async Task<ActionResult> Insert(ProductAddon productAddon)
        {
            try
            {
                await productaddRepo.InsertProductAddonAsync(productAddon);
                return Created($"api/ProductAddon{productAddon.ProductID}", productAddon);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{productID}/{addonId}")]
        //string productID, string addonId, ProductAddon productAddon
        public async Task<ActionResult> Update(string productID, string addonId, ProductAddon productAddon)
        {
            try
            {
                await productaddRepo.UpdateProductAddonAsync(productID, addonId, productAddon);
                return Ok(productAddon);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{productID}/{addonId}")]
        public async Task<ActionResult> Delete(string productID, string addonId)
        {
            try
            {
                await productaddRepo.DeleteProductAddonAsync(productID, addonId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("ByProduct/{productID}")]
        public async Task<ActionResult> ByProduct(string productID)
        {
            try
            {
                List<ProductAddon> productAddon = await productaddRepo.GetProductAddonByProductAsync(productID);
                return Ok(productAddon);

            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

    }

}
