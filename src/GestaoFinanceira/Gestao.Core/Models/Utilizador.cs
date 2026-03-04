using System;
using System.Collections.Generic;
using System.Text;

namespace Gestao.Core.Models
{
    /// <summary>
    /// Representa o utilizador do sistema para fins de autenticação e perfil.
    /// </summary>
    public class Utilizador
    {
        /// <summary> Identificador único do utilizador. </summary>
        public int IdUtilizador { get; set; }

        /// <summary> Nome completo ou alcunha do utilizador. </summary>
        public string Nome { get; set; } = string.Empty;

        /// <summary> E-mail utilizado para o Login. </summary>
        public string Email { get; set; } = string.Empty;

        /// <summary> 
        /// Hash seguro da password (BCrypt). 
        /// Nunca deve armazenar a password em texto limpo.
        /// </summary>
        public string PasswordHash { get; set; } = string.Empty;
    }
}
