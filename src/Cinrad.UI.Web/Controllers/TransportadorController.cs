using Cinrad.Service.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cinrad.UI.Web.Controllers
{
    public class TransportadorController : BaseController
    {

        [HttpGet]
        [ValidateAntiForgeryToken]
        public IActionResult Index()
        {
            ViewBag.Transportadoras = Service.TransportadorService.ObterTodos();
            return View();
        }

        // GET: Transportador/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Registrar(TransportadoraViewModel transportadora)
        {
            if (ModelState.IsValid)
            {
                var result = Service.TransportadorService.Adicionar(transportadora);
                if (result)
                    return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Transportador/Details/5
        [HttpGet]
        [ValidateAntiForgeryToken]
        public IActionResult Details(int id)
        {
            return View();
        }

        // POST: Transportador/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Transportador/Edit/5
        [HttpGet]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id)
        {
            return View();
        }

        // POST: Transportador/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Transportador/Delete/5
        [HttpDelete]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            return View();
        }

        // POST: Transportador/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


        #region Partial

        [HttpGet]
        public IActionResult TransportadorModal()
        {
            return PartialView();
        }
        #endregion
    }
}