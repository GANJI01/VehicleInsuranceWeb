using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ABZVehicleInsuranceMVCAPP.Models;
using System.Runtime.InteropServices;


namespace ABZVehicleInsuranceMVCAPP.Controllers
{
    public class PolicyController : Controller
    {
        static HttpClient client = new HttpClient() { BaseAddress = new Uri("http://localhost:5007/api/Policy/") };
        // GET: PolicyController
        public async Task<ActionResult> Index()
        {
            List<Policy> policies = await client.GetFromJsonAsync<List<Policy>>("");
            return View(policies);
        }

        // GET: PolicyController/Details/5
        public async Task<ActionResult> Details(string policyNo)
        {
            Policy policy = await client.GetFromJsonAsync<Policy>("" + policyNo);
            return View(policy);
        }

        // GET: PolicyController/Create
        public async Task<ActionResult> Create()
        {
            Policy policy = new Policy();
            return View(policy);
        }

        // POST: PolicyController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Policy policy)
        {
            try
            {
                await client.PostAsJsonAsync<Policy>("", policy);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PolicyController/Edit/5
        [Route("Policy/Edit/{policyNo}")]
        public async Task<ActionResult> Edit(string policyNo)
        {
            Policy policy = await client.GetFromJsonAsync<Policy>("" + policyNo);
            return View(policy);
        }

        // POST: PolicyController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Policy/Edit/{policyNo}")]
        public async Task<ActionResult> Edit(string policyNo, Policy policy)
        {
            try
            {
                await client.PutAsJsonAsync<Policy>(""+policyNo, policy);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PolicyController/Delete/5
        [Route("Policy/Delete/{policyNo}")]
        public async Task<ActionResult> Delete(string policyNo)
        {
            Policy policy = await client.GetFromJsonAsync<Policy>("" + policyNo);
            return View(policy);
        }

        // POST: PolicyController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Policy/Delete/{policyNo}")]
        public async Task<ActionResult> Delete(string policyNo, IFormCollection collection)
        {
            try
            {
                await client.DeleteAsync("" + policyNo);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public async Task<ActionResult> ByProposal(string proposalId)
        {
            List<Policy> policies = await client.GetFromJsonAsync<List<Policy>>("ByProposal/" + proposalId);
            return View(policies);
        }

    }
}
