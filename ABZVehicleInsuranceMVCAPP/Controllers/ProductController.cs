using ABZVehicleInsuranceMVCAPP.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ABZVehicleInsuranceMVCAPP.Controllers;
using System.Security.Cryptography;
using System.Net.Http.Json;
using NuGet.Common;
using Microsoft.EntityFrameworkCore;
using System.Buffers;

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

            string userName = User.Identity.Name;
            string role = User.Claims.ToArray()[4].Value;
            string secretKey = "My name is Bond, James Bond the great";
            HttpClient client2 = new HttpClient();
          //  token = await client2.GetStringAsync("http://localhost:5018/api/Auth/" + userName + "/" + role + "/" + secretKey);
            token = await client2.GetStringAsync("https://abzauthwebapi-chanad.azurewebsites.net/api/Auth/" + userName + "/" + role + "/" + secretKey);

            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            List<Product> products = await client.GetFromJsonAsync<List<Product>>("");
            return View(products);


            //try
            //{
            //    if (products.Count == 0)
            //    {
            //        TempData["InfoMessage"] = "Currently No products Available in Database";
            //        return View(products);
            //    }
            //    else
            //    {
            //        if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(id))
            //        {
            //            TempData["InfoMessage"] = "Please Provide Search Criteria and Value";
            //            return View(products);
            //        }
            //        else
            //        {
            //            IEnumerable<Product> searchResults = null;

            //            if (searchBy.ToLower() == "ProductName")
            //            {
            //                searchResults = products.Where(p => p.ProductName.ToLower().Contains(searchValue.ToLower()));
            //            }
            //            else if (searchBy.ToLower() == "Id")
            //            {
            //                var searchByProductId =  Products
            //                        .Where(p => p.ProductID.ToLower().Contains(searchValue.ToLower())) // Case-insensitive search
            //                        .ToList();
            //                return View(searchByProductId);
            //            }
            //            else if (searchBy.ToLower() == "InsuredIntrests")
            //            {
            //                searchResults = products.Where(p => p.InsuredInterests.ToLower().Contains(searchValue.ToLower()));
            //            }

            //            if (searchResults != null && searchResults.Any())
            //            {
            //                return View(searchResults.ToList());
            //            }
            //            else
            //            {
            //                TempData["InfoMessage"] = "No matching products found";
            //                return View(products);  // Return the list with all products or an empty list
            //            }
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    // Log error for debugging purposes
            //    TempData["ErrorMessage"] = "An error occurred while searching for products.";
            //    // Optionally, log the exception (e.g., using a logger)
            //    // Log.Error(ex, "Error in Index action");
            //    return View(products);
            //}
            if (string.IsNullOrEmpty(searchBy) || string.IsNullOrEmpty(searchValue))
            {
                // If no search criteria is provided, return all products
                return View(products);
            }

            IEnumerable<Product> searchResults = null;

            // Search by ProductID (varchar type)
            if (searchBy.ToLower() == "id")
            {
                searchResults = products.Where(p => p.ProductID.ToLower().Contains(searchValue.ToLower())).ToList();
            }

            if (searchResults != null && searchResults.Any())
            {
                return View(searchResults);  // Return filtered results
            }
            else
            {
                TempData["InfoMessage"] = "No matching products found.";
                return View(products);  // Return all products if no match is found
            }
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