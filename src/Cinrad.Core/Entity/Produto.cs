using System;
using System.Collections.Generic;
using System.Text;

namespace Cinrad.Core.Entity
{
    public class Produto : Entity
    {
        public Guid Codigo {get; set;}
        public string Nome { get; set; }
        public string Descrisao { get; set; }
        public bool IsDadosObrigatorio { get; set; }
        public Guid CodigoCor { get; set; }
        public string UnidadeMedida { get; set; }
        public string UnidadeVenda { get; set; }
    }
}
