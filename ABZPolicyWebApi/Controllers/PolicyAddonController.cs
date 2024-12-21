using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ABZPolicyLibrary.Models;
using ABZPolicyLibrary.Repos;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace ABZPolicyWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PolicyAddonController : ControllerBase
    {
        IPolicyAddonRepoAsync poliaddRepo;
        public PolicyAddonController(IPolicyAddonRepoAsync repo)
        {
            poliaddRepo = repo;
        }
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            List<PolicyAddon> policyAddons = await poliaddRepo.GetAllPolicyAddonAsync();
            return Ok(policyAddons);
        }
        [HttpGet("{policyNo}/{addonId}")]
        public async Task<ActionResult> GetOne(string policyNo, string addonId)
        {
            try
            {
                PolicyAddon policyAddon = await poliaddRepo.GetPolicyAddonAsync(policyNo, addonId);
                return Ok(policyAddon);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpPost]
        public async Task<ActionResult> Insert(PolicyAddon policyAddon)
        {
            try
            {
                await poliaddRepo.InsertPolicyAddonAsync(policyAddon);
                return Created($"api/PolicyAddon{policyAddon.PolicyNo}", policyAddon);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{policyNo}/{addonId}")]
        public async Task<ActionResult> Update(string policyNo, string addonId, PolicyAddon policyAddon)
        {
            try
            {
                await poliaddRepo.UpdatePolicyAddonAsync(policyNo, addonId, policyAddon);
                return Ok(policyAddon);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{policyNo}/{addonId}")]
        public async Task<ActionResult> Delete(string policyNo, string addonId)
        {
            try
            {
                await poliaddRepo.DeletePolicyAddonAsync(policyNo, addonId);
                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("ByPolicy/{policyNo}")]
        public async Task<ActionResult> GetPolicyAddonBYPolicy(string policyNo)
        {
            try
            {
                List<PolicyAddon> policyAddons = await poliaddRepo.GetPolicyAddonBYPolicy(policyNo);
                return Ok(policyAddons);
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }
        //[HttpPost("Policy")]
        //public async Task<ActionResult> Insert(Policy policy)
        //{
        //    try
        //    {
        //        await poliaddRepo.InsertPolicyAsync(policy);
        //        //HttpClient client = new HttpClient();
        //        //await client.PostAsJsonAsync("",new  { PolicyNo=policy.PolicyNo });
        //        return Created();
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}
    }
}
