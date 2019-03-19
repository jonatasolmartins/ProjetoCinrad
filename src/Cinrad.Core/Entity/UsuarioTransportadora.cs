
namespace Cinrad.Core.Entity
{
    public class UsuarioTransportadora : Entity
    {      
       public int UsuarioId { get; set; }
       public int TransportadoraId { get; set; }
       public virtual Transportadora Transportadora { get; set; }
       public virtual Usuario Usuario { get; set; }
    }
}
