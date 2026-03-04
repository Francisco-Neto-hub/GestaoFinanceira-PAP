using System;
using System.Collections.Generic;
using System.Text;

namespace Gestao.Core.Enums
{
    /// <summary>
    /// Define os tipos de transação permitidos no sistema.
    /// Os valores correspondem exatamente aos IDs definidos na tabela 'Tipo_Movimento' do SQL.
    /// </summary>
    public enum TipoMovimento
    {
        /// <summary> Representa uma entrada de capital (Receita). ID: 1 </summary>
        Entrada = 1,

        /// <summary> Representa uma saída de capital (Despesa). ID: 2 </summary>
        Saida = 2
    }
}
