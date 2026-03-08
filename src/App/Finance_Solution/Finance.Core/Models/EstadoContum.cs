namespace Finance.Core.Models;

public partial class EstadoContum
{
    public int IdEstado { get; set; }

    public string Designacao { get; set; } = null!;

    public virtual ICollection<Contum> Conta { get; set; } = new List<Contum>();
}
