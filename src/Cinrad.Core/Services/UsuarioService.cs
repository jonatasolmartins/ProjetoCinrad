using Cinrad.Core.Entity;
using Cinrad.Core.Interface.Services;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Cinrad.Core.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioService(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        public Usuario Adicionar(Usuario entity)
        {
            //TODO: Adicionar Regra de Negócio
            //Use Fluent Validation to validate the class propeties
            return _usuarioService.Adicionar(entity);
        }

        public void Atualizar(Usuario entity)
        {
            _usuarioService.Atualizar(entity);
        }

        public IEnumerable<Usuario> Buscar(Expression<Func<Usuario, bool>> predicado)
        {
            return _usuarioService.Buscar(predicado);
        }

        public Usuario ObterPorId(Guid id)
        {
            return _usuarioService.ObterPorId(id);
        }

        public IEnumerable<Usuario> ObterTodos()
        {
            return _usuarioService.ObterTodos();
        }

        public void Remover(Usuario entity)
        {
            _usuarioService.Remover(entity);
        }

        public void Remover(Guid id)
        {
            _usuarioService.Remover(id);
        }
    }
}
