using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ABZPolicyLibrary.Models;
using ABZPolicyLibrary.Repos;
using Microsoft.AspNetCore.Http.HttpResults;

namespace ABZPolicyWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PolicyController : ControllerBase
    {
        IPolicyRepoAsync policyRepo;
        public PolicyController(IPolicyRepoAsync repo)
        {
            policyRepo = repo;
        }
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            List<Policy> policies = await policyRepo.GetAllPoliciesAsync();
            return Ok(policies);
        }
        [HttpGet("{policyNo}")]
        public async Task<ActionResult> GetOne(string policyNo)
        {
            try
            {
                Policy policy = await policyRepo.GetPolicyAsync(policyNo);
                return Ok(policy);

            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpPost]
        public async Task<ActionResult> Insert(Policy policy)
        {
            try
            {
                await policyRepo.InsertPolicyAsync(policy);
                HttpClient client = new HttpClient();
                await client.PostAsJsonAsync("http://localhost:5189/api/Policy/Claim/", new { PolicyNo = policy.PolicyNo });
                return Created($"api/Policy/{policy.PolicyNo}", policy);

            }
            catch (Exception ex)
            {
                {
                    return BadRequest(ex.Message);
                }
            }
        }

        [HttpPut("{policyNo}")]
        public async Task<ActionResult> Update(string policyNo, Policy policy)
        {
            try
            {
                await policyRepo.UpdatePolicyAsync(policyNo, policy);
                return Ok(policy);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{policyNo}")]
        public async Task<ActionResult> Delete(string policyNo)
        {
            try
            {
                await policyRepo.DeletePolicyAsync(policyNo);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("ByProposal/{proposalNo}")]
        public async Task<ActionResult> GetByProposalAsync(string proposalNo)
        {
            try
            {
                List<Policy> polycies = await policyRepo.GetPolicyByProposalAsync(proposalNo);
                return Ok(polycies);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);

            }
        }

             [HttpPost("proposal")]
            public async Task<ActionResult> InsertProposalAsync(Proposal proposal)
            {
                try
                {
                    await policyRepo.InsertProposalAsync(proposal);
                    //HttpClient client = new HttpClient();
                    //await client.PostAsJsonAsync("http://localhost:5007/api/PolicyAddon/Policy", new {ProposalNo = proposal.ProposalNo});
                    return Created();
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }

            }
    }
}
