using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Gestao.Core.Validators
{
    /// <summary>
    /// Representa o resultado de uma operação de validação.
    /// </summary>
    public class ValidationResult
    {
        public List<string> Errors { get; } = new List<string>();
        public bool IsValid => !Errors.Any();

        public void AddError(string message) => Errors.Add(message);
    }
}
