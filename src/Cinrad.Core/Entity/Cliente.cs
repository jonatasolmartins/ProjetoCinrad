﻿using System.Collections.Generic;

namespace Cinrad.Core.Entity
{
    public class Cliente : Entity
    {
        public Cliente(string cnpj, string razaosocial, string nomefantasia, string site)
        {           
            Cnpj = cnpj;
            RazaoSocial = razaosocial;
            NomeFantasia = nomefantasia;
            Site = site;
        }

        protected Cliente(){}       
        public string Cnpj { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public string Telefone { get; set; }
        public string Site { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; }
        public virtual ICollection<ClienteTransportadora> ClienteTransportadoras { get; set; }
       
    }
}
