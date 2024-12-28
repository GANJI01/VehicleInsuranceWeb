using ABZCustomerQueryLibrary.Repos;
using ABZCustomerQueryLibrary.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ABZCustomerQueryLibrary.Repos;

namespace ABZCustomerQueryWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CustomerQueryController : ControllerBase
    {
        ICustomerQueryRepoAsync cqRepo;
        public CustomerQueryController(ICustomerQueryRepoAsync repo)
        {
            cqRepo = repo;
        }
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            List<CustomerQuery> cqr = await cqRepo.GetAllCustomerQueriesAsync();
            return Ok(cqr);
        }
        [HttpGet("{queryId}")]
        public async Task<ActionResult> GetOne(string queryId)
        {
            try
            {
                CustomerQuery cqr = await cqRepo.GetCustomerQueryAsync(queryId);
                return Ok(cqr);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpPost("{token}")]
        public async Task<ActionResult> Insert(string token, CustomerQuery customerquery)
        {
            try
            {
                await cqRepo.InsertCustomerQueryAsync(customerquery);
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                //  await client.PostAsJsonAsync("http://localhost:5058/api/CustomerQuery/", new { QueryID = customerQuery.QueryID });
                await client.PostAsJsonAsync("https://abzquerywebapi-chanad.azurewebsites.net/api/CustomerQuery/", new { QueryID = customerquery.QueryID });
                return Created($"api/CustomerQuery/{customerquery.QueryID}", customerquery);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{queryId}")]
        public async Task<ActionResult> Update(string queryId, CustomerQuery customerquery)
        {
            try
            {
                await cqRepo.UpdateCustomerQueryAsync(queryId, customerquery);
                return Ok(customerquery);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{queryId}")]
        public async Task<ActionResult> Delete(string queryId)
        {
            try
            {
                await cqRepo.DeleteCustomerQueryAsync(queryId);
                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("Customer")]
        public async Task<ActionResult> InsertCustomer(Customer customer)
        {
            try
            {
                await cqRepo.InsertCustomerAsync(customer);
                return Created();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        //GetCustomerQueryByCustomerAsync
        [HttpGet("ByCustomer/{customerId}")]

        public async Task<ActionResult> GetByCustomer(string customerId)
        {
            try
            {
                List<CustomerQuery> customerQueries = await cqRepo.GetCustomerQueryByCustomerAsync(customerId);
                return Ok(customerQueries);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}