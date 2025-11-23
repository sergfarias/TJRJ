using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Works.DeveloperEvaluation.Domain.Entities;
using Works.DeveloperEvaluation.Domain.Repositories;
namespace Works.DeveloperEvaluation.ORM.Repositories;

/// <summary>
/// Implementation of ILivroRepository using Entity Framework Core
/// </summary>
public class LivroRepository : ILivroRepository
{
    private readonly Context _context;

    /// <summary>
    /// Initializes a new instance of projectRepository
    /// </summary>
    /// <param name="context">The database context</param>
    public LivroRepository(Context context)
    {
        _context = context;
    }

    /// <summary>
    /// Creates a new Livro in the database
    /// </summary>
    /// <param name="user">The Livro to create</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created project</returns>
    public async Task<Livro> CreateAsync(Livro livro, CancellationToken cancellationToken = default)
    {
        await _context.Livro.AddAsync(livro, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return livro;
    }

    /// <summary>
    /// Update a Livro in the database
    /// </summary>
    /// <param name="Livro">The Livro to update</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The update project</returns>
    public async Task<Livro> UpdateAsync(Livro livro, CancellationToken cancellationToken = default)
    {
        _context.Entry(livro).State = EntityState.Modified;
        await _context.SaveChangesAsync(cancellationToken);
        return livro;
    }

    /// <summary>
    /// Deletes a Livro from the database
    /// </summary>
    /// <param name="id">The unique identifier of the projet to delete</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>True if the project was deleted, false if not found</returns>
    public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        var livro = await GetByIdAsync(id, cancellationToken);
        if (livro == null)
            return false;

        _context.Livro.RemoveRange(livro);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }

    /// <summary>
    /// Retrieves a project by their unique identifier
    /// </summary>
    /// <param name="id">The unique identifier of the project</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The project if found, null otherwise</returns>
    public async Task<Livro?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _context.Livro.FirstOrDefaultAsync(o => o.CodL == id, cancellationToken);
    }

    ///// <summary>
    ///// Retrieves as projects by IdUser 
    ///// </summary>
    ///// <param name="id">The IdUser of the project</param>
    ///// <param name="cancellationToken">Cancellation token</param>
    ///// <returns>The project if found, null otherwise</returns>
    public async Task<List<Livro>?> GetLivrosAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Livro.ToListAsync(cancellationToken: cancellationToken);
    }

    public async Task<List<LivroDetalhesView>> Relatorio(CancellationToken cancellationToken = default)
    {
        try
        {
            var livrosDetalhes = await _context.LivroDetalhesView.ToListAsync(cancellationToken: cancellationToken);
            return livrosDetalhes;
        }
        catch (Exception ex)
        {
            return null;
        }
    }



}
