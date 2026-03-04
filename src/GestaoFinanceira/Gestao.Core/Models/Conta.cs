using System;
using System.Collections.Generic;
using System.Text;

namespace Gestao.Core.Models
{
    /// <summary>
    /// Representa uma conta bancária ou carteira do utilizador.
    /// Mapeia a tabela 'Conta' da base de dados.
    /// </summary>
    public class Conta
    {
        /// <summary> Identificador único da conta (Primary Key). </summary>
        public int IdConta { get; set; }

        /// <summary> Nome descritivo da conta (ex: "Conta Ordenado", "Poupança"). </summary>
        public string Nome { get; set; } = string.Empty;

        /// <summary> Valor com que a conta foi aberta. </summary>
        public decimal SaldoInicial { get; set; }

        /// <summary> ID do utilizador proprietário desta conta. </summary>
        public int IdUtilizador { get; set; }

        /// <summary> 
        /// Estado da conta. Reflete o campo BIT do SQL. 
        /// Se falso, a conta é considerada 'arquivada'.
        /// </summary>
        public bool Ativo { get; set; } = true;
    }
}
