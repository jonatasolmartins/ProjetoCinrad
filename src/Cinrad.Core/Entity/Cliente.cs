using System;
using System.Collections.Generic;
using System.Text;

namespace Cinrad.Core.Entity
{
    public class Cliente : Entity
    {
     public Cliente(){}
        public int Codigo { get; set; }
        public string  Cnpj { get; set; }   
        public string RazaoSocial { get; set; }   
        public string NomeFantasia { get; set; } 
        public string Telefone { get; set; }
        public string Site { get; set; }
        public ICollection<Usuario> Usuarios{ get; set; }
    }
}
