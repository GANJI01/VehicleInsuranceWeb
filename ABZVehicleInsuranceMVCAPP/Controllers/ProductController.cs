using ABZVehicleInsuranceMVCAPP.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ABZVehicleInsuranceMVCAPP.Controllers;
using System.Security.Cryptography;
using System.Net.Http.Json;
using NuGet.Common;
using Microsoft.EntityFrameworkCore;
using System.Buffers;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ABZVehicleInsuranceMVCAPP.Controllers
{

    public class ProductController : Controller
    {
       // static HttpClient client = new HttpClient() { BaseAddress = new Uri("http://localhost:5145/api/Product/") };
        static HttpClient client = new HttpClient() { BaseAddress = new Uri("https://abzproductwebapi-chanad.azurewebsites.net/api/Product/") };

        static string token;
        // GET: ProductController
        public async Task<ActionResult> Index(string searchBy, string searchValue)
        {
            ViewData["ActiveNav"] = "Product";

            string userName = User.Identity.Name;
            string role = User.Claims.ToArray()[4].Value;
            string secretKey = "My name is Bond, James Bond the great";
            HttpClient client2 = new HttpClient();
          //  token = await client2.GetStringAsync("http://localhost:5018/api/Auth/" + userName + "/" + role + "/" + secretKey);
            token = await client2.GetStringAsync("https://abzauthwebapi-chanad.azurewebsites.net/api/Auth/" + userName + "/" + role + "/" + secretKey);

            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            List<Product> products = await client.GetFromJsonAsync<List<Product>>("");
           // return View(products);
            if (!string.IsNullOrEmpty(searchValue))
            {
                searchValue = searchValue.Replace(" ", "").ToLower(); // Remove spaces and convert to lowercase
            }

            if (string.IsNullOrEmpty(searchBy) || string.IsNullOrEmpty(searchValue))
            {
                return View(products);
            }

            // Initialize search results
            IEnumerable<Product> searchResults = null;

            // Search by AgentName
            if (searchBy.ToLower() == "productname")
            {
                searchResults = products.Where(a => a.ProductName != null && a.ProductName.ToLower().Contains(searchValue.ToLower())).ToList();
            }

            if (searchResults != null && searchResults.Any())
            {
                return View(searchResults); // Return filtered results
            }
            else
            {
                TempData["InfoMessage"] = "No matching agents found.";
                return View(products); // Return all agents if no match is found
            }

            return View(products);
        }
    


        

        // GET: ProductController/Details/5
        public async Task<ActionResult> Details(string productID)
        {
            Product product = await client.GetFromJsonAsync<Product>("" + productID);
            return View(product);
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            Product product = new Product();
            ViewData["token"] = token;
            List<SelectListItem> fuelTypes = new List<SelectListItem>
            {
                new SelectListItem { Text = "Private car", Value = "PRIVATE CAR" },
                new SelectListItem { Text = "Public car", Value = "PUBLIC CAR" }
             };

            // Passing the fuelTypes list to the View using ViewBag
            ViewBag.FuelTypes = fuelTypes;
            return View(product);
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<ActionResult> Create(Product product)
        {
            try
            {
                await client.PostAsJsonAsync<Product>("" + token, product);
                TempData["AlertMessage"] = "Created Successfully.....!";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        [Route("Product/Edit/{productID}")]
        // GET: ProductController/Edit/5
        public async Task<ActionResult> Edit(string productID)
        {
            Product product = await client.GetFromJsonAsync<Product>("" + productID);
            return View(product);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Product/Edit/{productID}")]
        public async Task<ActionResult> Edit(string productID, Product product)
        {
            try
            {
                await client.PutAsJsonAsync<Product>("" + productID, product);
                TempData["AlertMessage"] = "Edited Successfully.....!";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Delete/5
        [Route("Product/Delete/{productID}")]
        public async Task<ActionResult> Delete(string productID)
        {
            Product product = await client.GetFromJsonAsync<Product>("" + productID);
            return View(product);
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Product/Delete/{productID}")]
        public async Task<ActionResult> Delete(string productID, IFormCollection collection)
        {
            try
            {
                await client.DeleteAsync("" + productID);
                TempData["AlertMessage"] = "Deleted Successfully.....!";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
     
    }
}