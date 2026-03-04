using System;
using System.Collections.Generic;
using System.Text;

namespace Gestao.Core.Models
{
    /// <summary>
    /// Modelo auxiliar para transporte de dados estatísticos.
    /// Não possui tabela direta na BD; resulta de consultas de agregação (SUM/GROUP BY).
    /// </summary>
    public class RelatorioCategoria
    {
        /// <summary> Nome da categoria (ex: "Lazer"). </summary>
        public string CategoriaNome { get; set; }

        /// <summary> Somatório total gasto nesta categoria. </summary>
        public decimal TotalGasto { get; set; }

        /// <summary> Peso percentual desta categoria face ao total de gastos. </summary>
        public double Percentagem { get; set; }
    }
}
