using System;
using System.Collections.Generic;
using System.Text;
using BCrypt.Net;

namespace Gestao.Core.Helpers
{
    /// <summary>
    /// Utilitário de segurança para processamento de credenciais.
    /// Utiliza o algoritmo BCrypt para garantir que as passwords nunca sejam armazenadas em texto limpo.
    /// </summary>
    public static class PasswordHasher
    {
        /// <summary>
        /// Gera um hash seguro e único (incluindo salt automático) a partir de uma password.
        /// </summary>
        /// <param name="password">A password original fornecida pelo utilizador.</param>
        /// <returns>Uma string contendo o hash formatado para armazenamento na base de dados.</returns>
        public static string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        /// <summary>
        /// Compara uma password em texto limpo com um hash armazenado para validar a identidade.
        /// </summary>
        /// <param name="password">A password digitada no momento do login.</param>
        /// <param name="hash">O hash recuperado da base de dados.</param>
        /// <returns>True se a password corresponder ao hash.</returns>
        public static bool VerifyPassword(string password, string hash)
        {
            return BCrypt.Net.BCrypt.Verify(password, hash);
        }
    }
}
