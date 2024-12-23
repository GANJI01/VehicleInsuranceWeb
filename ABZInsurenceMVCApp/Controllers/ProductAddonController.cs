using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ABZInsurenceMVCApp.Controllers
{
    public class ProductAddonController : Controller
    {
        // GET: ProductAddonController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ProductAddonController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductAddonController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductAddonController/Create
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

        // GET: ProductAddonController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProductAddonController/Edit/5
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

        // GET: ProductAddonController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductAddonController/Delete/5
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
