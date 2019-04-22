using Cinrad.Service.ViewModels;
using Cinrad.UI.Web.Models.AccountViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Cinrad.UI.Web.Controllers
{
    [Authorize("RequireAdminRole")]
    public class UsuarioController : BaseController
    {

        [HttpGet]
        public IActionResult Index(bool status = true)
        {            
            var users = Service.UsuarioService.ObterTodos();
            ViewBag.Usuarios = users.Where(c => c.IsAtivo == status).ToList();

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

        [HttpGet]
       // [ValidateAntiForgeryToken]
        public IActionResult Perfil(Guid id)
        {
            var user = Service.UsuarioService.ObterPorId(id);
            ViewBag.User = user;
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(UsuarioViewModel usuario, RegisterViewModel register = null, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                var result = Service.UsuarioService.Atualizar(usuario);
                if (!result)
                    ModelState.AddModelError(string.Empty, "Falha ao atualizar cadastro!");
            }

            if(!string.IsNullOrEmpty(returnUrl))
               return RedirectToAction(nameof(Perfil), usuario);

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
            
            return PartialView(user);
        }

        [HttpGet]
        public IActionResult PerfilModal(Guid id, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;

            var user = Service.UsuarioService.ObterPorId(id);
            if (user == null)
                return PartialView();           
           
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