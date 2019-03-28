using Cinrad.Service.ViewModels;
using Cinrad.UI.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Cinrad.UI.Web.Controllers
{
    [Authorize("RequireSuperUserRole")]
    public class HomeController : BaseController
    {

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
       
        [HttpGet]
        public IActionResult Pedidos()
        {      
            return View();
        }

        [HttpPost]
        public IActionResult Pedidos(PedidoViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
            }

            return View(model);
        }

        [HttpGet]        
        public IActionResult Calculadora()
        {
            return View();
        }

        [HttpGet]
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
