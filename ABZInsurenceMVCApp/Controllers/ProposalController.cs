using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ABZInsurenceMVCApp.Controllers
{
    public class ProposalController : Controller
    {
        // GET: ProposalController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ProposalController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProposalController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProposalController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProposalController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProposalController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProposalController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProposalController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
