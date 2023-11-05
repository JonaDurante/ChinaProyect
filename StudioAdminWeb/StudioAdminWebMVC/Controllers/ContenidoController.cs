using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace StudioAdminWebMVC.Controllers
{
    public class ContenidoController : Controller
    {
        // GET: ContenidoController
        public ActionResult Videos()
        {
            return View();
        }

        // GET: ContenidoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ContenidoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ContenidoController/Create
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

        // GET: ContenidoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ContenidoController/Edit/5
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

        // GET: ContenidoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ContenidoController/Delete/5
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
