using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ABZVehicleInsuranceMVCAPP.Models;
using System.Runtime.InteropServices;
using NuGet.Common;

namespace ABZVehicleInsuranceMVCAPP.Controllers
{
    public class ProposalController : Controller
    {
        // GET: ProposalController
       // static HttpClient client = new HttpClient() { BaseAddress = new Uri("http://localhost:5273/api/Proposal/") };
        static HttpClient client = new HttpClient() { BaseAddress = new Uri("https://abzproposalwebapi-chanad.azurewebsites.net/api/Proposal/") };

        static string token;
        public async Task<ActionResult> Index()
        {
            ViewData["ActiveNav"] = "Proposal";

            string userName = User.Identity.Name;
            string role = User.Claims.ToArray()[4].Value;
            string secretKey = "My name is Bond, James Bond the great";
            HttpClient client2 = new HttpClient();
            //  token = await client2.GetStringAsync("http://localhost:5018/api/Auth/" + userName + "/" + role + "/" + secretKey);
            token = await client2.GetStringAsync("https://abzauthwebapi-chanad.azurewebsites.net/api/Auth/" + userName + "/" + role + "/" + secretKey);

            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            List<Proposal> proposals = await client.GetFromJsonAsync<List<Proposal>>("");
            return View(proposals);
        }

        // GET: ProposalController/Details/5
        public async Task<ActionResult> Details(string proposalNo)
        {
            Proposal proposal = await client.GetFromJsonAsync<Proposal>("" +proposalNo);
            return View(proposal);
        }

        // GET: ProposalController/Create
        public ActionResult Create()
        {
            Proposal proposal = new Proposal();
            ViewData["token"] = token;
            return View(proposal);
        }

        // POST: ProposalController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Proposal proposal)
        {
            try
            {
                await client.PostAsJsonAsync<Proposal>("" + token, proposal);
                TempData["AlertMessage"] = "Created Successfully.....!";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProposalController/Edit/5
        [Route("Proposal/Edit/{proposalNo}")]
        public async Task<ActionResult> Edit(string proposalNo)
        {
            Proposal proposal = await client.GetFromJsonAsync<Proposal>("" + proposalNo);
            return View(proposal);
        }

        // POST: ProposalController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Proposal/Edit/{proposalNo}")]
        public async Task<ActionResult> Edit(string proposalNo, Proposal proposal)
        {
            try
            {
                await client.PutAsJsonAsync<Proposal>("" + proposalNo, proposal);
                TempData["AlertMessage"] = "Edited Successfully.....!";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProposalController/Delete/5
        [Route("Proposal/Delete/{proposalNo}")]
        public async Task<ActionResult> Delete(string proposalNo)
        {
            Proposal proposal = await client.GetFromJsonAsync<Proposal>("" + proposalNo);
            return View(proposal);
        }

        // POST: ProposalController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Proposal/Delete/{proposalNo}")]
        public async Task<ActionResult> Delete(string proposalNo, IFormCollection collection)
        {
            try
            {
                await client.DeleteAsync("" + proposalNo);
                TempData["AlertMessage"] = "Deleted Successfully.....!";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        public async Task<ActionResult> ByAgent(string agentId)
        {
            List<Proposal> proposals = await client.GetFromJsonAsync<List<Proposal>>("ByAgent/" + agentId);
            return View(proposals);
        }
        public async Task<ActionResult> ByCustomer(string customerId)
        {
            List<Proposal> customers = await client.GetFromJsonAsync<List<Proposal>>("ByCustomer/" + customerId);
            return View(customers);
        }
        public async Task<ActionResult> ByProduct(string productId)
        {
            List<Proposal> products = await client.GetFromJsonAsync<List<Proposal>>("ByProduct/" + productId);
            return View(products);
        }
        public async Task<ActionResult> ByVehicle(string regNo)
        {
            List<Proposal> vehicles = await client.GetFromJsonAsync<List<Proposal>>("ByVehicle/" + regNo);
            return View(vehicles);
        }
    }
}
