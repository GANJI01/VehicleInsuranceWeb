using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ABZInsurenceMVCApp.Models;
using System.Runtime.InteropServices;

namespace ABZInsurenceMVCApp.Controllers
{
    public class ProposalController : Controller
    {
        // GET: ProposalController
        static HttpClient client = new HttpClient() { BaseAddress = new Uri("http://localhost:5273/api/Proposal/") };
        public async Task<ActionResult> Index()
        {
            List<Proposal> proposals = await client.GetFromJsonAsync<List<Proposal>>("");
            return View(proposals);
        }

        // GET: ProposalController/Details/5
        public async Task<ActionResult> Details(string proposalID)
        {
            Proposal proposal=await client.GetFromJsonAsync<Proposal>(""+proposalID);
            return View(proposal);
        }

        // GET: ProposalController/Create
        public ActionResult Create()
        {
            Proposal proposal = new Proposal();
            return View(proposal);
        }

        // POST: ProposalController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Proposal proposal)
        {
            try
            {
                await client.PostAsJsonAsync<Proposal>("", proposal);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProposalController/Edit/5
        [Route("Proposal/Edit/{proposalID}")]
        public async Task<ActionResult> Edit(string proposalID)
        {
            Proposal proposal = await client.GetFromJsonAsync<Proposal>(""+ proposalID);
            return View(proposal);
        }

        // POST: ProposalController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Proposal/Edit/{proposalID}")]
        public async Task<ActionResult> Edit(string proposalID, Proposal proposal)
        {
            try
            {
                await client.PutAsJsonAsync<Proposal>("" + proposalID, proposal);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProposalController/Delete/5
        [Route("Proposal/Delete/{proposalID}")]
        public async Task<ActionResult> Delete(string proposalID)
        {
            Proposal proposal = await client.GetFromJsonAsync<Proposal>("" + proposalID);
            return View(proposal);
        }

        // POST: ProposalController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Proposal/Delete/{proposalID}")]
        public async Task<ActionResult> Delete(string proposalID, IFormCollection collection)
        {
            try
            {
                await client.DeleteAsync("" + proposalID);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        public async Task<ActionResult> GetByAgent(string agentID)
        {
            List<Proposal> proposals = await client.GetFromJsonAsync<List<Proposal>>("GetByAgent/" + agentID);
            return View(proposals);
        }
        public async Task<ActionResult> GetByCustomer(string custID)
        {
            List<Customer> customers = await client.GetFromJsonAsync<List<Customer>>("GetByCustomer/" + custID);
            return View(customers);
        }
        public async Task<ActionResult> GetByProduct(string productID)
        {
            List<Product> products = await client.GetFromJsonAsync<List<Product>>("GetByProduct/" + productID);
            return View(products);
        }
        public async Task<ActionResult> GetByVehicle(string regID)
        {
            List<Vehicle> vehicles = await client.GetFromJsonAsync < List < Vehicle>>("GetByVehicle/" + regID);
            return View(vehicles);
        }
    }
}
