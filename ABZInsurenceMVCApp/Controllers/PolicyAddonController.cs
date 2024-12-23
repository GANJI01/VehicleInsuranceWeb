using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ABZInsurenceMVCApp.Controllers
{
    public class PolicyAddonController : Controller
    {
        // GET: PolicyAddonController
        public ActionResult Index()
        {
            return View();
        }

        // GET: PolicyAddonController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PolicyAddonController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PolicyAddonController/Create
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

        // GET: PolicyAddonController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PolicyAddonController/Edit/5
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

        // GET: PolicyAddonController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PolicyAddonController/Delete/5
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
