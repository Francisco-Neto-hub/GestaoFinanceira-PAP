using Dapper;
using Gestao.Core.Helpers;
using Gestao.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gestao.Core.Services
{
    /// <summary>
    /// Serviço de Autenticação e Gestão de Acessos.
    /// </summary>
    public class AuthService
    {
        private readonly DbConnectionFactory _dbFactory;

        public AuthService(DbConnectionFactory dbFactory) => _dbFactory = dbFactory;

        /// <summary>
        /// Valida as credenciais de um utilizador comparando o e-mail e o hash da password.
        /// </summary>
        /// <param name="email">E-mail único do utilizador.</param>
        /// <param name="password">Password em texto limpo enviada pela UI.</param>
        /// <returns>True se as credenciais forem válidas e o utilizador estiver ativo.</returns>
        public bool ValidarUtilizador(string email, string password)
        {
            using var db = _dbFactory.CreateConnection();

            // Procura o utilizador pelo e-mail para obter o hash guardado
            var user = db.QueryFirstOrDefault<Utilizador>(
                "SELECT * FROM Utilizador WHERE email = @email AND ativo = 1",
                new { email });

            if (user == null) return false;

            // Compara a password fornecida com o hash seguro da BD
            return PasswordHasher.VerifyPassword(password, user.PasswordHash);
        }
    }
}
