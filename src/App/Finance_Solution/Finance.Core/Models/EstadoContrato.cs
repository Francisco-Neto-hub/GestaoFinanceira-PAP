namespace Finance.Core.Models;

public partial class EstadoContrato
{
    public int IdEstado { get; set; }

    public string Designacao { get; set; } = null!;

    public virtual ICollection<Contrato> Contratos { get; set; } = new List<Contrato>();
}
