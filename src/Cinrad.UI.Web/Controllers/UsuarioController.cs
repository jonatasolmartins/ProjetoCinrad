﻿using Cinrad.Service.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Cinrad.UI.Web.Controllers
{
    [Authorize("RequireSuperUserRole")]
    public class UsuarioController : BaseController
    {

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Usuarios = Service.UsuarioService.ObterTodos();
            return View();
        }

        // GET: Usuario/Details/5
        [HttpGet]
        [ValidateAntiForgeryToken]
        public IActionResult Details(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Registrar(UsuarioViewModel usuario)
        {
            if (ModelState.IsValid)
            {
                var result = await Service.UsuarioService.Adicionar(usuario);
                if (result)
                    return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }

        // POST: Usuario/Create
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

        // GET: Usuario/Edit/5
        public IActionResult Edit(int id)
        {
            return View();
        }

        // POST: Usuario/Edit/5
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

        // GET: Usuario/Delete/5
        public IActionResult Delete(int id)
        {
            return View();
        }

        // POST: Usuario/Delete/5
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
        public ActionResult UsuarioModal()
        {
            return PartialView();
        }
        #endregion
    }
}