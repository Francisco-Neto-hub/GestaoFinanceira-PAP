namespace Finance.Core.Models;

public partial class Categorium
{
    public int IdCategoria { get; set; }

    public string Nome { get; set; } = null!;

    public virtual ICollection<Transacao> Transacaos { get; set; } = new List<Transacao>();
}
