using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ABZVehicleInsuranceMVCAPP.Models;
using NuGet.Common;

namespace ABZVehicleInsuranceMVCAPP.Controllers
{

    public class CustomerController : Controller
    {
        // GET: CustomerController
       // static HttpClient client = new HttpClient() { BaseAddress = new Uri("http://localhost:5151/api/Customer/") };
        static HttpClient client = new HttpClient() { BaseAddress = new Uri("https://abzcustomerwebapi-chanad.azurewebsites.net/api/Customer/") };

        static string token;
        public async Task<ActionResult> Index()
        {
            string userName = User.Identity.Name;
            string role = User.Claims.ToArray()[4].Value;
            string secretKey = "My name is Bond, James Bond the great";
            HttpClient client2 = new HttpClient();
            // token = await client2.GetStringAsync("http://localhost:5018/api/Auth/" + userName + "/" + role + "/" + secretKey);
            token = await client2.GetStringAsync("https://abzauthwebapi-chanad.azurewebsites.net/api/Auth/" + userName + "/" + role + "/" + secretKey);
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            List<Customer> customers = await client.GetFromJsonAsync<List<Customer>>("");
            return View(customers);
        }

        // GET: ProposalController/Details/5
        public async Task<ActionResult> Details(string customerId)
        {
            Customer customer = await client.GetFromJsonAsync<Customer>("" + customerId);
            return View(customer);
        }

        // GET: ProposalController/Create
        public ActionResult Create()
        {
            Customer customer = new Customer();
            ViewData["token"] = token;
            return View(customer);
        }

        // POST: ProposalController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Customer customer)
        {
            try
            {
                await client.PostAsJsonAsync<Customer>(""+token, customer);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProposalController/Edit/5
        [Route("Customer/Edit/{customerId}")]
        public async Task<ActionResult> Edit(string customerId)
        {
            Customer customer = await client.GetFromJsonAsync<Customer>("" + customerId);
            return View(customer);
        }
        // POST: ProposalController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Customer/Edit/{customerId}")]
        public async Task<ActionResult> Edit(string customerId, Customer customer)
        {
            try
            {
                await client.PutAsJsonAsync<Customer>("" + customerId, customer);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProposalController/Delete/5
        [Route("Customer/Delete/{customerId}")]
        public async Task<ActionResult> Delete(string customerId)
        {
            Customer customer = await client.GetFromJsonAsync<Customer>("" + customerId);
            return View(customer);
        }

        // POST: ProposalController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Customer/Delete/{customerId}")]
        public async Task<ActionResult> Delete(string customerId, IFormCollection collection)
        {
            try
            {
                await client.DeleteAsync("" + customerId);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
