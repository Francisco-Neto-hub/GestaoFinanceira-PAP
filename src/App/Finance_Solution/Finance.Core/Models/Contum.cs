namespace Finance.Core.Models;

public partial class Contum
{
    public int IdConta { get; set; }

    public string NomeConta { get; set; } = null!;

    public int? IdEstadoConta { get; set; }

    public decimal? Montante { get; set; }

    public DateOnly DataInicio { get; set; }

    public DateOnly? DataFim { get; set; }

    public int? IdContrato { get; set; }

    public virtual Contrato? IdContratoNavigation { get; set; }

    public virtual EstadoContum? IdEstadoContaNavigation { get; set; }

    public virtual ICollection<Transacao> Transacaos { get; set; } = new List<Transacao>();
}
