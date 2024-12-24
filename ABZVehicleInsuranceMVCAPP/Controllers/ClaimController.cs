using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ABZVehicleInsuranceMVCAPP.Controllers;
using ABZVehicleInsuranceMVCAPP.Models;
using System.Runtime.InteropServices;


namespace ABZVehicleInsuranceMVCAPP.Controllers
{
    public class ClaimController : Controller
    {
        // static HttpClient client = new HttpClient() { BaseAddress = new Uri("https://abzclaimwebapi.azurewebsites.net\r\n") };
        static HttpClient client = new HttpClient() { BaseAddress = new Uri("http://localhost:5189/api/Claim/") };
        // GET: ClaimController
        public async Task<ActionResult> Index()
        {
            List<Claim> claims = await client.GetFromJsonAsync<List<Claim>>("");
            return View(claims);
        }

        // GET: ClaimController/Details/5
        public async Task<ActionResult> Details(string claimNo)
        {
            Claim claim = await client.GetFromJsonAsync<Claim>("" + claimNo);
            return View(claim);
        }

        // GET: ClaimController/Create
        public async Task<ActionResult> Create()
        {
            Claim claim = new Claim();
            return View(claim);
        }

        // POST: ClaimController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Claim claim)
        {
            try
            {
                await client.PostAsJsonAsync<Claim>("", claim);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ClaimController/Edit/5
        [Route("Claim/Edit/{claimNo}")]
        public async Task<ActionResult> Edit(string claimNo)
        {
            Claim claim = await client.GetFromJsonAsync<Claim>("" + claimNo);
            return View(claim);
        }

        // POST: ClaimController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Claim/Edit/{claimNo}")]
        public async Task<ActionResult> Edit(string claimNo, Claim claim)
        {
            try
            {
                await client.PutAsJsonAsync<Claim>("" + claimNo, claim);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ClaimController/Delete/5
        [Route("Claim/Delete/{id}")]
        public async Task<ActionResult> Delete(string claimNo)
        {
            Claim claim = await client.GetFromJsonAsync<Claim>("" + claimNo);
            return View(claim);
        }

        // POST: ClaimController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Claim/Delete/{claimNo}")]
        public async Task<ActionResult> Delete(string claimNo, IFormCollection collection)
        {
            try
            {
                await client.DeleteAsync("" + claimNo);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
       
        public async Task<ActionResult> ByPolicy(string policyNo)
        {
            List<Claim> claims = await client.GetFromJsonAsync<List<Claim>>("ByPolicy/" + policyNo);
            return View(claims);
        }
    }
}
