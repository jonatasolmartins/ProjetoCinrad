using Cinrad.Service.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;

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

        // GET: Cliente/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Registrar(ClienteViewModel cliente)
        {           
            if (ModelState.IsValid)
            {

                var result = Service.ClienteService.Adicionar(cliente);
                if (!result)
                    ModelState.AddModelError(string.Empty, "Tentativa de cadastro falhou!");
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AssociarTransportadora(ClienteTransportadoraViewModel clienteTransportadora)
        {
            if(ModelState.IsValid)
            {
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(ClienteViewModel cliente)
        {
            if (ModelState.IsValid)
            {
                if (!Service.ClienteService.Atualizar(cliente))
                    ModelState.AddModelError(string.Empty, "Falha ao atualizar cadastro!");
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: Cliente/Delete/5
        [HttpGet]        
        public IActionResult Remover(Guid id)
        {
            if (!Service.ClienteService.Remover(id))
                ModelState.AddModelError(string.Empty, "Falha ao excluir cadastro!");

            return RedirectToAction(nameof(Index));
        }


        #region Partial
        [HttpGet]
        public IActionResult ClienteModal()
        {
            return PartialView();
        }

        [HttpGet]
        public IActionResult ClienteTransportadoraModal(Guid id)
        {
            var cliente = Service.ClienteService.ObterPorId(id);
            if (cliente == null)
                return PartialView();

            ViewBag.Transportadoras = new SelectList(Service.TransportadorService.ObterTodos(), "Id", "RazaoSocial");
            ViewBag.Id = cliente.Id;
            ViewBag.ClienteTransportadora = new SelectList(Service.ClienteService.ListarTransportadoras(id), "Id", "TransportadoraId");
            return PartialView();
        }

        [HttpGet]        
        public IActionResult EditarModal(Guid id)
        {
            var cliente = Service.ClienteService.ObterPorId(id);
            if (cliente == null)
                return PartialView();


            return PartialView(cliente);
        }

        [HttpGet]
        public IActionResult RemoverModal(Guid id)
        {
            var cliente = Service.ClienteService.ObterPorId(id);
            if (cliente != null)
                ViewBag.Id = cliente.Id;

            return PartialView();
        }
        #endregion
    }
}