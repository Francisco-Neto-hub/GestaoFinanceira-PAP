namespace Finance.Core.Models;

public partial class ContratoCliente
{
    public int IdContrato { get; set; }

    public int IdCliente { get; set; }

    public int? IdEstadoContratoCliente { get; set; }

    public virtual Cliente IdClienteNavigation { get; set; } = null!;

    public virtual Contrato IdContratoNavigation { get; set; } = null!;

    public virtual EstadoContratoCliente? IdEstadoContratoClienteNavigation { get; set; }
}
