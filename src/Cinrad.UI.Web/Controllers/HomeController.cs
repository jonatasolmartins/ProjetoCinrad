using Cinrad.Service.ViewModels;
using Cinrad.UI.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Cinrad.UI.Web.Controllers
{
    public class HomeController : BaseController
    {


        [Authorize("RequireSuperUserRole")]
        public IActionResult Index()
        {
            return View();
        }

              
        [Authorize("RequireSuperUserRole")]        
        public async Task<IActionResult> RegistrarCliente(ClienteViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {

                //await Service.UsuarioService.Adicionar(model);            

            }

            return View(model);
        }
                 

        [Authorize("RequireSuperUserRole")]        
        public async Task<IActionResult> RegistrarTransportadora(TransportadoraViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {               
                
            }

            return View(model);
        }

       
        [Authorize("RequireSuperUserRole")]
        public async Task<IActionResult> Pedidos(PedidoViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {                
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

        #endregion

    }
}
