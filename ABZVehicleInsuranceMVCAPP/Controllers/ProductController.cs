using ABZVehicleInsuranceMVCAPP.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ABZVehicleInsuranceMVCAPP.Controllers;
using System.Security.Cryptography;
using System.Net.Http.Json;
using NuGet.Common;

namespace ABZVehicleInsuranceMVCAPP.Controllers
{

    public class ProductController : Controller
    {
        static HttpClient client = new HttpClient() { BaseAddress = new Uri("http://localhost:5145/api/Product/") };
        static string token;
        // GET: ProductController
        public async Task<ActionResult> Index()
        {
            string userName = User.Identity.Name;
            string role = User.Claims.ToArray()[4].Value;
            string secretKey = "My name is Bond, James Bond the great";
            HttpClient client2 = new HttpClient();
            token = await client2.GetStringAsync("http://localhost:5243/api/Auth/" + userName + "/" + role + "/" + secretKey);
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            List<Product> products = await client.GetFromJsonAsync<List<Product>>("");
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
            return View(product);
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<ActionResult> Create(Product product)
        {
            try
            {
                await client.PostAsJsonAsync<Product>("", product);
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
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
     
    }
}