using Cinrad.Service.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cinrad.UI.Web.Controllers
{
    [Authorize("RequireSuperUserRole")]
    public class ClienteController : BaseController
    {
        // GET: Cliente
        public IActionResult Index()
        {
            ViewBag.Clientes = Service.ClienteService.ObterTodos();
            return View();
        }

        // GET: Cliente/Details/5
        [HttpGet]
        [ValidateAntiForgeryToken]
        public IActionResult Details(int id)
        {
            return View();
        }

        // GET: Cliente/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Registrar(ClienteViewModel cliente)
        {
            if (ModelState.IsValid)
            {
                var result = Service.ClienteService.Adicionar(cliente);
                if (result)
                    return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }

        // POST: Cliente/Create
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

        // GET: Cliente/Edit/5
        [HttpGet]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id)
        {
            return View();
        }

        // POST: Cliente/Edit/5
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

        // GET: Cliente/Delete/5
        [HttpGet]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            return View();
        }

        // POST: Cliente/Delete/5
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
        public IActionResult ClienteModal()
        {
            return PartialView();
        }
        #endregion
    }
}