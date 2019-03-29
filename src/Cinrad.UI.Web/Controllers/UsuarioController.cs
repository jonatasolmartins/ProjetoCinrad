using Cinrad.Service.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Threading.Tasks;

namespace Cinrad.UI.Web.Controllers
{
    [Authorize("RequireAdminRole")]
    public class UsuarioController : BaseController
    {

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Usuarios = Service.UsuarioService.ObterTodos();

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Registrar(UsuarioViewModel usuario, int perfil)
        {
            if (ModelState.IsValid)
            {
                var result = await Service.UsuarioService.Adicionar(usuario, perfil);
                if (!result)
                    ModelState.AddModelError(string.Empty, "Tentativa de cadastro falhou!");                
            }           

            return RedirectToAction(nameof(Index), ModelState);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(UsuarioViewModel usuario)
        {
            if (ModelState.IsValid)
            {
                var result = Service.UsuarioService.Atualizar(usuario);
                if (!result)
                    ModelState.AddModelError(string.Empty, "Falha ao atualizar cadastro!");
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Remover(Guid id)
        {
            if (!Service.UsuarioService.Remover(id))
                ModelState.AddModelError(string.Empty, "Falha ao excluir cadastro!");

            return RedirectToAction(nameof(Index));
        }

        #region Partial
        [HttpGet]
        public ActionResult UsuarioModal()
        {

            ViewBag.Transportadoras = new SelectList(Service.TransportadorService.ObterTodos(), "Id", "RazaoSocial");
            ViewBag.Clientes = new SelectList(Service.ClienteService.ObterTodos(), "Id", "RazaoSocial");

            return PartialView();
        }

        [HttpGet]
        public IActionResult EditarModal(Guid id)
        {
            var user = Service.UsuarioService.ObterPorId(id);
            if (user == null)
                return PartialView();

            ViewBag.Transportadoras = new SelectList(Service.TransportadorService.ObterTodos(), "Id", "RazaoSocial");
            ViewBag.Clientes = new SelectList(Service.ClienteService.ObterTodos(), "Id", "RazaoSocial");
            //ViewBag.Id = user.Id;

            return PartialView(user);
        }

        [HttpGet]
        public IActionResult RemoverModal(Guid id)
        {
            var user = Service.UsuarioService.ObterPorId(id);
            if (user != null)
                ViewBag.Id = user.Id;


            return PartialView();
        }
        #endregion
    }
}