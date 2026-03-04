using System;
using System.Collections.Generic;
using Gestao.Core.Models;
using System.Text;

namespace Gestao.Core.Interfaces
{
    /// <summary>
    /// Define o contrato para a gestão de categorias.
    /// </summary>
    public interface ICategoriaService
    {
        /// <summary>
        /// Obtém a lista completa de categorias ativas no sistema.
        /// </summary>
        /// <returns>Uma coleção de <see cref="Categoria"/>.</returns>
        IEnumerable<Categoria> ListarTodas();

        /// <summary>
        /// Adiciona uma nova categoria ao catálogo do sistema.
        /// </summary>
        /// <param name="categoria">Objeto categoria a ser persistido.</param>
        void CriarCategoria(Categoria categoria);
    }
}
