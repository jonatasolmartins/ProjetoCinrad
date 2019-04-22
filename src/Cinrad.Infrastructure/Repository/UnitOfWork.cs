using Cinrad.Core.Interface.Repository;
using Cinrad.Infrastructure.Data;
using System;

namespace Cinrad.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CinradContext _context;

        public UnitOfWork
            (CinradContext context, IUsuarioRepository usuarioRepository, IClienteRepository clienteRepository,
            IClienteTransportadoraRepository clienteTransportadoraRepository, ITransportadoraRepository transportadoraRepository,
            IProdutoRepository produtoRepository)
        {
            _context = context;
            UsuarioRepository = usuarioRepository;
            ClienteRepository = clienteRepository;
            ClienteTransportadoraRepository = clienteTransportadoraRepository;
            TransportadoraRepository = transportadoraRepository;
            ProdutoRepository = produtoRepository;
            
        }

        public IUsuarioRepository UsuarioRepository { get; }

        public IClienteRepository ClienteRepository { get; }
        public IClienteTransportadoraRepository ClienteTransportadoraRepository { get; }
        public ITransportadoraRepository TransportadoraRepository { get; }
        public IProdutoRepository ProdutoRepository { get; }

        public int Save()
        {
            return _context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}