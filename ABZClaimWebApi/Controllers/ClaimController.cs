using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ABZClaimsLibrary.Models;
using ABZClaimsLibrary.RepoAsync;
    
using Microsoft.AspNetCore.Routing.Matching;

namespace ABZClaimWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClaimController : ControllerBase
    {
        IClaimRepoAsync claimRepo;
        public ClaimController(IClaimRepoAsync repo)
        {
            claimRepo = repo;
        }
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            List<Claim> claims = await claimRepo.GetAllClaimAsync();
            return Ok(claims);
        }
        [HttpGet("{claimNo}")]
        public async Task<ActionResult> GetOne(string claimNo)
        {
            try
            {
                Claim claim = await claimRepo.GetClaimByNoAsync(claimNo);
                return Ok(claim);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpPost("{token}")]
        public async Task<ActionResult> Insert(string token, Claim claim)
        {
            try
            {
                await claimRepo.InsertClaimAsync(claim);
                return Created($"api/Claim/{claim.ClaimNo}", claim);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{claimNo}")]
        public async Task<ActionResult> Update(string claimNo, Claim claim)
        {
            try
            {
                await claimRepo.UpdateClaimAsync(claimNo, claim);
                return Ok(claim);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{claimNo}")]
        public async Task<ActionResult> Delete(string claimNo)
        {
            try
            {
                await claimRepo.DeleteClaimAsync(claimNo);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("policy/{policyNo}")]
        public async Task<ActionResult> GetByPolicy(string policyNo)
        {
            try
            {
                List<Claim> claims = await claimRepo.GetClaimsByPolicyNoAsync(policyNo);
                return Ok(claims);
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
                await claimRepo.InsertPolicyAsync(policy);
                // HttpClient client = new HttpClient();
                //await client.PostAsJsonAsync("http://localhost:5189/api/Claim", new { PolicyNo = policy.PolicyNo });
                return Created($"api/Claim/{policy.PolicyNo}", policy);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}

        
       
 


