using Cinrad.Service.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Cinrad.UI.Web.Controllers
{
    public class ProdutoController : BaseController
    {
        public IActionResult Index()
        {
            ViewBag.Produtos = Service.ProdutoService.ObterTodos();
            return View();
        }

        // GET: Produto/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Registrar(ProdutoViewModel produto)
        {
            if (ModelState.IsValid)
            {

                var result = Service.ProdutoService.Adicionar(produto);
                if (!result)
                    ModelState.AddModelError(string.Empty, "Tentativa de cadastro falhou!");
            }

            return RedirectToAction(nameof(Index));
        }
        

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(ProdutoViewModel produto)
        {
            if (ModelState.IsValid)
            {
                if (!Service.ProdutoService.Atualizar(produto))
                    ModelState.AddModelError(string.Empty, "Falha ao atualizar cadastro!");
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: Cliente/Delete/5
        [HttpGet]
        public IActionResult Remover(Guid id)
        {
            if (!Service.ProdutoService.Remover(id))
                ModelState.AddModelError(string.Empty, "Falha ao excluir cadastro!");

            return RedirectToAction(nameof(Index));
        }
        
        #region Partial
        [HttpGet]
        public IActionResult ProdutoModal()
        {
            return PartialView();
        }


        [HttpGet]
        public IActionResult EditarModal(Guid id)
        {
            var produto = Service.ProdutoService.ObterPorId(id);
            if (produto == null)
                return PartialView();


            return PartialView(produto);
        }


        [HttpGet]
        public IActionResult RemoverModal(Guid id)
        {
            var produto = Service.ProdutoService.ObterPorId(id);
            if (produto != null)
                ViewBag.Id = produto.Id;

            return PartialView();
        }

        #endregion
    }

}

