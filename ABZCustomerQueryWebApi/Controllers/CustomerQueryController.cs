using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ABZCustomerQueryLibrary.Models;
using ABZCustomerQueryLibrary.Repos;

namespace ABZCustomerQueryWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerQueryController : ControllerBase
    {
        ICustomerQueryRepoAsync cusqueRepo;
        public CustomerQueryController(ICustomerQueryRepoAsync repo)
        {
            cusqueRepo = repo;
        }
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            List<CustomerQuery> customerQueries=await cusqueRepo.GetAllCustomerQueriesAsync();
            return Ok(customerQueries);
        }
        [HttpGet("{queryId}")]
        public async Task<ActionResult> GetOne(string queryId)
        {
            try
            {
                CustomerQuery customerQuery = await cusqueRepo.GetCustomerQueryAsync(queryId);
                return Ok(customerQuery);

            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpGet("ByCustomer/{customerId}")]
        public async Task<ActionResult> GetByCustomer(string customerId)
        {
            try
            {
                List<CustomerQuery> customerQueries=await cusqueRepo.GetCustomerQueryByCustomerAsync(customerId);
                return Ok(customerQueries);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        

    }
}
