using System.ComponentModel.DataAnnotations;

namespace Cinrad.Service.ViewModels
{
    public class UsuarioViewModel
    {
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
        [Display(Name = "Ativar/Desativar Cadastro")]
        public bool IsDeleted { get; set; }
    }
}
