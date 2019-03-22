using Cinrad.Infrastructure.CrossCutting.Identity;
using Cinrad.Infrastructure.Repository;
using Cinrad.UI.Web.Models;
using Cinrad.UI.Web.Models.HomeViewsModels;
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
        //private readonly UnitOfWork _unitOfWork;

        public HomeController(UserManager<ApplicationUser> userManager ) //UnitOfWork unitOfWork
        {
            _userManager = userManager;
            //_unitOfWork = unitOfWork;
        }

        [Authorize("RequireSuperUserRole")]       
        public IActionResult Index()
        {
            return View();
        }


        [Authorize("RequireSuperUserRole")]       
        public async Task<IActionResult> RegistrarUsuario(UsuarioViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                //_unitOfWork.UsuarioRepository.Adicionar(model);
                var user = await _userManager.FindByEmailAsync("jonatas@jom.io.com");
            }

            return View(model);
        }
              
        
        [Authorize("RequireSuperUserRole")]        
        public async Task<IActionResult> RegistrarCliente(ClienteViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                //await _unitOfWork.ClienteRepository.Adicionar(model); 
                var user = await _userManager.FindByEmailAsync("jonatas@jom.io.com");                

            }

            return View(model);
        }
                 

        [Authorize("RequireSuperUserRole")]        
        public async Task<IActionResult> RegistrarTransportadora(TransportadoraViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                //await _unitOfWork.TransportadoraRepository.Adicionar(model);
                var user = await _userManager.FindByEmailAsync("jonatas@jom.io.com");               
            }

            return View(model);
        }

       
        [Authorize("RequireSuperUserRole")]
        public IActionResult Pedidos()
        {
            return View();
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

    }
}
