using Cinrad.Service.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cinrad.UI.Web.Controllers
{
    [Authorize("RequireSuperUserRole")]
    public class UsuarioController : BaseController
    {
        
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.Usuarios = Service.UsuarioService.ObterTodos();
            return View();
        }

        // GET: Usuario/Details/5
        [HttpGet]
        public ActionResult Details(int id)
        {
            return View();
        }

        [HttpPost]        
        public ActionResult Registrar(UsuarioViewModel model, string retutnUrl)
        {
            ViewData["ReturnUrl"] = retutnUrl;
            if (ModelState.IsValid)
            {
                var user = Service.UsuarioService.Adicionar(model);
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(UsuarioModal));
        }

        // POST: Usuario/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: Usuario/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Usuario/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: Usuario/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Usuario/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
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
        public ActionResult UsuarioModal()
        {
            return PartialView();
        }
        #endregion
    }
}