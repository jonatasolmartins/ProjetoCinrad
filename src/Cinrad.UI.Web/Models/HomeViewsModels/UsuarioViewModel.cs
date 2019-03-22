using System.ComponentModel.DataAnnotations;

namespace Cinrad.UI.Web.Models.HomeViewsModels
{
    public class UsuarioViewModel
    {
        [Required]
        [Display(Name = "Nome")]
        [MaxLength(30)]
        public string Nome { get; private set; }

        [Required]
        [EmailAddress]
        [Display(Name = "E-mail")]
        [MaxLength(35)]
        public string Email { get; private set; }

        [Required]
        [Display(Name = "CPF")]
        [MaxLength(11)]
        public string CPF { get; private set; }
       
        [Display(Name = "Celular")]
        [MaxLength(9)]
        public string Celular { get; private set; }
        
        [Display(Name = "Telefone")]
        [MaxLength(8)]
        public string Telefone { get; private set; }
        [Display(Name = "Ativar/Desativar Cadastro")]
        public bool IsDeleted { get; set; }
    }
}
