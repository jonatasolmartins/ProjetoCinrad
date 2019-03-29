using System.ComponentModel.DataAnnotations;

namespace Cinrad.UI.Web.Models.AccountViewModels
{
    public class LoginViewModel
    {

        [Required]
        [Display(Name = "Nome de Usuário")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }

        [Display(Name = "Lembrar login")]
        public bool RememberMe { get; set; }
    }
}
