using System;
using System.Collections.Generic;
using System.Text;
using Gestao.Core.Models;

namespace Gestao.Core.Interfaces
{
    /// <summary>
    /// Define as operações de acesso a dados para a entidade Utilizador.
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// Procura um utilizador através do endereço de e-mail.
        /// </summary>
        /// <param name="email">E-mail de login.</param>
        /// <returns>O objeto <see cref="Utilizador"/> se encontrado; caso contrário, null.</returns>
        Utilizador ObterPorEmail(string email);

        /// <summary>
        /// Regista um novo utilizador no sistema. 
        /// A password deve ser enviada já em formato Hash.
        /// </summary>
        /// <param name="utilizador">Dados do novo utilizador.</param>
        void CriarUtilizador(Utilizador utilizador);

        /// <summary>
        /// Verifica se as credenciais de acesso são válidas.
        /// </summary>
        /// <param name="email">E-mail do utilizador.</param>
        /// <param name="password">Password em texto limpo (para validação via BCrypt).</param>
        /// <returns>True se o login for bem-sucedido.</returns>
        bool ValidarLogin(string email, string password);
    }
}
