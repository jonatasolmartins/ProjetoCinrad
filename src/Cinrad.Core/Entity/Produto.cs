using System;

namespace Cinrad.Core.Entity
{
    public class Produto : Entity
    {
        public Produto()
        {

        }
        public Guid Codigo {get; set;}
        public string Nome { get; set; }
        public string Descrisao { get; set; }
        public bool IsDadosObrigatorio { get; set; }
        public Guid CodigoCor { get; set; }
        public string UnidadeMedida { get; set; }
        public string UnidadeVenda { get; set; }
    }
}
