using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ABZVehicleInsuranceMVCAPP.Models;
using Claim = ABZVehicleInsuranceMVCAPP.Models.Claim;
using NuGet.Common;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;

namespace ABZVehicleInsuranceMVCAPP.Controllers
{
    [Authorize]
    public class ClaimController : Controller
    {
        static HttpClient client = new HttpClient() { BaseAddress = new Uri("http://localhost:5172/ClaimSvc/") };
        // static HttpClient client = new HttpClient() { BaseAddress = new Uri("https://abzclaimwebapi-chanad.azurewebsites.net/api/Claim/") };

        static string token;
        // GET: ClaimController
        public async Task<ActionResult> Index()
        {
            ViewData["ActiveNav"] = "Claim";

            string userName = User.Identity.Name;
            string role = User.Claims.ToArray()[4].Value;
            string secretKey = "My name is Bond, James Bond the great";
            HttpClient client2 = new HttpClient();
            token = await client2.GetStringAsync("http://localhost:5172/AuthSvc/" + userName + "/" + role + "/" + secretKey);
            // token = await client2.GetStringAsync("https://abzauthwebapi-chanad.azurewebsites.net/api/Auth/" + userName + "/" + role + "/" + secretKey);
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            List<Claim> claims = await client.GetFromJsonAsync<List<Claim>>("");
            return View(claims);
        }

        // GET: ClaimController/Details/5
        public async Task<ActionResult> Details(string claimNo)
        {
            Claim claims = await client.GetFromJsonAsync<Claim>("" + claimNo);
            return View(claims);
        }

        // GET: ClaimController/Create
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Create()
        {
            Claim claim = new Claim();
            ViewData["token"] = token;

            List<SelectListItem> fuelTypes = new List<SelectListItem>
            {
                new SelectListItem { Text = "Submitted", Value = "S" },
                new SelectListItem { Text = "Approved", Value = "A" },
                new SelectListItem { Text = "Rejected", Value = "R" },
                new SelectListItem { Text = "Terminated", Value = "T" }
             };

            // Passing the fuelTypes list to the View using ViewBag
            ViewBag.FuelTypes = fuelTypes;

            return View(claim);
            return View(claim);
        }

        // POST: ClaimController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]

        public async Task<ActionResult> Create(Claim claim)
        {
            try
            {
                await client.PostAsJsonAsync<Claim>("" + token, claim);
                TempData["AlertMessage"] = "Created Successfully.....!";


                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        [Route("Claim/Edit/{claimNo}")]
        [Authorize(Roles = "Admin")]
        // GET: ClaimController/Edit/5
        public async Task<ActionResult> Edit(string claimNo)
        {
            Claim claim = await client.GetFromJsonAsync<Claim>("" + claimNo);
            return View(claim);
        }

        // POST: ClaimController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Claim/Edit/{claimNo}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Edit(string claimNo, Claim claim)
        {
            try
            {
                await client.PutAsJsonAsync<Claim>("" + claimNo, claim);
                TempData["AlertMessage"] = "Edited Successfully.....!";

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        [Route("Claim/Delete/{claimNo}")]
        [Authorize(Roles = "Admin")]
        // GET: ClaimController/Delete/5
        public async Task<ActionResult> Delete(string claimNo)
        {
            Claim claim = await client.GetFromJsonAsync<Claim>("" + claimNo);
            return View(claim);
        }

        // POST: ClaimController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Claim/Delete/{claimNo}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Delete(string claimNo, IFormCollection collection)
        {
            try
            {
                await client.DeleteAsync("" + claimNo);
                TempData["AlertMessage"] = "Deleted Successfully.....!";

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