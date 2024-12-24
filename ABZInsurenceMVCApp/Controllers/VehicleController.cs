using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ABZInsurenceMVCApp.Models;
using System.Runtime.InteropServices;

namespace ABZInsurenceMVCApp.Controllers
{
    public class VehicleController : Controller
    {
        static HttpClient client = new HttpClient() { BaseAddress = new Uri("http://localhost:5083/api/Vehicle/") };
        // GET: VehicleController
        public async Task<ActionResult> Index()
        {
            List<Vehicle> vehicles = await client.GetFromJsonAsync<List<Vehicle>>("");
            return View(vehicles);
        }

        // GET: VehicleController/Details/5
        public async Task<ActionResult> Details(string regNo)
        {
            Vehicle vehicle = await client.GetFromJsonAsync<Vehicle>("" + regNo);
            return View(vehicle);
        }

        // GET: VehicleController/Create
        public async Task<ActionResult> Create()
        {
            Vehicle vehicle = new Vehicle();
            return View(vehicle);
        }

        // POST: VehicleController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Vehicle vehicle)
        {
            try
            {
                await client.PostAsJsonAsync<Vehicle>("", vehicle);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: VehicleController/Edit/5
        [Route("Vehicle/Edit/{regNo}")]
        public async Task<ActionResult> Edit(string regNo)
        {
            Vehicle vehicle = await client.GetFromJsonAsync<Vehicle>("" + regNo);
            return View(vehicle);
        }

        // POST: VehicleController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Vehicle/Edit/{regNo}")]
        public async Task<ActionResult> Edit(string regNo, Vehicle vehicle)
        {
            try
            {
                await client.PutAsJsonAsync<Vehicle>(""+regNo, vehicle);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: VehicleController/Delete/5
        [Route("Vehicle/Delete/{regNo}")]
        public async Task<ActionResult> Delete(string regNo)
        {
            Vehicle vehicle = await client.GetFromJsonAsync<Vehicle>("" + regNo);
            return View(vehicle);

        }

        // POST: VehicleController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Vehicle/Delete/{regNo}")]
        public async Task<ActionResult> Delete(string regNo, IFormCollection collection)
        {
            try
            {
                await client.DeleteAsync("" + regNo);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
       // [HttpGet("ByCustomer/{customerId}")]
        public async Task<ActionResult> ByCustomer(string customerId)
        {
            List<Vehicle> vehicles = await client.GetFromJsonAsync<List<Vehicle>>("ByCustomer/"+customerId);
            return View(vehicles);
        }
        
    }
}
