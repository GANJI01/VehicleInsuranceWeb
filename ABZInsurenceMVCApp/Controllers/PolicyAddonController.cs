using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ABZInsurenceMVCApp.Models;
using Microsoft.AspNetCore.Routing.Matching;

namespace ABZInsurenceMVCApp.Controllers
{
    public class PolicyAddonController : Controller
    {
        static HttpClient client = new HttpClient() { BaseAddress = new Uri("http://localhost:5007/api/Policy/") };
        // GET: PolicyAddonController
        public async Task<ActionResult> Index()
        {
            List<PolicyAddon> policyAddons = await client.GetFromJsonAsync <List<PolicyAddon>>("");
            return View(policyAddons);
        }

        // GET: PolicyAddonController/Details/5
        public async Task<ActionResult> Details(string policyNo,string addonId)
        {
            PolicyAddon policyAddon = await client.GetFromJsonAsync<PolicyAddon>(""+ policyNo+ addonId);
            return View(policyAddon);
        }

        // GET: PolicyAddonController/Create
        public async Task<ActionResult> Create()
        {
            PolicyAddon policyAddon=new PolicyAddon();
            return View(policyAddon);
        }

        // POST: PolicyAddonController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(PolicyAddon policyAddon)
        {
            try
            {
                await client.PostAsJsonAsync<PolicyAddon>("",policyAddon);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PolicyAddonController/Edit/5
        [Route("PolicyAddon/Edit/{policyNo}")]
        public async Task<ActionResult> Edit(string policyNo,string addonId)
        {
            PolicyAddon policyAddon = await client.GetFromJsonAsync<PolicyAddon>("" + policyNo + addonId);
            return View(policyAddon);
        }

        // POST: PolicyAddonController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("PolicyAddon/Edit/{policyNo}/{addonId}")]
        public async Task<ActionResult> Edit(string policyNo, string addonId,PolicyAddon policyAddon)
        {
            try
            {
                await client.PutAsJsonAsync<PolicyAddon>(""+policyNo+addonId, policyAddon);    
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PolicyAddonController/Delete/5
        [Route("PolicyAddon/Delete/{policyNo}/{addonId}")]
        public async Task<ActionResult> Delete(string policyNo,string addonId)
        {
            PolicyAddon policyAddon = await client.GetFromJsonAsync<PolicyAddon>("" + policyNo + addonId);
            return View(policyAddon);
        }

        // POST: PolicyAddonController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("PolicyAddon/Delete/{policyNo}/{addonId}")]
        public async Task<ActionResult> Delete(string policyNo,string addonId, IFormCollection collection)
        {
            try
            {
                await client.DeleteAsync(""+policyNo+addonId);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        
        public async Task<ActionResult> ByPolicy(string proposalId)
        {
            List<PolicyAddon> policyAddons = await client.GetFromJsonAsync<List<PolicyAddon>>("ByPolicy/"+proposalId);
            return View(policyAddons);
        }
    }
}
