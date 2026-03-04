using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Dapper;
using Gestao.Core.Services;
using Gestao.Core.Models;
using System.Linq;

namespace Gestao.Tests.Sevices
{
    public class DbIntegrationTests
    {
        private readonly DbConnectionFactory _dbFactory = new DbConnectionFactory();

        [Fact]
        public void Diagnostico_Config()
        {
            // Forma correta para .NET 6/7/8
            string caminhoBase = System.AppContext.BaseDirectory;
            string nomeConfig = System.AppDomain.CurrentDomain.FriendlyName + ".dll.config";

            // Isto vai imprimir no output do teste o caminho onde o ficheiro DEVE estar
            throw new System.Exception($"O ficheiro deve estar em: {caminhoBase} com o nome: {nomeConfig}");
        }
    }
}
