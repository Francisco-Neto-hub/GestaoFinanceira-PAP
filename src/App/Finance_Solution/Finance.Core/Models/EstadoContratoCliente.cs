namespace Finance.Core.Models;

public partial class EstadoContratoCliente
{
    public int IdEstado { get; set; }

    public string Designacao { get; set; } = null!;

    public virtual ICollection<ContratoCliente> ContratoClientes { get; set; } = new List<ContratoCliente>();
}
