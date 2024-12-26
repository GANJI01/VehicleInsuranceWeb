using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ABZVehicleInsuranceMVCAPP.Models
{
    //public static async Task<List<SelectListItem>> GetEmpIds()
    //{
    //    HttpClient client = new HttpClient() { BaseAddress = new Uri("http://employeewebapi-snrao.azurewebsites.net/api/Employee/") };
    //    List<Employee> employees = await client.GetFromJsonAsync<List<Employee>>("");
    //    List<SelectListItem> empIds = new List<SelectListItem>();
    //    foreach (Employee employee in employees)
    //    {
    //        empIds.Add(new SelectListItem { Text = employee.EmpId.ToString(), Value = employee.EmpId.ToString() });
    //    }
    //    return empIds;
    public class ForeignKeyHelper
    {
        public static async Task<List<SelectListItem>> GetCustomerIds()
        {
            HttpClient client = new HttpClient() { BaseAddress = new Uri("http://localhost:5151/api/Customer/") };
            List<Customer> customers = await client.GetFromJsonAsync<List<Customer>>("");
            List<SelectListItem> cIds=new List<SelectListItem>();
            foreach (Customer customer in customers)
            {
                cIds.Add(new SelectListItem { Text = customer.CustomerID.ToString(), Value = customer.CustomerID.ToString() });

            }
            return cIds;
        }
        public static async Task<List<SelectListItem>> GetAgentIds()
        {
            HttpClient client = new HttpClient() { BaseAddress = new Uri("http://localhost:5147/api/Agent/") };
            List<Agent> agents = await client.GetFromJsonAsync<List<Agent>>("");
            List<SelectListItem> aIds = new List<SelectListItem>();
            foreach (Agent agent in agents)
            {
                aIds.Add(new SelectListItem { Text = agent.AgentID.ToString(), Value = agent.AgentID.ToString() });

            }
            return aIds;
        }
        public static async Task<List<SelectListItem>> GetPolicyNos()
        {
            HttpClient client = new HttpClient() { BaseAddress = new Uri("http://localhost:5007/api/Policy/") };
            List<Policy> policies = await client.GetFromJsonAsync<List<Policy>>("");
            List<SelectListItem> poIds = new List<SelectListItem>();
            foreach (Policy policy in policies)
            {
                poIds.Add(new SelectListItem { Text = policy.PolicyNo.ToString(), Value = policy.PolicyNo.ToString() });

            }
            return poIds;
        }
        public static async Task<List<SelectListItem>> GetProductIds()
        {
            HttpClient client = new HttpClient() { BaseAddress = new Uri("http://localhost:5145/api/Product/") };
            List<Product> products = await client.GetFromJsonAsync<List<Product>>("");
            List<SelectListItem> proIds = new List<SelectListItem>();
            foreach (Product product in products)
            {
                proIds.Add(new SelectListItem { Text = product.ProductID.ToString(), Value = product.ProductID.ToString() });

            }
            return proIds;
        }
        public static async Task<List<SelectListItem>> GetProposalNos()
        {
            HttpClient client = new HttpClient() { BaseAddress = new Uri("http://localhost:5273/api/Proposal/") };
            List<Proposal> proposals = await client.GetFromJsonAsync<List<Proposal>>("");
            List<SelectListItem> propIds = new List<SelectListItem>();
            foreach (Proposal proposal in proposals)
            {
                propIds.Add(new SelectListItem { Text = proposal.ProposalNo.ToString(), Value = proposal.ProposalNo.ToString() });

            }
            return propIds;
        }
        public static async Task<List<SelectListItem>> GetVehicleIds()
        {
            HttpClient client = new HttpClient() { BaseAddress = new Uri("http://localhost:5083/api/Vehicle/") };
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
