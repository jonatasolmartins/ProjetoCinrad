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
                if (!result)
                    ModelState.AddModelError(string.Empty, "Tentativa de cadastro falhou!");
            }           

            return RedirectToAction(nameof(Index));
        }        

        // POST: Transportador/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(TransportadoraViewModel transportadora)
        {
            if (ModelState.IsValid)
            {
                if (!Service.TransportadorService.Atualizar(transportadora))
                    ModelState.AddModelError(string.Empty, "Falhou! ao atualizar cadastro!");
            }            

            return RedirectToAction(nameof(Index));
        }

        // GET: Transportador/Delete/5
        [HttpDelete]
        [ValidateAntiForgeryToken]
        public IActionResult Remover(Guid id)
        {
            if (!Service.TransportadorService.Remover(id))
                ModelState.AddModelError(string.Empty, "Falha ao excluir cadastro!");

            return RedirectToAction(nameof(Index));
        }     


        #region Partial
        [HttpGet]
        public IActionResult TransportadorModal()
        {
            return PartialView();
        }


        [HttpGet]
        public IActionResult TransportadoraClienteModal()
        {
            return PartialView();
        }

        
        [HttpGet]
        public IActionResult EditarModal(Guid id)
        {
            var transportadora = Service.TransportadorService.ObeterPorId(id);
            if (transportadora == null)
                return PartialView();

            return PartialView(transportadora);
        }

        [HttpGet]
        public IActionResult RemoverModal(Guid id)
        {
            var cliente = Service.TransportadorService.ObeterPorId(id);
            if (cliente != null)
                ViewBag.Id = cliente.Id;

            return PartialView();
        }
        #endregion
    }
}