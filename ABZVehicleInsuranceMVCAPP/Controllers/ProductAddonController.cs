using ABZVehicleInsuranceMVCAPP.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ABZVehicleInsuranceMVCAPP.Controllers
{
    public class ProductAddonController : Controller
    {
        // GET: ProductAddonController
        static HttpClient client = new HttpClient() { BaseAddress = new Uri("http://localhost:5145/api/ProductAddon/") };
        public async Task<ActionResult> Index()
        {
            List<ProductAddon> productaddons = await client.GetFromJsonAsync<List<ProductAddon>>("");
            return View(productaddons);
        }

        // GET: ProductAddonController/Details/5
        public async Task<ActionResult> Details(string productID, string addonId)
        {
            ProductAddon productaddon = await client.GetFromJsonAsync<ProductAddon>($"{productID}/{addonId}");
            return View(productaddon);
        }

        // GET: ProductAddonController/Create
        public ActionResult Create()
        {
            ProductAddon productaddon = new ProductAddon();
            return View(productaddon);
        }

        // POST: ProductAddonController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ProductAddon productaddon)
        {
            try
            {
                await client.PostAsJsonAsync<ProductAddon>("", productaddon);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        [Route("ProductAddon/Edit/{productID}/{addonId}")]

        // GET: ProductAddonController/Edit/5

        public async Task<ActionResult> Edit(string productID, string addonId)
        {
            ProductAddon productaddon = await client.GetFromJsonAsync<ProductAddon>($"{productID}/{addonId}/");
            return View(productaddon);
        }

        // POST: ProductAddonController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("ProductAddon/Edit/{productID}/{addonId}")]


        public async Task<ActionResult> Edit(string productID, string addonId, ProductAddon productaddon)
        {
            try
            {
                await client.PutAsJsonAsync<ProductAddon>($"{productID}/{addonId}/", productaddon);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductAddonController/Delete/5
        [Route("ProductAddon/Delete/{productID}/{addonId}")]

        public async Task<ActionResult> Delete(string productID, string addonId)
        {
            ProductAddon productaddon = await client.GetFromJsonAsync<ProductAddon>($"{productID}/{addonId}");
            return View(productaddon);
        }

        // POST: ProductAddonController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("ProductAddon/Delete/{productID}/{addonId}")]

        public async Task<ActionResult> Delete(string productID, string addonId, IFormCollection collection)
        {
            try
            {
                await client.DeleteAsync($"{productID}/{addonId}");
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        public async Task<ActionResult> ByProduct(string productId)
        {
            List<ProductAddon> productAddons = await client.GetFromJsonAsync<List<ProductAddon>>("ByProduct/" + productId);
            return View(productAddons);
        }
    }
}