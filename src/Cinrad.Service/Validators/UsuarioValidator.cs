using Cinrad.Core.Entity;
using FluentValidation;
using System;

namespace Cinrad.Service.Validators
{
    public class UsuarioValidator : AbstractValidator<Usuario>
    {
        protected void ValidateName()
        {
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("O campo Nome não pode é obrigatório!")
                .Length(2, 150).WithMessage("O campo nome deve ter no mínimo 3 letas!");
        }        

        protected void ValidateEmail()
        {
            RuleFor(c => c.Email)
                .NotEmpty()
                .Length(7, 35).WithMessage("O campo E-mail de ter entre 7 e 35 caracteres!")
                .EmailAddress();
        }

        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty);
        }

        protected void ValidateCpf()
        {
            RuleFor(c => c.CPF)
                .NotEmpty().WithMessage("O campo CPF é obrigatório!")
                .Length(11).WithMessage("CPF inválido!");
        }

        protected void ValidateCelular()
        {
            RuleFor(c => c.Celular)
                .Must(IsCelularValid);
        }

        protected void ValidateTelefone()
        {
            RuleFor(c => c.Telefone)
                .Must(IsTelefoneValid);
        }

        protected static bool IsCelularValid(string celular)
        {
            return (celular == null || celular.Length == 9) ? true : false;
        }

        protected static bool IsTelefoneValid(string telefone)
        {
            return (telefone == null || telefone.Length == 9) ? true : false;
        }
        
    }
}
