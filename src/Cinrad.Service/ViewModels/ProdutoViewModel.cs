using System;

namespace Cinrad.Service.ViewModels
{
    public class ProdutoViewModel
    {
        public Guid Id { get; set; }
        public Guid Codigo { get; set; }
        public string Nome { get; set; }
        public string Descrisao { get; set; }
        public bool IsDadosObrigatorio { get; set; }
        public Guid CodigoCor { get; set; }
        public string UnidadeMedida { get; set; }
        public string UnidadeVenda { get; set; }
    }
}
