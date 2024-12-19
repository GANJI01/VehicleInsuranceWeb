using ABZAgentLibrary.Models;
using ABZAgentLibrary.Repos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ABZAgentWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgentController : ControllerBase
    {
        IAgentRepoAsync agentRepo;
        public AgentController(IAgentRepoAsync ageRepo)
        {
            agentRepo = ageRepo;
        }
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            List<Agent> agents = await agentRepo.GetAllAgentsAsync();
            return Ok(agents);
        }
    
        [HttpGet("{agentId}")]
        public async Task<ActionResult> GetOne(string agentId)
        {
            try
            {
                Agent agent = await agentRepo.GetAgentByIDAsync(agentId);
                return Ok(agent);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpPost]
        public async Task<ActionResult> Insert(Agent agent)
        {
            try
            {
                await agentRepo.InsertAgentAsync(agent);
                return Created($"api/Agent{agent.AgentID}",agent);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{agentId}")]
        public async Task<ActionResult> Update(string agentId, Agent agent)
        {
            try
            {
                await agentRepo.UpdateAgentAsync(agentId, agent);
                return Ok(agent);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{agentId}")]
        public async Task<ActionResult> Delete(string agentId)
        {
            try
            {
                await agentRepo.DeleteAgentAsync(agentId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}