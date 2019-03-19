
namespace Cinrad.Core.Entity
{
    public class UsuarioCliente : Entity
    {       
       public int UsuarioId { get; set; }
       public int ClienteId { get; set; }
       public virtual Cliente Cliente { get; set; }
       public virtual Usuario Usuario { get; set; }
    }
}
