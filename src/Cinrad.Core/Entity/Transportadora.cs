using System;
using System.Collections.Generic;

namespace Cinrad.Core.Entity
{
    public class Transportadora : Entity
    {
        public Transportadora(Guid codigo, string cnpj, string razaosocial, string nomefantasia, string site)
        {
            Codigo = codigo;
            Cnpj = cnpj;
            RazaoSocial = razaosocial;
            NomeFantasia = nomefantasia;
            Site = site;
        }
        protected Transportadora() { }
        public Guid Codigo { get; set; }
        public string Cnpj { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public string Telefone { get; set; }
        public string Site { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; }
        public virtual ICollection<ClienteTransportadora> ClienteTransportadoras { get; set; }
    }
}
