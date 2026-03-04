using System;
using System.Collections.Generic;
using Gestao.Core.Models;
using System.Text;

namespace Gestao.Core.Validators
{
    /// <summary>
    /// Responsável por validar as regras de integridade de um Movimento.
    /// </summary>
    public static class MovimentoValidator
    {
        /// <summary>
        /// Verifica se os dados do movimento são consistentes.
        /// </summary>
        /// <param name="movimento">O objeto a ser validado.</param>
        /// <returns>Resultado contendo a lista de erros, se houver.</returns>
        public static ValidationResult Validate(Movimento movimento)
        {
            var result = new ValidationResult();

            if (movimento.Valor <= 0)
                result.AddError("O valor do movimento deve ser maior que zero.");

            if (string.IsNullOrWhiteSpace(movimento.Descricao))
                result.AddError("A descrição é obrigatória.");

            if (movimento.IdConta <= 0)
                result.AddError("É necessário selecionar uma conta válida.");

            if (movimento.IdCategoria <= 0)
                result.AddError("É necessário selecionar uma categoria.");

            if (movimento.Data > System.DateTime.Now.AddDays(1))
                result.AddError("Não é permitido registar movimentos em datas futuras distantes.");

            return result;
        }
    }
}
