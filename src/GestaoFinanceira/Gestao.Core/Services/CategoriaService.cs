using System;
using Dapper;
using Gestao.Core.Interfaces;
using Gestao.Core.Models;
using System.Collections.Generic;
using System.Text;

namespace Gestao.Core.Services
{
    /// <summary>
    /// Serviço responsável pela gestão do catálogo de categorias (ex: Alimentação, Lazer, Salário).
    /// Fornece métodos para organização e classificação dos movimentos financeiros.
    /// </summary>
    public class CategoriaService : ICategoriaService
    {
        private readonly DbConnectionFactory _dbFactory;

        /// <summary>
        /// Inicializa uma nova instância do serviço de categorias.
        /// </summary>
        /// <param name="dbFactory">A fábrica de conexões para acesso à base de dados SQL Server.</param>
        public CategoriaService(DbConnectionFactory dbFactory)
        {
            _dbFactory = dbFactory;
        }

        /// <summary>
        /// Recupera todas as categorias que estão marcadas como ativas no sistema.
        /// Os resultados são ordenados alfabeticamente para facilitar a seleção em componentes como ComboBoxes.
        /// </summary>
        /// <returns>Uma coleção de categorias disponíveis para classificação de movimentos.</returns>
        public IEnumerable<Categoria> ListarTodas()
        {
            using var db = _dbFactory.CreateConnection();

            // Filtramos por ativo = 1 para evitar que categorias descontinuadas apareçam na interface
            // A ordenação ASC (A-Z) garante uma interface mais organizada para o utilizador
            return db.Query<Categoria>("SELECT * FROM Categoria WHERE ativo = 1 ORDER BY nome ASC");
        }

        /// <summary>
        /// Regista uma nova categoria no sistema.
        /// Por padrão, a categoria é criada com o estado 'ativo' definido como verdadeiro.
        /// </summary>
        /// <param name="categoria">Objeto contendo os dados da categoria a ser inserida.</param>
        public void CriarCategoria(Categoria categoria)
        {
            using var db = _dbFactory.CreateConnection();

            // Inserimos o nome fornecido e forçamos o estado ativo para 1
            string sql = "INSERT INTO Categoria (nome, ativo) VALUES (@Nome, 1)";

            db.Execute(sql, categoria);
        }
    }
}
