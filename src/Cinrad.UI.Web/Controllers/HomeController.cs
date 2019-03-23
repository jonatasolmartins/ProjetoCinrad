using Cinrad.Infrastructure.CrossCutting.Identity;
using Cinrad.Service.Interface;
using Cinrad.Service.ViewModels;
using Cinrad.UI.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Cinrad.UI.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IService _service;

        public HomeController(UserManager<ApplicationUser> userManager, IService service)
        {
            _userManager = userManager;
            _service = service;
        }

        [Authorize("RequireSuperUserRole")]       
        public IActionResult Index()
        {
            return View();
        }


        [Authorize("RequireSuperUserRole")]
        public IActionResult RegistrarUsuario(UsuarioViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                model = _service.UsuarioService.Adicionar(model);
               
            }

            return View(model);
        }


        [Authorize("RequireSuperUserRole")]        
        public async Task<IActionResult> RegistrarCliente(ClienteViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                
                await _userManager.FindByEmailAsync("jonatas@jom.io.com");                

            }

            return View(model);
        }
                 

        [Authorize("RequireSuperUserRole")]        
        public async Task<IActionResult> RegistrarTransportadora(TransportadoraViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                
                 await _userManager.FindByEmailAsync("jonatas@jom.io.com");               
            }

            return View(model);
        }

       
        [Authorize("RequireSuperUserRole")]
        public async Task<IActionResult> Pedidos(PedidoViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                await _userManager.FindByEmailAsync("jonatas@jom.io.com");
            }

            return View(model);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        #region partial

        public ActionResult ResgistarUsuarioModal()
        {
            return PartialView();
        }

        #endregion

    }
}
