using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NuGet.Common;

namespace ABZVehicleInsuranceMVCAPP.Models
{
    public class ForeignKeyHelper
    {
        public static async Task<List<SelectListItem>> GetAgentIds(string token)
        {
            HttpClient client = new HttpClient() { BaseAddress = new Uri("http://localhost:5172/AgentSvc/") };
           // HttpClient client = new HttpClient() { BaseAddress = new Uri(" https://abzAgentwebapi-chanad.azurewebsites.net/api/Agent/") };

            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            List<Agent> agents = await client.GetFromJsonAsync<List<Agent>>("");
            List<SelectListItem> aIds = new List<SelectListItem>();
            foreach (Agent agent in agents)
            {
                aIds.Add(new SelectListItem { Text = agent.AgentID.ToString(), Value = agent.AgentID.ToString() });

            }
            return aIds;
        }
        

        public static async Task<List<SelectListItem>> GetCustomerIds(string token)
        {
           HttpClient client = new HttpClient() { BaseAddress = new Uri("http://localhost:5172/CustomerSvc/") };
           // HttpClient client = new HttpClient() { BaseAddress = new Uri(" https://abzcustomerwebapi-chanad.azurewebsites.net/api/Customer/") };

            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            List<Customer> customers = await client.GetFromJsonAsync<List<Customer>>("");
            List<SelectListItem> cIds=new List<SelectListItem>();
            foreach (Customer customer in customers)
            {
                cIds.Add(new SelectListItem { Text = customer.CustomerID.ToString(), Value = customer.CustomerID.ToString() });

            }
            return cIds;
        }
        public static async Task<List<SelectListItem>> GetCustomerQueryIds(string token)
        {
            HttpClient client = new HttpClient() { BaseAddress = new Uri("http://localhost:5172/CustomerQuerySvc/") };
            //HttpClient client = new HttpClient() { BaseAddress = new Uri("http://abzcustomerwebapi-akshitha.azurewebsites.net/api/customer/") };

            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            List<CustomerQuery> cqs = await client.GetFromJsonAsync<List<CustomerQuery>>("");
            List<SelectListItem> queryIds = new List<SelectListItem>();
            foreach (CustomerQuery c in cqs)
            {
                queryIds.Add(new SelectListItem { Text = c.QueryID.ToString(), Value = c.QueryID.ToString() });
            }
            return queryIds;
        }

        public static async Task<List<SelectListItem>> GetPolicyNos(string token)
        {
             HttpClient client = new HttpClient() { BaseAddress = new Uri("http://localhost:5172/PolicySvc/") };
           // HttpClient client = new HttpClient() { BaseAddress = new Uri(" https://abzpolicywebapi-chanad.azurewebsites.net/api/Policy/") };

            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            List<Policy> policies = await client.GetFromJsonAsync<List<Policy>>("");
            List<SelectListItem> poIds = new List<SelectListItem>();
            foreach (Policy policy in policies)
            {
                poIds.Add(new SelectListItem { Text = policy.PolicyNo.ToString(), Value = policy.PolicyNo.ToString() });

            }
            return poIds;
        }
        public static async Task<List<SelectListItem>> GetProductIds(string token)
        {
            HttpClient client = new HttpClient() { BaseAddress = new Uri("http://localhost:5172/ProductSvc/") };
           // HttpClient client = new HttpClient() { BaseAddress = new Uri(" https://abzproductwebapi-chanad.azurewebsites.net/api/Product/") };

            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            List<Product> products = await client.GetFromJsonAsync<List<Product>>("");
            List<SelectListItem> proIds = new List<SelectListItem>();
            foreach (Product product in products)
            {
                proIds.Add(new SelectListItem { Text = product.ProductID.ToString(), Value = product.ProductID.ToString() });

            }
            return proIds;
        }
        public static async Task<List<SelectListItem>> GetProposalNos(string token)
        {
            HttpClient client = new HttpClient() { BaseAddress = new Uri("http://localhost:5172/ProposalSvc/") };
           // HttpClient client = new HttpClient() { BaseAddress = new Uri(" https://abzproposalwebapi-chanad.azurewebsites.net/api/Proposal/") };
       
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            List<Proposal> proposals = await client.GetFromJsonAsync<List<Proposal>>("");
            List<SelectListItem> propIds = new List<SelectListItem>();
            foreach (Proposal proposal in proposals)
            {
                propIds.Add(new SelectListItem { Text = proposal.ProposalNo.ToString(), Value = proposal.ProposalNo.ToString() });

            }
            return propIds;
        }
        public static async Task<List<SelectListItem>> GetVehicleIds(string token)
        {
            HttpClient client = new HttpClient() { BaseAddress = new Uri("http://localhost:5172/VehicleSvc/") };
            //HttpClient client = new HttpClient() { BaseAddress = new Uri(" https://abzvehiclewebapi-chanad.azurewebsites.net/api/Vehicle/") };

            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            List<Vehicle> vehicles = await client.GetFromJsonAsync<List<Vehicle>>("");
            List<SelectListItem> regNos = new List<SelectListItem>();
            foreach (Vehicle vehicle in vehicles)
            {
                regNos.Add(new SelectListItem { Text = vehicle.RegNo.ToString(), Value = vehicle.RegNo.ToString() });

            }
            return regNos;
        }
    }
}
