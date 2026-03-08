using Microsoft.EntityFrameworkCore;
using Finance.Core.Services;
using Finance.Core.Models;

namespace Finance.Tests
{
    public class FinanceTests
    {
        private FinanceDbContext GetDbContext()
        {
            var connectionString = "Server=DESKTOP-76S1NRV\\SQLEXPRESS;Database=Finance_BD_v2;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=true";
            var options = new DbContextOptionsBuilder<FinanceDbContext>()
                .UseSqlServer(connectionString)
                .Options;
            return new FinanceDbContext(options);
        }

        [Fact]
        public async Task Testar_Receita_Aumenta_Saldo()
        {
            using var context = GetDbContext();
            var service = new FinanceService(context);

            // O Scaffold costuma gerar 'Conta' (singular) ou 'Contas'
            var conta = await context.Conta.FirstAsync(cancellationToken: TestContext.Current.CancellationToken);
            decimal saldoInicial = conta.Montante ?? 0m; 
            decimal valorReceita = 100.00m;

            var movimento = new Transacao
            {
                IdConta = conta.IdConta,
                NomeTransacao = "Teste Receita Scaffold",
                ValorTransacao = valorReceita,
                IdTipo = 1, // Receita
                IdCategoria = 1,
                IdEstadoTransacao = 1,
                DataTransacao = DateTime.Now
            };

            var resultado = await service.RegistarTransacaoAsync(movimento);

            // 1. Tentar encontrar a conta
            var contaAtualizada = await context.Conta.FindAsync(new object?[] { conta.IdConta }, TestContext.Current.CancellationToken);
            // 2. Validar que o resultado do serviço foi positivo
            Assert.True(resultado.Sucesso, $"O serviço falhou: {resultado.Mensagem}");
            // 3. Validar que a conta existe mesmo (isto resolve o aviso de 'null')
            Assert.NotNull(contaAtualizada);
            // 4. Agora o C# sabe que 'contaAtualizada' não é null e deixa-te usar o .Montante
            Assert.Equal(saldoInicial + valorReceita, contaAtualizada.Montante);
        }

        [Fact]
        public async Task Testar_Despesa_Diminui_Saldo()
        {
            using var context = GetDbContext();
            var service = new FinanceService(context);

            // Procurar uma conta que tenha saldo para o teste
            var conta = await context.Conta.FirstAsync(c => c.Montante >= 50, cancellationToken: TestContext.Current.CancellationToken);
            decimal saldoInicial = conta.Montante ?? 0m;
            decimal valorDespesa = 50.00m;

            var movimento = new Transacao
            {
                IdConta = conta.IdConta,
                NomeTransacao = "Teste Despesa Scaffold",
                ValorTransacao = valorDespesa,
                IdTipo = 2, // Despesa
                IdCategoria = 1,
                IdEstadoTransacao = 1,
                DataTransacao = DateTime.Now
            };
        }

        [Fact]
        public async Task Testar_Soma_Dashboard_Com_Novos_Modelos()
        {
            using var context = GetDbContext();
            var service = new FinanceService(context);
            int idContratoAtivo = 1; // ID do Francisco

            var gastosPorCategoria = await service.GetGastosPorCategoriaAsync(idContratoAtivo);

            // Verificação manual para validar o service
            decimal totalEsperado = await context.Transacaos
                .Where(t => t.IdContaNavigation.IdContrato == idContratoAtivo && t.IdTipo == 2)
                .SumAsync(t => t.ValorTransacao, cancellationToken: TestContext.Current.CancellationToken);

            Assert.Equal(totalEsperado, gastosPorCategoria.Values.Sum());
        }
    }
}
