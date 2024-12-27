using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ABZCustomerQueryLibrary.Repos;
using ABZCustomerQueryLibrary.Models;

namespace ABZCustomerQueryWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QueryResponseController : ControllerBase
    {
        IQueryResponseRepoAsync qrRepo;
        public QueryResponseController(IQueryResponseRepoAsync repo)
        {
            qrRepo = repo;
        }
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            List<QueryResponse> qr = await qrRepo.GetAllQuerysAsync();
            return Ok(qr);
        }
        [HttpGet("{queryID}/{srNo}")]
        public async Task<ActionResult> GetOne(string queryID, string srNo)
        {
            try
            {
                QueryResponse qr = await qrRepo.GetQueryResponseAsync(queryID, srNo);
                return Ok(qr);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpPost("{token}")]
        public async Task<ActionResult> Insert(string token, QueryResponse queryresponse)
        {
            try
            {
                await qrRepo.InsertQueryResponseAsync(queryresponse);
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                return Created($"api/QueryResponse{queryresponse.QueryID}", queryresponse);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{queryID}/{srNo}")]
        public async Task<ActionResult> Update(string queryID, string srNo, QueryResponse queryresponse)
        {
            try
            {
                await qrRepo.UpdateQueryResponseAsync(queryID, srNo,queryresponse);
                return Ok(qrRepo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{queryID}/{srNo}")]
        public async Task<ActionResult> Delete(string queryID, string srNo)
        {
            try
            {
                await qrRepo.DeleteQueryResponseAsync(queryID, srNo);
                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("ByCustomer/{queryID}")]
        
        public async Task<ActionResult> GetByCustomer(string queryID)
        {
            try
            {
                List<QueryResponse> queryResponses = await qrRepo.GetQueryResponseByCustomerQuery(queryID);
                return Ok(queryResponses);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
