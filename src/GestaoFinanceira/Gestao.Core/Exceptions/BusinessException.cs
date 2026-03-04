using System;
using System.Collections.Generic;
using System.Text;

namespace Gestao.Core.Exceptions
{
    /// <summary>
    /// Exceção lançada quando uma regra de negócio é violada (ex: saldo insuficiente ou valores inválidos).
    /// </summary>
    public class BusinessException : Exception
    {
        /// <summary>
        /// Inicializa uma nova instância de erro de negócio.
        /// </summary>
        /// <param name="message">A descrição detalhada da regra violada.</param>
        public BusinessException(string message) : base(message) { }
    }
}
