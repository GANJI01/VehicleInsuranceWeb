using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ABZVehicleInsuranceMVCAPP.Models;
using System.Runtime.InteropServices;
using NuGet.Common;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;

namespace ABZVehicleInsuranceMVCAPP.Controllers
{
    [Authorize]
    public class VehicleController : Controller
    {
        static HttpClient client = new HttpClient() { BaseAddress = new Uri("http://localhost:5172/VehicleSvc/") };
        //static HttpClient client = new HttpClient() { BaseAddress = new Uri("https://abzvehiclewebapi-chanad.azurewebsites.net/api/Vehicle/") };

        static string token;
        // GET: VehicleController
        public async Task<ActionResult> Index(string selectedFuelType)
        {
            string userName = User.Identity.Name;
            string role = User.Claims.ToArray()[4].Value;
            string secretKey = "My name is Bond, James Bond the great";
            HttpClient client2 = new HttpClient();
            token = await client2.GetStringAsync("http://localhost:5172/AuthSvc/" + userName + "/" + role + "/" + secretKey);
            //token = await client2.GetStringAsync("https://abzauthwebapi-chanad.azurewebsites.net/api/Auth/" + userName + "/" + role + "/" + secretKey);
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            List<Vehicle> vehicles = await client.GetFromJsonAsync<List<Vehicle>>("");
            ViewBag.FuelTypes = new List<SelectListItem>
            {
                new SelectListItem { Text = "Petrol", Value = "P" },
                new SelectListItem { Text = "Diesel", Value = "D" },
                new SelectListItem { Text = "CNG", Value = "C" },
                new SelectListItem { Text = "LPG", Value = "L" },
                new SelectListItem { Text = "Electric", Value = "E" }
            };

            // Filter vehicles based on fuel type
            if (!string.IsNullOrEmpty(selectedFuelType))
            {
                vehicles = vehicles.Where(v => v.FuelType == selectedFuelType).ToList();
            }

            return View(vehicles);

        }

        // GET: VehicleController/Details/5
        public async Task<ActionResult> Details(string regNo)
        {
            Vehicle vehicle = await client.GetFromJsonAsync<Vehicle>("" + regNo);
            return View(vehicle);
        }

        // GET: VehicleController/Create
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Create()
        {
            Vehicle vehicle = new Vehicle();
            ViewData["token"] = token;
            List<SelectListItem> fuelTypes = new List<SelectListItem>
            {
                new SelectListItem { Text = "Petrol", Value = "P" },
                new SelectListItem { Text = "Diesel", Value = "D" },
                new SelectListItem { Text = "CNG", Value = "C" },
                new SelectListItem { Text = "LPG", Value = "L" },
                new SelectListItem { Text = "Electric", Value = "E" }
             };

            // Passing the fuelTypes list to the View using ViewBag
            ViewBag.FuelTypes = fuelTypes;

            return View(vehicle);
            return View(vehicle);
        }

        // POST: VehicleController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Edit(string regNo)
        {
            Vehicle vehicle = await client.GetFromJsonAsync<Vehicle>("" + regNo);
            return View(vehicle);
        }

        // POST: VehicleController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Vehicle/Edit/{regNo}")]
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Delete(string regNo)
        {
            Vehicle vehicle = await client.GetFromJsonAsync<Vehicle>("" + regNo);
            return View(vehicle);

        }

        // POST: VehicleController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Vehicle/Delete/{regNo}")]
        [Authorize(Roles = "Admin")]
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
