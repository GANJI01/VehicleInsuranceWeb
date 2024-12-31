using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ABZVehicleInsuranceMVCAPP.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ABZVehicleInsuranceMVCAPP.Controllers
{
    public class CustomerQueryController : Controller
    {
        //static HttpClient client = new HttpClient() { BaseAddress = new Uri("http://localhost:5058/api/CustomerQuery/") };
        static HttpClient client = new HttpClient() { BaseAddress = new Uri("https://abzquerywebapi-chanad.azurewebsites.net/api/CustomerQuery/") };
        static string token;
        // GET: CustomerQueryController
        public async Task<ActionResult> Index(string selectedQueryStatus)
        {
            ViewData["ActiveNav"] = "CustomerQuery";

            string userName = User.Identity.Name;
            string role = User.Claims.ToArray()[4].Value;
            string secretKey = "My name is Bond, James Bond the great";
            HttpClient client2 = new HttpClient();
           // token = await client2.GetStringAsync("http://localhost:5058/api/CustomerQuery/" + userName + "/" + role + "/" + secretKey);
            token = await client2.GetStringAsync("https://abzauthwebapi-chanad.azurewebsites.net/api/Auth/" + userName + "/" + role + "/" + secretKey);
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            List<CustomerQuery> customers = await client.GetFromJsonAsync<List<CustomerQuery>>("");
            ViewBag.FuelTypes = new List<SelectListItem>
            {
                new SelectListItem { Text = "Active", Value = "A" },
                new SelectListItem { Text = "Responded", Value = "R" }
            };

            // Filter vehicles based on fuel type
            if (!string.IsNullOrEmpty(selectedQueryStatus))
            {
                customers = customers.Where(v => v.Status == selectedQueryStatus).ToList();
            }
            return View(customers);
        }

        // GET: CustomerQueryController/Details/5
        public async Task<ActionResult> Details(string queryId)
        {
            CustomerQuery customerquery = await client.GetFromJsonAsync<CustomerQuery>("" + queryId);
            return View(customerquery);
        }

        // GET: CustomerQueryController/Create
        public async Task<ActionResult> Create()
        {
            CustomerQuery customerquery = new CustomerQuery();
            ViewData["token"] = token;
            List<SelectListItem> fuelTypes = new List<SelectListItem>
            {
                new SelectListItem { Text = "Active", Value = "A" },
                new SelectListItem { Text = "Responded", Value = "R" }
             };

            // Passing the fuelTypes list to the View using ViewBag
            ViewBag.FuelTypes = fuelTypes;
            return View(customerquery);
        }

        // POST: CustomerQueryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CustomerQuery customerquery)
        {
            try
            {
                await client.PostAsJsonAsync<CustomerQuery>("" + token, customerquery);
                TempData["AlertMessage"] = "Created Successfully.....!";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomerQueryController/Edit/5
        [Route("CustomerQuery/Edit/{queryId}")]
        public async Task<ActionResult> Edit(string queryId)
        {
            CustomerQuery customerquery = await client.GetFromJsonAsync<CustomerQuery>("" + queryId);
            return View(customerquery);
        }

        // POST: CustomerQueryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("CustomerQuery/Edit/{queryId}")]
        public async Task<ActionResult> Edit(string queryId, CustomerQuery customerquery)
        {
            try
            {
                await client.PutAsJsonAsync<CustomerQuery>("" + queryId, customerquery);
                TempData["AlertMessage"] = "Edited Successfully.....!";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomerQueryController/Delete/5
        [Route("CustomerQuery/Delete/{queryId}")]
        public async Task<ActionResult> Delete(string queryId)
        {
            CustomerQuery customerquery = await client.GetFromJsonAsync<CustomerQuery>("" + queryId);
            return View(customerquery);
        }

        // POST: CustomerQueryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("CustomerQuery/Delete/{queryId}")]
        public async Task<ActionResult> Delete(string queryId, IFormCollection collection)
        {
            try
            {
                await client.DeleteAsync("" + queryId);
                TempData["AlertMessage"] = "Deleted Successfully.....!";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        public async Task<ActionResult> ByCustomer(string customerId)
        {
            List<CustomerQuery> customerquery = await client.GetFromJsonAsync<List<CustomerQuery>>("ByCustomer/" + customerId);
            return View(customerquery);
        }
    }
}
