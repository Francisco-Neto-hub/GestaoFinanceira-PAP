using System;
using System.Collections.Generic;
using System.Text;
using Gestao.Core.Models;

namespace Gestao.Core.Interfaces
{
    /// <summary>
    /// Define o contrato para operações financeiras e gestão de movimentos.
    /// </summary>
    public interface IMovimentoService
    {
        /// <summary>
        /// Efetua o registo de uma nova transação (Entrada ou Saída).
        /// </summary>
        /// <param name="movimento">Dados da transação.</param>
        void RegistarMovimento(Movimento movimento);

        /// <summary>
        /// Recupera o histórico de transações de uma determinada conta.
        /// </summary>
        /// <param name="idConta">Identificador da conta.</param>
        /// <returns>Lista de movimentos ordenados por data.</returns>
        IEnumerable<Movimento> ListarPorConta(int idConta);

        /// <summary>
        /// Realiza a eliminação lógica de um movimento. 
        /// Altera o estado para inativo (ativo = 0) sem remover o registo físico.
        /// </summary>
        /// <param name="idMovimento">ID do movimento a desativar.</param>
        void DesativarMovimento(int idMovimento);
    }
}
