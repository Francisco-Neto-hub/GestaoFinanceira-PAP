using System;
using System.Collections.Generic;
using System.Text;

namespace Gestao.Core.Models
{
    /// <summary>
    /// Representa uma transação financeira (receita ou despesa).
    /// </summary>
    public class Movimento
    {
        /// <summary> Identificador único do movimento. </summary>
        public int IdMovimento { get; set; }

        /// <summary> Data em que a transação ocorreu. </summary>
        public DateTime Data { get; set; }

        /// <summary> Valor monetário da transação. </summary>
        public decimal Valor { get; set; }

        /// <summary> Detalhes ou notas sobre a transação. </summary>
        public string Descricao { get; set; } = string.Empty;

        /// <summary> ID da conta onde o movimento foi realizado. </summary>
        public int IdConta { get; set; }

        /// <summary> ID da categoria associada (ex: Alimentação). </summary>
        public int IdCategoria { get; set; }

        /// <summary> ID do tipo (1 para Entrada, 2 para Saída). </summary>
        public int IdTipoMovimento { get; set; }

        /// <summary> Data e hora de inserção no sistema. </summary>
        public DateTime DataCriacao { get; set; } = DateTime.Now;

        /// <summary> Define se o movimento é válido ou foi anulado. </summary>
        public bool Ativo { get; set; } = true;
    }
}
