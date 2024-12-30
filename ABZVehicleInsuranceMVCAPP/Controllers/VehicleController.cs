using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ABZVehicleInsuranceMVCAPP.Models;
using System.Runtime.InteropServices;
using NuGet.Common;

namespace ABZVehicleInsuranceMVCAPP.Controllers
{
    public class VehicleController : Controller
    {
       // static HttpClient client = new HttpClient() { BaseAddress = new Uri("http://localhost:5083/api/Vehicle/") };
        static HttpClient client = new HttpClient() { BaseAddress = new Uri("https://abzvehiclewebapi-chanad.azurewebsites.net/api/Vehicle/") };

        static string token;
        // GET: VehicleController
        public async Task<ActionResult> Index()
        {
            string userName = User.Identity.Name;
            string role = User.Claims.ToArray()[4].Value;
            string secretKey = "My name is Bond, James Bond the great";
            HttpClient client2 = new HttpClient();
            //token = await client2.GetStringAsync("http://localhost:5018/api/Auth/" + userName + "/" + role + "/" + secretKey);
            token = await client2.GetStringAsync("https://abzauthwebapi-chanad.azurewebsites.net/api/Auth/" + userName + "/" + role + "/" + secretKey);
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

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
            ViewData["token"] = token;
            return View(vehicle);
        }

        // POST: VehicleController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Vehicle vehicle)
        {
            try
            {
                await client.PostAsJsonAsync<Vehicle>("" + token, vehicle);
                TempData["AlertMessage"] = "Created Successfully.....!";
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
                await client.PutAsJsonAsync<Vehicle>(""+ regNo ,vehicle );
                TempData["AlertMessage"] = "Edited Successfully.....!";
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
            List<Vehicle> vehicles = await client.GetFromJsonAsync<List<Vehicle>>("ByCustomer/" + customerId);
            return View(vehicles);
        }

    }
}
