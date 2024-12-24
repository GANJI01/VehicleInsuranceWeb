using ABZProposalLibrary.Models;
using ABZProposalLibrary.RepoAsync;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ABZProposalWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProposalController : ControllerBase
    {
        IProposalRepoAsync proRepo;
        public ProposalController(IProposalRepoAsync repo)
        {
            proRepo = repo;
        }
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            List<Proposal> proposals = await proRepo.GetAllProposalsAsync();
            return Ok(proposals);
        }
        [HttpGet("{proposalNo}")]
        public async Task<ActionResult> GetOne(string proposalNo)
        {
            try
            {
                Proposal prop = await proRepo.GetProposalByIdAsync(proposalNo);
                return Ok(prop);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpPut("{proposalNo}")]
        public async Task<ActionResult> Update(string proposalNo, Proposal proposal)
        {
            try
            {
                await proRepo.UpdateProposalAsync(proposalNo, proposal);
                return Ok(proposal);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{proposalNo}")]
        public async Task<ActionResult> Delete(string proposalNo)
        {
            try
            {
                await proRepo.DeleteProposalAsync(proposalNo);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<ActionResult> Insert(Proposal proposal)
        {
            try
            {
                await proRepo.InsertProposalAsync(proposal);
                HttpClient client = new HttpClient();
                 await client.PostAsJsonAsync("http://localhost:5007/api/Policy/Proposal", new { ProposalNo = proposal.ProposalNo });
                 //await client.PostAsJsonAsync("http://abzpolicywebapi-hana.azurewebsites.net/api/policy/Proposal", new { ProposalNo = proposal.ProposalNo });

                return Created($"api/Proposal/{proposal.ProposalNo}", proposal);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("Agent")]
        public async Task<ActionResult> InsertAgentAsync(Agent agent)
        {
            await proRepo.InsertAgentAsync(agent);
            return Created();
        }
        [HttpPost("Customer")]
        public async Task<ActionResult> InsertCustomerAsync(Customer customer)
        {
            await proRepo.InsertCustomerAsync(customer);
            return Created();
        }
        [HttpPost("Product")]
        public async Task<ActionResult> InsertProductAsync(Product product)
        {
            await proRepo.InsertProductAsync(product);
            return Created();
        }
        [HttpPost("Vehicle")]
        public async Task<ActionResult> InsertVehicleAsync(Vehicle vehicle)
        {
            await proRepo.InsertVehicleAsync(vehicle);
            return Created();
        }

        [HttpGet("ByVehicle/{regNo}")]
        public async Task<ActionResult> GetByVehicle(string regNo)
        {
            try
            {
                List<Proposal> prop = await proRepo.GetProposalByVehicleAsync(regNo);
                return Ok(prop);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpGet("ByAgent/{agentId}")]
        public async Task<ActionResult> GetByAgent(string agentId)
        {
            try
            {
                List<Proposal> prop = await proRepo.GetProposalByAgentAsync(agentId);
                return Ok(prop);
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
                List<Proposal> prop = await proRepo.GetProposalByCustomerAsync(customerId);
                return Ok(prop);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpGet("ByProduct/{productId}")]
        public async Task<ActionResult> GetByProduct(string productId)
        {
            try
            {
                List<Proposal> prop = await proRepo.GetProposalByProductAsync(productId);
                return Ok(prop);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}