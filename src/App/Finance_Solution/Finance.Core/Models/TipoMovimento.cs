namespace Finance.Core.Models;

public partial class TipoMovimento
{
    public int IdTipo { get; set; }

    public string Descricao { get; set; } = null!;

    public virtual ICollection<Transacao> Transacaos { get; set; } = new List<Transacao>();
}
