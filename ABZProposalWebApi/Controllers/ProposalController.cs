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
        [HttpGet("{proposalId}")]
        public async Task<ActionResult> GetOne(string proposalId)
        {
            try
            {
                Proposal prop = await proRepo.GetProposalByIdAsync(proposalId);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpPut("{proposalId}")]
        public async Task<ActionResult> Update(string proposalId, Proposal proposal)
        {
            try
            {
                await proRepo.UpdateProposalAsync(proposalId, proposal);
                return Ok(proposal);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{proposalId}")]
        public async Task<ActionResult> Delete(string proposalId)
        {
            try
            {
                await proRepo.DeleteProposalAsync(proposalId);
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
                return Created($"api/Proposal/{proposal.ProposalID}",proposal);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("ByVehicle{regNo}")]
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
        [HttpGet("ByAgent{agentId}")]
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
        [HttpGet("ByCustomer{customerId}")]
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
        [HttpGet("ByProduct{productId}")]
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

