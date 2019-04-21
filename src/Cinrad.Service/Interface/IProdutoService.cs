using Cinrad.Service.ViewModels;
using System;
using System.Collections.Generic;

namespace Cinrad.Service.Interface
{
    public interface IProdutoService
    {
        bool Adicionar(ProdutoViewModel produto);
        bool Atualizar(ProdutoViewModel produto);
        bool Remover(ProdutoViewModel produto);
        bool Remover(Guid id);
        ProdutoViewModel ObterPorId(Guid id);
        IList<ProdutoViewModel> ObterTodos();
    }
}
