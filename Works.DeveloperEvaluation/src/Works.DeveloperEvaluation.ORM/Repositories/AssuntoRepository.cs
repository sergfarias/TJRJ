using Microsoft.EntityFrameworkCore;
using Works.DeveloperEvaluation.Domain.Entities;
using Works.DeveloperEvaluation.Domain.Repositories;
namespace Works.DeveloperEvaluation.ORM.Repositories;

/// <summary>
/// Implementation of ILivroRepository using Entity Framework Core
/// </summary>
public class AssuntoRepository : IAssuntoRepository
{
    private readonly Context _context;

    /// <summary>
    /// Initializes a new instance of projectRepository
    /// </summary>
    /// <param name="context">The database context</param>
    public AssuntoRepository(Context context)
    {
        _context = context;
    }

    /// <summary>
    /// Creates a new Livro in the database
    /// </summary>
    /// <param name="user">The Livro to create</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created project</returns>
    public async Task<Assunto> CreateAsync(Assunto assunto, CancellationToken cancellationToken = default)
    {
        await _context.Assunto.AddAsync(assunto, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return assunto;
    }

    /// <summary>
    /// Update a Livro in the database
    /// </summary>
    /// <param name="Livro">The Livro to update</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The update project</returns>
    public async Task<Assunto> UpdateAsync(Assunto assunto, CancellationToken cancellationToken = default)
    {
        _context.Entry(assunto).State = EntityState.Modified;
        await _context.SaveChangesAsync(cancellationToken);
        return assunto;
    }

    /// <summary>
    /// Deletes a Livro from the database
    /// </summary>
    /// <param name="id">The unique identifier of the projet to delete</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>True if the project was deleted, false if not found</returns>
    public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        var assunto = await GetByIdAsync(id, cancellationToken);
        if (assunto == null)
            return false;

        _context.Assunto.RemoveRange(assunto);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }

    /// <summary>
    /// Retrieves a project by their unique identifier
    /// </summary>
    /// <param name="id">The unique identifier of the project</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The project if found, null otherwise</returns>
    public async Task<Assunto?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _context.Assunto.FirstOrDefaultAsync(o => o.CodAs == id, cancellationToken);
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
    public async Task<List<Assunto>?> GetAssuntosAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Assunto.ToListAsync(cancellationToken: cancellationToken);
    }

}
