using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ABZVehicleInsuranceMVCAPP.Models;

namespace ABZVehicleInsuranceMVCAPP.Controllers;

public class CustomerController : Controller
{
    // GET: CustomerController
    static HttpClient client = new HttpClient() { BaseAddress = new Uri("http://localhost:5151/api/Customer/") };
    public async Task<ActionResult> Index()
    {
        List<Customer> customers = await client.GetFromJsonAsync<List<Customer>>("");
        return View(customers);
    }

    // GET: ProposalController/Details/5
    public async Task<ActionResult> Details(string customerID)
    {
        Customer customer = await client.GetFromJsonAsync<Customer>("" + customerID);
        return View(customer);
    }

    // GET: ProposalController/Create
    public ActionResult Create()
    {
        Customer customer = new Customer();
        return View(customer);
    }

    // POST: ProposalController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Create(Customer customer)
    {
        try
        {
            await client.PostAsJsonAsync<Customer>("", customer);
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }

    // GET: ProposalController/Edit/5
    [Route("Customer/Edit/{customerID}")]
    public async Task<ActionResult> Edit(string customerID)
    {
        Customer customer = await client.GetFromJsonAsync<Customer>("" + customerID);
        return View(customer);
    }
    // POST: ProposalController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    [Route("Customer/Edit/{customerID}")]
    public async Task<ActionResult> Edit(string customerID, Customer customer)
    {
        try
        {
            await client.PutAsJsonAsync<Customer>("" + customerID, customer);
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }

    // GET: ProposalController/Delete/5
    [Route("Customer/Delete/{customerID}")]
    public async Task<ActionResult> Delete(string customerID)
    {
        Customer customer = await client.GetFromJsonAsync<Customer>("" + customerID);
        return View(customer);
    }

    // POST: ProposalController/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    [Route("Customer/Delete/{customerID}")]
    public async Task<ActionResult> Delete(string customerID, IFormCollection collection)
    {
        try
        {
            await client.DeleteAsync("" + customerID);
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }
}
