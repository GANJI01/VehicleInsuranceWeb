using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ABZVehicleInsuranceMVCAPP.Controllers;
using ABZVehicleInsuranceMVCAPP.Models;
using System.Runtime.InteropServices;

namespace ABZVehicleInsuranceMVCAPP.Controllers
{
    public class ProductAddonController : Controller
    {
        static HttpClient client = new HttpClient() { BaseAddress = new Uri("http://localhost:5145/api/Product/") };
        // GET: ProductAddonController
        public async Task<ActionResult> Index()
        {
            List<ProductAddOn> productAddon = await client.GetFromJsonAsync<List<ProductAddOn>>("");
            return View(productAddon);
        }

        // GET: ProductAddonController/Details/5
        public async Task<ActionResult> Details(string productID, string addonId)
        {
            ProductAddOn productAddon = await client.GetFromJsonAsync<ProductAddOn>("" + productID + addonId);
            return View(productAddon);
        }

        // GET: ProductAddonController/Create
        public async Task<ActionResult> Create()
        {
            ProductAddOn productAddon = new ProductAddOn();
            return View(productAddon);
        }

        // POST: ProductAddonController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ProductAddOn productAddon)
        {
            try
            {
                await client.PostAsJsonAsync<ProductAddOn>("", productAddon);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductAddonController/Edit/5
        [Route("ProductAddon/Edit/{productID}")]
        public async Task<ActionResult> Edit(string productID, string addonId)
        {
            ProductAddOn productAddon = await client.GetFromJsonAsync<ProductAddOn>("" + productID + addonId);
            return View(productAddon);
        }

        // POST: ProductAddonController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("ProductAddon/Edit/{productID}/{addonId}")]
        public async Task<ActionResult> Edit(string productID, string addonId, ProductAddOn productAddon)
        {
            try
            {
                await client.PutAsJsonAsync<ProductAddOn>("" + productID + addonId, productAddon);
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
            ProductAddOn productAddon = await client.GetFromJsonAsync<ProductAddOn>("" + productID + addonId);
            return View(productAddon);
        }

        // POST: ProductAddonController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("ProductAddon/Delete/{productID}/{addonId}")]
        public async Task<ActionResult> Delete(string productID, string addonId, IFormCollection collection)
        {
            try
            {
                await client.DeleteAsync("" + productID + addonId);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public async Task<ActionResult> ByProduct(string productID)
        {
            List<ProductAddOn> productAddons = await client.GetFromJsonAsync<List<ProductAddOn>>("ByProduct/" + productID);
            return View(productAddons);
        }
    }
}
