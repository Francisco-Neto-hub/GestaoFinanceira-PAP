using System;
using System.Collections.Generic;
using System.Text;

namespace Gestao.Core.Services
{
    /// <summary>
    /// Provede funcionalidades de registo de eventos e erros do sistema (Logging).
    /// Utilizado para persistir falhas técnicas em ficheiros locais para análise posterior.
    /// </summary>
    public static class Logger
    {
        /// <summary>
        /// Regista os detalhes de uma exceção num ficheiro de texto local.
        /// Guarda o carimbo de data/hora, a mensagem de erro e o StackTrace (rastreio da origem do erro).
        /// </summary>
        /// <param name="ex">A exceção capturada que contém os detalhes do erro técnico.</param>
        /// <remarks>
        /// O ficheiro 'error_log.txt' será criado automaticamente na pasta de execução da aplicação
        /// caso ainda não exista.
        /// </remarks>
        public static void LogError(Exception ex)
        {
            // Define o nome/caminho do ficheiro de log
            string logPath = "error_log.txt";

            // Constrói uma mensagem detalhada para facilitar o debug
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"-----------------------------------------------------------");
            sb.AppendLine($"Data/Hora: {DateTime.Now}");
            sb.AppendLine($"Mensagem:  {ex.Message}");
            sb.AppendLine($"StackTrace: {ex.StackTrace}");
            sb.AppendLine($"-----------------------------------------------------------");
            sb.AppendLine();

            try
            {
                // Escreve no ficheiro sem apagar o conteúdo anterior (Append)
                File.AppendAllText(logPath, sb.ToString());
            }
            catch
            {
                // Em caso de falha na escrita do log (ex: permissões de pasta), 
                // o sistema falha silenciosamente para não interromper a execução principal.
            }
        }
    }
}
