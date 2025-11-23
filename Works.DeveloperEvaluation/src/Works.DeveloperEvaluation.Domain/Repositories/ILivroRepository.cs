using Works.DeveloperEvaluation.Domain.Entities;

namespace Works.DeveloperEvaluation.Domain.Repositories;

/// <summary>
/// Repository interface for project entity operations
/// </summary>
public interface ILivroRepository
{
    /// <summary>
    /// Creates a new project in the repository
    /// </summary>
    /// <param name="user">The project to create</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created project</returns>
    Task<Livro> CreateAsync(Livro livro, CancellationToken cancellationToken = default);

    /// <summary>
    /// Update a project in the repository
    /// </summary>
    /// <param name="user">The project to update</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The update project</returns>
    Task<Livro> UpdateAsync(Livro livro, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes a project from the database
    /// </summary>
    /// <param name="id">The unique identifier of the project to delete</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>True if the project was deleted, false if not found</returns>
    Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves a project by their unique identifier
    /// </summary>
    /// <param name="id">The unique identifier of the project</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The sale if found, null otherwise</returns>
    Task<Livro?> GetByIdAsync(int id, CancellationToken cancellationToken = default);

    Task<List<Livro>?> GetLivrosAsync(CancellationToken cancellationToken = default);

    Task<List<LivroDetalhesView>> Relatorio(CancellationToken cancellationToken = default);
}
