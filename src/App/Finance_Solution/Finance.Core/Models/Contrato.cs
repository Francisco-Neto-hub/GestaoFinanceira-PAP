namespace Finance.Core.Models;

public partial class Contrato
{
    public int IdContrato { get; set; }

    public DateOnly DataInicio { get; set; }

    public DateOnly? DataFim { get; set; }

    public int? IdEstadoContrato { get; set; }

    public virtual ICollection<Contum> Conta { get; set; } = new List<Contum>();

    public virtual ICollection<ContratoCliente> ContratoClientes { get; set; } = new List<ContratoCliente>();

    public virtual EstadoContrato? IdEstadoContratoNavigation { get; set; }
}
