using System;
using System.ComponentModel.DataAnnotations;

namespace Cinrad.Service.ViewModels
{
    public class TransportadoraViewModel
    {
        public Guid Id { get; set; }

        [Display(Name = "Código")]
        [MaxLength(50)]
        public Guid? Codigo { get; set; }

        [Required]
        [Display(Name = "CNPJ")]
        [MaxLength(14)]
        public string Cnpj { get; set; }

        [Required]
        [Display(Name = "Razão Social")]
        [MaxLength(100)]
        public string RazaoSocial { get; set; }

        [Display(Name = "Nome Fantasia")]
        [MaxLength(100)]
        public string NomeFantasia { get; set; }

        [Display(Name = "Telefone Corporativo")]
        [MaxLength(20)]
        public string Telefone { get; set; }

        [Display(Name = "Site Institucional")]
        [MaxLength(80)]
        public string Site { get; set; }
    }
}
