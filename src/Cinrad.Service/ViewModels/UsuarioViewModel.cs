using System;
using System.ComponentModel.DataAnnotations;

namespace Cinrad.Service.ViewModels
{
    public class UsuarioViewModel
    {
        [Display(Name ="Id")]
        public Guid Id { get; set; }

        [Required]
        [Display(Name = "Nome")]
        [MaxLength(30)]
        public string Nome { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "E-mail")]
        [MaxLength(35)]
        public string Email { get; set; }

        [Required]
        [Display(Name = "CPF")]
        [MaxLength(11)]
        public string CPF { get; set; }

        [Display(Name = "Celular")]
        [MaxLength(9)]
        public string Celular { get; set; }

        [Display(Name = "Telefone")]
        [MaxLength(8)]
        public string Telefone { get; set; }       

        [Display(Name = "ClienteId")]
        public Guid? ClienteId { get; set; }

        [Display(Name = "TransportadraId")]
        public Guid? TransportadraId { get; set; }   

        [Display(Name = "Ativar/Desativar Cadastro")]
        public bool IsDeleted { get; set; }
    }
}
