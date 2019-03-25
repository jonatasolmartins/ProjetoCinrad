using Cinrad.Service.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Cinrad.UI.Web.Controllers
{
    [Authorize("RequireSuperUserRole")]
    public class TransportadorController : BaseController
    {

        [HttpGet]
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
            ModelState.AddModelError(string.Empty, "Tentativa de cadastro falhou!");

            return RedirectToAction(nameof(Index));
        }



        [HttpGet]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(Guid id)
        {
            var transportadora = Service.TransportadorService.ObeterPorId(id);
            if (transportadora == null)
                return View();

            return View(transportadora);
        }

        // POST: Transportador/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(TransportadoraViewModel transportadora)
        {
            if (ModelState.IsValid)
            {
                if (Service.TransportadorService.Atualizar(transportadora))
                    return RedirectToAction(nameof(Index));
            }
            ModelState.AddModelError(string.Empty, "Falhou! ao atualizar cadastro!");

            return View();
        }

        // GET: Transportador/Delete/5
        [HttpDelete]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Guid id)
        {
            if (Service.TransportadorService.Remover(id))
                ModelState.AddModelError(string.Empty, "Falha ao excluir cadastro!");

            return View();
        }     


        #region Partial

        public IActionResult TransportadorModal()
        {
            return PartialView();
        }


        public IActionResult TransportadoraClienteModal()
        {
            return PartialView();
        }
        #endregion
    }
}