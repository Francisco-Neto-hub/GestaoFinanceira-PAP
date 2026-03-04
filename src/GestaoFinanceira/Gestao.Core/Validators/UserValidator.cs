using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Gestao.Core.Models;

namespace Gestao.Core.Validators
{
    /// <summary>
    /// Valida regras de criação de utilizadores e segurança de passwords.
    /// </summary>
    public static class UserValidator
    {
        public static ValidationResult Validate(Utilizador utilizador, string passwordAberta)
        {
            var result = new ValidationResult();

            if (string.IsNullOrWhiteSpace(utilizador.Nome) || utilizador.Nome.Length < 3)
                result.AddError("O nome deve ter pelo menos 3 caracteres.");

            // Regex simples para validar formato de e-mail
            if (!Regex.IsMatch(utilizador.Email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                result.AddError("O formato do e-mail é inválido.");

            if (string.IsNullOrWhiteSpace(passwordAberta) || passwordAberta.Length < 6)
                result.AddError("A password deve ter no mínimo 6 caracteres.");

            return result;
        }
    }
}
