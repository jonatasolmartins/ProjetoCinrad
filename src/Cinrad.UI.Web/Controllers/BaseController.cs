using Cinrad.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Cinrad.UI.Web.Controllers
{
    public abstract class BaseController : Controller
    {
        private IService _service;
        protected IService Service => _service ?? (_service = (IService)HttpContext?.RequestServices.GetService(typeof(IService)));

    }
}