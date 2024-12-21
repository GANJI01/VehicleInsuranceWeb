using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ABZCustomerLibrary.Models;
using ABZCustomerLibrary.RepoAsync;

namespace ABZCustomerWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        ICustomerRepoAsync custRepo;
        public CustomerController(ICustomerRepoAsync repo)
        {
            custRepo = repo;
        }
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            List<Customer> customer = await custRepo.GetAllCustomersAsync();
            return Ok(customer);
        }
        [HttpGet("{customerId}")]
        public async Task<ActionResult> GetOne(string customerId)
        {
            try
            {
                Customer cust = await custRepo.GetCustomerByIdAsync(customerId);
                return Ok(cust);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpPost]
        public async Task<ActionResult> Insert(Customer customer)
        {
            try
            {
                await custRepo.InsertCustomerAsync(customer);
                HttpClient client = new HttpClient();
                HttpClient client2 = new HttpClient();
                await client2.PostAsJsonAsync("http://localhost:5083/api/Vehicle/Customer/", new { customerId = customer.CustomerID });
                await client.PostAsJsonAsync("http\"claimNo\": \"CL9\",\r\n\"claimDate\": \"2024-12-19T09:59:53.448Z\",\r\n\"policyNo\": \"19\",\r\n\"incidentDate\": \"2024-12-19T09:59:53.448Z\",\r\n\"incidentLocation\": \"Banglore\",\r\n\"incidentDescription\": \"Descriptions\",\r\n\"claimAmount\": 10001,\r\n\"surveyorName\": \"SureshReddy\",\r\n\"surveyorPhone\": \"7894561320\",\r\n\"surveyDate\": \"2024-12-19T09:59:53.448Z\",\r\n\"surveyDescription\": \"Hii\",\r\n\"claimStatus\": \"A\"://localhost:5273/api/Proposal/Customer/", new { customerId = customer.CustomerID });
                return Created($"api/Customer/{customer.CustomerID}", customer);
                
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpPut("{customerId}")]
        public async Task<ActionResult> Update(string customerId, Customer customer)
        {
            try
            {
                await custRepo.UpdateCustomerAsync(customerId, customer);
                return Ok(customer);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{customerId}")]
        public async Task<ActionResult> Delete(string customerId)
        {
            try
            {
                await custRepo.DeleteCustomerAsync(customerId);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
