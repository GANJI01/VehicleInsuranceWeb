using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ABZMVCApp.Controllers
{
    public class AgentController : Controller
    {
        // GET: AgentController
        public ActionResult Index()
        {
            return View();
        }

        // GET: AgentController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AgentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AgentController/Create
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

        // GET: AgentController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AgentController/Edit/5
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

        // GET: AgentController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AgentController/Delete/5
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
