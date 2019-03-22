﻿using System;
using System.Collections.Generic;

namespace Cinrad.Core.Entity
{
    public class Transportadora : Entity
    {
        public Transportadora(Guid codigo, string cnpj, string razaosocial, string nomefantasia, string site)
        {
            this.Codigo = codigo;
            this.Cnpj = cnpj;
            this.RazaoSocial = razaosocial;
            this.NomeFantasia = nomefantasia;
            this.Site = site;
        }
        protected Transportadora() { }
        public Guid Codigo { get; set; }
        public string Cnpj { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public string Telefone { get; set; }
        public string Site { get; set; }
        public ICollection<Usuario> Usuarios { get; set; }
    }
}