﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ABZVehicleInsuranceMVCAPP.Models;
using Microsoft.AspNetCore.Routing.Matching;
using NuGet.Common;
using Microsoft.AspNetCore.Authorization;

namespace ABZVehicleInsuranceMVCAPP.Controllers
{
    [Authorize]
    public class PolicyAddonController : Controller
    {
        static HttpClient client = new HttpClient() { BaseAddress = new Uri("http://localhost:5172/PolicyAddonSvc/") };
        //static HttpClient client = new HttpClient() { BaseAddress = new Uri("https://abzpolicywebapi-chanad.azurewebsites.net/api/PolicyAddon/") };
        
        static string token;
        // GET: PolicyAddonController
        public async Task<ActionResult> Index(string pid)
        {
            ViewData["ActiveNav"] = "PolicyAddon";

            string userName = User.Identity.Name;
            string role = User.Claims.ToArray()[4].Value;
            string secretKey = "My name is Bond, James Bond the great";
            HttpClient client2 = new HttpClient();
            token = await client2.GetStringAsync("http://localhost:5172/AuthSvc/" + userName + "/" + role + "/" + secretKey);
           // token = await client2.GetStringAsync("https://abzauthwebapi-chanad.azurewebsites.net/api/Auth/" + userName + "/" + role + "/" + secretKey);
                                                  
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            List<PolicyAddon> policyAddons = await client.GetFromJsonAsync<List<PolicyAddon>>(""+pid);
            return View(policyAddons);
        }

        // GET: PolicyAddonController/Details/5
        public async Task<ActionResult> Details(string policyNo, string addonId)
        {
            PolicyAddon policyAddon = await client.GetFromJsonAsync<PolicyAddon>($"{policyNo}/{addonId}");
            return View(policyAddon);
        }

        // GET: PolicyAddonController/Create
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Create()
        {
            PolicyAddon policyAddon = new PolicyAddon();
            ViewData["token"] = token;

            return View(policyAddon);
        }

        // POST: PolicyAddonController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Create(PolicyAddon policyAddon)
        {
            try
            {
                await client.PostAsJsonAsync<PolicyAddon>("" + token, policyAddon);
                TempData["AlertMessage"] = "Created Successfully.....!";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PolicyAddonController/Edit/5
        [Route("PolicyAddon/Edit/{policyNo}/{addonId}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Edit(string policyNo, string addonId)
        {
            PolicyAddon policyAddon = await client.GetFromJsonAsync<PolicyAddon>($"{policyNo}/{addonId}/");
            return View(policyAddon);
        }

        // POST: PolicyAddonController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("PolicyAddon/Edit/{policyNo}/{addonId}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Edit(string policyNo, string addonId, PolicyAddon policyAddon)
        {
            try
            {
                await client.PutAsJsonAsync<PolicyAddon>($"{policyNo}/{addonId}/", policyAddon);
                TempData["AlertMessage"] = "Edited Successfully.....!";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PolicyAddonController/Delete/5
        [Route("PolicyAddon/Delete/{policyNo}/{addonId}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Delete(string policyNo, string addonId)
        {
            PolicyAddon policyAddon = await client.GetFromJsonAsync<PolicyAddon>($"{policyNo}/{addonId}");
            return View(policyAddon);
        }

        // POST: PolicyAddonController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("PolicyAddon/Delete/{policyNo}/{addonId}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Delete(string policyNo, string addonId, IFormCollection collection)
        {
            try
            {
                await client.DeleteAsync($"{policyNo}/{addonId}");
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
