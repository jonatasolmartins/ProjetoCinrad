using System;
using System.Collections.Generic;
using AutoMapper;
using Cinrad.Core.Entity;
using Cinrad.Infrastructure.Repository;
using Cinrad.Service.Interface;
using Cinrad.Service.ViewModels;

namespace Cinrad.Service.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ProdutoService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public bool Adicionar(ProdutoViewModel produto)
        {
            var prod = _mapper.Map<Produto>(produto);
            //var result = new ClienteValidator().Validate(cli);
            if (prod == null)
                return false;

            _unitOfWork.ProdutoRepository.Adicionar(prod);

            return _unitOfWork.Save() > 0;
        }

        public bool Atualizar(ProdutoViewModel produto)
        {
            throw new NotImplementedException();
        }

        public ProdutoViewModel ObterPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public IList<ProdutoViewModel> ObterTodos()
        {
            return _mapper.Map<IList<ProdutoViewModel>>(_unitOfWork.ProdutoRepository.ObterTodos());
        }

        public bool Remover(ProdutoViewModel produto)
        {
            throw new NotImplementedException();
        }

        public bool Remover(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
