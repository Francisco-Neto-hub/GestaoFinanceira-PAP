using Finance.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Finance.Core.Services
{
    public class AuthService
    {
        private readonly FinanceDbContext _context;

        public AuthService(FinanceDbContext context)
        {
            _context = context;
        }

        public async Task<Cliente?> ValidarCredenciaisAsync(string email, string password)
        {
            // O Scaffold costuma gerar nomes em PascalCase (ex: ByPass em vez de by_pass)
            return await _context.Clientes
                .Include(c => c.IdEstadoClienteNavigation) // Nome gerado pelo Scaffold para a relação
                .FirstOrDefaultAsync(c => c.Email == email &&
                                          c.ByPass == password &&
                                          c.IdEstadoCliente == 1);
        }
    }
}