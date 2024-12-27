using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ABZVehicleInsuranceMVCAPP.Models;
using System.Net.Http.Json;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace ABZVehicleInsuranceMVCAPP.Controllers
{
    public class QueryResponseController : Controller
    {
        static HttpClient client = new HttpClient() { BaseAddress = new Uri("http://localhost:5058/api/QueryResponse/") };
        static string token;
        // GET: CustomerQueryController
        public async Task<ActionResult> Index()
        {
            string userName = User.Identity.Name;
            string role = User.Claims.ToArray()[4].Value;
            string secretKey = "My name is Bond, James Bond the great";
            HttpClient client2 = new HttpClient();
            token = await client2.GetStringAsync("http://localhost:5058/api/QueryResponse/" + userName + "/" + role + "/" + secretKey);
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            List<QueryResponse> queries = await client.GetFromJsonAsync<List<QueryResponse>>("");
            return View(queries);
        }

        // GET: CustomerQueryController/Details/5
        public async Task<ActionResult> Details(string queryID,string srNo)
        {
            QueryResponse query = await client.GetFromJsonAsync<QueryResponse>("" + queryID + srNo);
            return View(query);
        }

        // GET: CustomerQueryController/Create
        public async Task<ActionResult> Create()
        {
            QueryResponse query = new QueryResponse();
            ViewData["token"] = token;
            return View(query);
        }

        // POST: CustomerQueryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(QueryResponse queryresponse)
        {
            try
            {
                await client.PostAsJsonAsync<QueryResponse>("" + token, queryresponse);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomerQueryController/Edit/5
        [Route("CustomerQuery/Edit/{queryID}")]
        public async Task<ActionResult> Edit(string queryID, string srNo)
        {
            QueryResponse query = await client.GetFromJsonAsync<QueryResponse>("" + queryID+ srNo);
            return View(query);
        }

        // POST: CustomerQueryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("QueryResponse/Edit/{queryID}/{srNo}")]
        public async Task<ActionResult> Edit(string queryID, string srNo, QueryResponse qr)
        {
            try
            {
                await client.PutAsJsonAsync<QueryResponse>("" + queryID+srNo, qr);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomerQueryController/Delete/5
        [Route("CustomerQuery/Delete/{queryID}")]
        public async Task<ActionResult> Delete(string queryID,string srNo)
        {
            QueryResponse query = await client.GetFromJsonAsync<QueryResponse>("" + queryID + srNo);
            return View(query);
        }

        // POST: CustomerQueryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("QueryResponse/Delete/{queryID}/{srNo}")]
        public async Task<ActionResult> Delete(string queryID, string srNo, IFormCollection collection)
        {
            try
            {
                await client.DeleteAsync("" + queryID+srNo);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        public async Task<ActionResult> GetByCustomer(string queryId)
        {
            List<QueryResponse> queries = await client.GetFromJsonAsync<List<QueryResponse>>("GetByCustomer/" + queryId);
            return View(queries);
        }
    }
}
