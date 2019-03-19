using System;
using System.Collections.Generic;
using System.Text;
using Cinrad.Core.Interface;
namespace Cinrad.Core.Entity
{
    public class Usuario : Entity, IIsDeleted
    {
        public Usuario(){}            
        
        public string Nome { get; set; }
        public string Email { get; set; }
        public string CPF { get; set; }
        public string Celular { get; set; }
        public string Telefone { get; set; }
        public bool IsDeleted { get; set; }
        public Guid? ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public Guid? TransportadoraId { get; set; }
        public Transportadora Transportadora { get; set; }
    }
}
