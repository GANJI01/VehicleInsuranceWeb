using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ABZVehicleInsuranceMVCAPP.Models;
using System.Net.Http.Json;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using Microsoft.AspNetCore.Authorization;

namespace ABZVehicleInsuranceMVCAPP.Controllers
{
    [Authorize]
    public class QueryResponseController : Controller
    {
        static HttpClient client = new HttpClient() { BaseAddress = new Uri("http://localhost:5172/QueryResponseSvc/") };
        //static HttpClient client = new HttpClient() { BaseAddress = new Uri("https://abzquerywebapi-chanad.azurewebsites.net/api/QueryResponse/") };

        static string token;
        // GET: CustomerQueryController
        public async Task<ActionResult> Index()
        {
            ViewData["ActiveNav"] = "QueryResponse";

            string userName = User.Identity.Name;
            string role = User.Claims.ToArray()[4].Value;
            string secretKey = "My name is Bond, James Bond the great";
            HttpClient client2 = new HttpClient();
            token = await client2.GetStringAsync("http://localhost:5172/QueryResponseSvc/" + userName + "/" + role + "/" + secretKey);
           // token = await client2.GetStringAsync("https://abzauthwebapi-chanad.azurewebsites.net/api/Auth/" + userName + "/" + role + "/" + secretKey);
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            List<QueryResponse> queries = await client.GetFromJsonAsync<List<QueryResponse>>("");
            return View(queries);
        }

        // GET: CustomerQueryController/Details/5
        public async Task<ActionResult> Details(string queryId, string srNo)
        {
            QueryResponse query = await client.GetFromJsonAsync<QueryResponse>($"{queryId}/{srNo}");
            return View(query);
        }

        // GET: CustomerQueryController/Create
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Create()
        {
            QueryResponse query = new QueryResponse();
            ViewData["token"] = token;
            return View(query);
        }

        // POST: CustomerQueryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Create(QueryResponse queryresponse)
        {
            try
            {
                await client.PostAsJsonAsync<QueryResponse>("" + token, queryresponse);
                TempData["AlertMessage"] = "Created Successfully.....!";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomerQueryController/Edit/5
       
        [Route("QueryResponse/Edit/{queryId}/{srNo}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Edit(string queryId, string srNo)
        {
            QueryResponse query = await client.GetFromJsonAsync<QueryResponse>($"{queryId}/{srNo}");
            return View(query);
        }

        // POST: CustomerQueryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("QueryResponse/Edit/{queryId}/{srNo}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Edit(string queryId, string srNo, QueryResponse queryResponse)
        {
            try
            {
                await client.PutAsJsonAsync<QueryResponse>($"{queryId}/{srNo}", queryResponse);
                TempData["AlertMessage"] = "Edited Successfully.....!";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomerQueryController/Delete/5
        [Route("QueryResponse/Delete/{queryId}/{srNo}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Delete(string queryId, string srNo)
        {
            QueryResponse query = await client.GetFromJsonAsync<QueryResponse>($"{queryId}/{srNo}");
            return View(query);
        }

        // POST: CustomerQueryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("QueryResponse/Delete/{queryId}/{srNo}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Delete(string queryId, string srNo, IFormCollection collection)
        {
            try
            {
                await client.DeleteAsync($"{queryId}/{srNo}");
                TempData["AlertMessage"] = "Deleted Successfully.....!";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        public async Task<ActionResult> ByCustomerQuery(string queryId)
        {
            List<QueryResponse> queries = await client.GetFromJsonAsync<List<QueryResponse>>("ByCustomerQuery/" + queryId);
            return View(queries);
        }
        public async Task<ActionResult> ByAgent(string agentID)
        {
            List<QueryResponse> qr = await client.GetFromJsonAsync<List<QueryResponse>>("ByAgent/" + agentID);
            return View(qr);
        }
    }
}
