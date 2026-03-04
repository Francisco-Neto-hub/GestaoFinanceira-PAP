using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace Gestao.Core.Services
{
    /// <summary>
    /// Fábrica responsável pela criação e configuração de conexões com a Base de Dados SQL Server.
    /// </summary>
    public class DbConnectionFactory
    {
        /// <summary>
        /// Cria uma nova instância de conexão SQL. 
        /// Tenta ler a ConnectionString do App.config; caso falhe, utiliza uma configuração local de fallback.
        /// </summary>
        /// <returns>Uma implementação de <see cref="IDbConnection"/> pronta a ser aberta.</returns>
        public IDbConnection CreateConnection()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["FinanceDB"]?.ConnectionString;

            if (string.IsNullOrEmpty(connectionString))
            {
                // Fallback para ambiente de desenvolvimento/testes
                connectionString = "Server=.;Database=BD_Finance_v1;Trusted_Connection=True;TrustServerCertificate=True;";
            }

            return new SqlConnection(connectionString);
        }
    }
}
