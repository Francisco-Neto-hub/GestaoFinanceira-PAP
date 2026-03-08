namespace Finance.Core.Models;

public partial class Transacao
{
    public int IdTransacao { get; set; }

    public int IdConta { get; set; }

    public int? IdEstadoTransacao { get; set; }

    public string NomeTransacao { get; set; } = null!;

    public DateTime DataTransacao { get; set; }

    public decimal ValorTransacao { get; set; }

    public int? IdCategoria { get; set; }

    public int? IdTipo { get; set; }

    public virtual Categorium? IdCategoriaNavigation { get; set; }

    public virtual Contum IdContaNavigation { get; set; } = null!;

    public virtual EstadoTransacao? IdEstadoTransacaoNavigation { get; set; }

    public virtual TipoMovimento? IdTipoNavigation { get; set; }
}
