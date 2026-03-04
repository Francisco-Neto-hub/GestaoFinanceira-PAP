using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace Gestao.Core.Services
{
    public class DbConnectionFactory
    {
        public IDbConnection CreateConnection()
        {
            // 1. Tenta ler do App.config
            var connectionString = ConfigurationManager.ConnectionStrings["FinanceDB"]?.ConnectionString;

            // 2. Se falhar (como nos testes), usa a string local direta
            if (string.IsNullOrEmpty(connectionString))
            {
                // Substitui pelo teu IP ou '.' se for local
                connectionString = "Server=.;Database=BD_Finance_v1;Trusted_Connection=True;TrustServerCertificate=True;";
            }

            return new SqlConnection(connectionString);
        }
    }
}
