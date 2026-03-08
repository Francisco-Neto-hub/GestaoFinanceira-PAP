namespace Finance.Core.Models;

public partial class EstadoCliente
{
    public int IdEstado { get; set; }

    public string Designacao { get; set; } = null!;

    public virtual ICollection<Cliente> Clientes { get; set; } = new List<Cliente>();
}
