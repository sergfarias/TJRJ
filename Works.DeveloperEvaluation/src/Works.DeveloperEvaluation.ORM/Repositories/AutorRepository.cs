using Microsoft.EntityFrameworkCore;
using Works.DeveloperEvaluation.Domain.Entities;
using Works.DeveloperEvaluation.Domain.Repositories;
namespace Works.DeveloperEvaluation.ORM.Repositories;

/// <summary>
/// Implementation of ILivroRepository using Entity Framework Core
/// </summary>
public class AutorRepository : IAutorRepository
{
    private readonly Context _context;

    /// <summary>
    /// Initializes a new instance of projectRepository
    /// </summary>
    /// <param name="context">The database context</param>
    public AutorRepository(Context context)
    {
        _context = context;
    }

    /// <summary>
    /// Creates a new Livro in the database
    /// </summary>
    /// <param name="user">The Livro to create</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created project</returns>
    public async Task<Autor> CreateAsync(Autor autor, CancellationToken cancellationToken = default)
    {
        await _context.Autor.AddAsync(autor, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return autor;
    }

    /// <summary>
    /// Update a Livro in the database
    /// </summary>
    /// <param name="Livro">The Livro to update</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The update project</returns>
    public async Task<Autor> UpdateAsync(Autor autor, CancellationToken cancellationToken = default)
    {
        _context.Entry(autor).State = EntityState.Modified;
        await _context.SaveChangesAsync(cancellationToken);
        return autor;
    }

    /// <summary>
    /// Deletes a Livro from the database
    /// </summary>
    /// <param name="id">The unique identifier of the projet to delete</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>True if the project was deleted, false if not found</returns>
    public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        var autor = await GetByIdAsync(id, cancellationToken);
        if (autor == null)
            return false;

        _context.Autor.RemoveRange(autor);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }

    /// <summary>
    /// Retrieves a project by their unique identifier
    /// </summary>
    /// <param name="id">The unique identifier of the project</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The project if found, null otherwise</returns>
    public async Task<Autor?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _context.Autor.FirstOrDefaultAsync(o => o.CodAu == id, cancellationToken);
    }

    ///// <summary>
    ///// Retrieves as projects by IdUser 
    ///// </summary>
    ///// <param name="id">The IdUser of the project</param>
    ///// <param name="cancellationToken">Cancellation token</param>
    ///// <returns>The project if found, null otherwise</returns>
    //public async Task<List<Livro>?> GetLivrosAsync(Guid userId, CancellationToken cancellationToken = default)
    //{
    //    return await _context.Livros.Where(a => a.UserId == userId).ToListAsync(cancellationToken: cancellationToken);
    //}


    ///// <summary>
    ///// Retrieves as projects by IdUser 
    ///// </summary>
    ///// <param name="id">The IdUser of the project</param>
    ///// <param name="cancellationToken">Cancellation token</param>
    ///// <returns>The project if found, null otherwise</returns>
    public async Task<List<Autor>?> GetAutoresAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Autor.ToListAsync(cancellationToken: cancellationToken);
    }

}
