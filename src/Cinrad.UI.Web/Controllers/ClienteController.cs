using Cinrad.Service.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
            var cliente = Service.ClienteService.ObterPorId(id);
            if (cliente == null)
                return View();

            return View(cliente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(ClienteViewModel cliente)
        {
            if (ModelState.IsValid)
            {

                if (Service.ClienteService.Atualizar(cliente))
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            ModelState.AddModelError(string.Empty, "Falha ao atualizar cadastro!");
            return View();
        }

        // GET: Cliente/Delete/5
        [HttpGet]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Guid id)
        {
            if (Service.ClienteService.Remover(id))
                ModelState.AddModelError(string.Empty, "Falha ao excluir cadastro!");

            return View();
        }
        

        #region Partial
        public IActionResult ClienteModal()
        {
            return PartialView();
        }

        public IActionResult ClienteTransportadoraModal()
        {
            return PartialView();
        }
        #endregion
    }
}