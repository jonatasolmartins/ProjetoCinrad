using Cinrad.Infrastructure.Data;
using System;

namespace Cinrad.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CinradContext _context;
        private readonly UsuarioRepository _usuarioRepository;
        private readonly ClienteRepository _clienteRepository;
        private readonly TransportadoraRepository _transportadoraRepository;

        public UnitOfWork(CinradContext context)
        {
            _context = context;
        }

        public UsuarioRepository UsuarioRepository
        {
            get
            {
                return _usuarioRepository ?? new UsuarioRepository(_context);
            }
        }

        public ClienteRepository ClienteRepository
        {
            get
            {
                return _clienteRepository ?? new ClienteRepository(_context);
            }
        }

        public TransportadoraRepository TransportadoraRepository
        {
            get
            {
                return _transportadoraRepository ?? new TransportadoraRepository(_context);
            }
        }

        public void Save()
        {
            _context.SaveChanges();
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