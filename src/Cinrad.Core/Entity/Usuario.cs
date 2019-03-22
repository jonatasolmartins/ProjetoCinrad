﻿using Cinrad.Core.Interface;
using System;
namespace Cinrad.Core.Entity
{
    public class Usuario : Entity, IIsDeleted
    {
        public Usuario(string nome, string email)
        {
            Nome = nome;
            Email = email;
            IsDeleted = false;
        }            
        
        protected Usuario(){}
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string CPF { get; private set; }
        public string Celular { get; private set; }
        public string Telefone { get; private set; }
        public bool IsDeleted { get; set; }
        public Guid? ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public Guid? TransportadoraId { get; set; }
        public Transportadora Transportadora { get; set; }
    }
}