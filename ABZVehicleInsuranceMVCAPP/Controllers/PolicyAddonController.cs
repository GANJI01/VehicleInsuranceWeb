using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ABZVehicleInsuranceMVCAPP.Models;
using Microsoft.AspNetCore.Routing.Matching;

namespace ABZVehicleInsuranceMVCAPP.Controllers
{
    public class PolicyAddonController : Controller
    {
        static HttpClient client = new HttpClient() { BaseAddress = new Uri("http://localhost:5007/api/Policy/") };
        // GET: PolicyAddonController
        public async Task<ActionResult> Index(string pid)
        {
            List<PolicyAddon> policyAddons = await client.GetFromJsonAsync<List<PolicyAddon>>(""+pid);
            return View(policyAddons);
        }

        // GET: PolicyAddonController/Details/5
        public async Task<ActionResult> Details(string policyNo, string addonId)
        {
            PolicyAddon policyAddon = await client.GetFromJsonAsync<PolicyAddon>("" + policyNo + addonId);
            return View(policyAddon);
        }

        // GET: PolicyAddonController/Create
        public async Task<ActionResult> Create()
        {
            PolicyAddon policyAddon = new PolicyAddon();
            return View();
        }

        // POST: PolicyAddonController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(PolicyAddon policyAddon)
        {
            try
            {
                await client.PostAsJsonAsync<PolicyAddon>("", policyAddon);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PolicyAddonController/Edit/5
        public async Task<ActionResult> Edit(string policyNo, string addonId)
        {
            PolicyAddon policyAddon = await client.GetFromJsonAsync<PolicyAddon>($"{policyNo}/{addonId}");
            return View(policyAddon);
        }

        // POST: PolicyAddonController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(string policyNo, string addonId, PolicyAddon policyAddon)
        {
            try
            {
                await client.PutAsJsonAsync<PolicyAddon>($"{policyNo}/{addonId}", policyAddon);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PolicyAddonController/Delete/5
        public async Task<ActionResult> Delete(string policyNo, string addonId)
        {
            PolicyAddon policyAddon = await client.GetFromJsonAsync<PolicyAddon>($"{policyNo}/{addonId}");
            return View(policyAddon);
        }

        // POST: PolicyAddonController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(string policyNo, string addonId, IFormCollection collection)
        {
            try
            {
                await client.DeleteAsync($"{policyNo}/{addonId}");
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        /*public async Task<ActionResult> ByPolicy(string policyNo)
        {
            List<PolicyAddon> policyAddons = await client.GetFromJsonAsync<List<PolicyAddon>>("ByPolicy/" + policyNo);
            return View(policyAddons);
        }*/
    }
}
