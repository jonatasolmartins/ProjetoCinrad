using System;
using System.Collections.Generic;

namespace Cinrad.Core.Entity
{
    public class Cliente : Entity
    {
        public Cliente(Guid codigo, string cnpj, string razaosocial, string nomefantasia, string site)
        {
            this.Codigo = codigo;
            this.Cnpj = cnpj;
            this.RazaoSocial = razaosocial;
            this.NomeFantasia = nomefantasia;
            this.Site = site;
        }

        protected Cliente(){}
        public Guid Codigo { get; set; }
        public string Cnpj { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public string Telefone { get; set; }
        public string Site { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
