using Cinrad.Core.Interface;
using System;
namespace Cinrad.Core.Entity
{
    public class Usuario : Entity, IIsDeleted
    {
        public Usuario(string nome, string email)
        {
            Nome = nome;
            Email = email;
            IsAtivo = true;
        }            
        
        protected Usuario(){}

        public void SetId(Guid id)
        {
            Id = id;
        }

        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string CPF { get; private set; }
        public string Celular { get; private set; }
        public string Telefone { get; private set; }
        public bool IsAtivo { get; set; }
        public Guid? ClienteId { get; set; }
        public virtual Cliente Cliente { get; set; }
        public Guid? TransportadoraId { get; set; }
        public virtual Transportadora Transportadora { get; set; }
    }
}
