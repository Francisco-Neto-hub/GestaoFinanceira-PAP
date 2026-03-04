using System;
using System.Collections.Generic;
using System.Text;

namespace Gestao.Core.Exceptions
{
    /// <summary>
    /// Exceção lançada quando ocorrem falhas críticas na camada de dados (SQL Server).
    /// </summary>
    public class DatabaseException : Exception
    {
        /// <summary>
        /// Inicializa uma nova instância de erro de base de dados.
        /// </summary>
        /// <param name="message">Mensagem amigável para o utilizador.</param>
        /// <param name="inner">A exceção original (SqlException) para fins de log.</param>
        public DatabaseException(string message, Exception inner) : base(message, inner) { }
    }
}
