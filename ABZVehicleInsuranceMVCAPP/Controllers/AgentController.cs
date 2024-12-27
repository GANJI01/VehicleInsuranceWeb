using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ABZVehicleInsuranceMVCAPP.Controllers;
using ABZVehicleInsuranceMVCAPP.Models;
using System.Runtime.InteropServices;
using NuGet.Common;

namespace ABZVehicleInsuranceMVCAPP.Controllers
{
    public class AgentController : Controller
    {
       // static HttpClient client = new HttpClient() { BaseAddress = new Uri("http://localhost:5147/api/Agent/") };
        static HttpClient client = new HttpClient() { BaseAddress = new Uri("https://abzagentwebapi-chanad.azurewebsites.net/api/Agent/") };

        static string token;
        // GET: AgentController
        public async Task<ActionResult> Index()
        {
            string userName = User.Identity.Name;
            string role = User.Claims.ToArray()[4].Value;
            string secretKey = "My name is Bond, James Bond the great";
            HttpClient client2 = new HttpClient();
           // token = await client2.GetStringAsync("http://localhost:5018/api/Auth/" + userName + "/" + role + "/" + secretKey);
            token = await client2.GetStringAsync("https://abzauthwebapi-chanad.azurewebsites.net/api/Auth/" + userName + "/" + role + "/" + secretKey);

            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);


            List<Agent> agents = await client.GetFromJsonAsync<List<Agent>>("");
            return View(agents);
        }

        // GET: AgentController/Details/5
        public async Task<ActionResult> Details(string agentId)
        {
            Agent agent = await client.GetFromJsonAsync<Agent>("" + agentId);
            return View(agent);
        }

        // GET: AgentController/Create
        public async Task<ActionResult> Create()
        {
            Agent agent = new Agent();
            ViewData["token"] = token;
            return View(agent);
        }

        // POST: AgentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Agent agent)
        {
            try
            {
                await client.PostAsJsonAsync<Agent>("" + token, agent);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AgentController/Edit/5
        [Route("Agent/Edit/{agentId}")]
        public async Task<ActionResult> Edit(string agentId)
        {
            Agent agent = await client.GetFromJsonAsync<Agent>("" + agentId);
            return View(agent);
        }

        // POST: AgentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Agent/Edit/{agentId}")]
        public async Task<ActionResult> Edit(string agentId, Agent agent)
        {
            try
            {
                await client.PutAsJsonAsync<Agent>("" + agentId, agent);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AgentController/Delete/5
        [Route("Agent/Delete/{agentId}")]
        public async Task<ActionResult> Delete(string agentId)
        {
            Agent agent = await client.GetFromJsonAsync<Agent>("" + agentId);
            return View(agent);
        }

        // POST: AgentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Agent/Delete/{agentId}")]
        public async Task<ActionResult> Delete(string agentId, IFormCollection collection)
        {
            try
            {
                await client.DeleteAsync("" + agentId);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
