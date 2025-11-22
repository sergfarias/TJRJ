using AutoMapper;
using MediatR;
using Works.DeveloperEvaluation.Domain.Repositories;
namespace Works.DeveloperEvaluation.Application.LivrosAutores.ListarLivroAutor;

/// <summary>
/// Handler for processing GetProjectCommand requests
/// </summary>
public class ListarLivroAutorHandler : IRequestHandler<ListarLivroAutorCommand, List<ListarLivroAutorResult>>
{
    private readonly ILivroAutorRepository _livroAutorRepository;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of ListProjectHandler
    /// </summary>
    public ListarLivroAutorHandler(
        ILivroAutorRepository livroAutorRepository,
        IMapper mapper)
    {
        _livroAutorRepository = livroAutorRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Handles the ListProjectCommand request
    /// </summary>
    public async Task<List<ListarLivroAutorResult>> Handle(ListarLivroAutorCommand command, CancellationToken cancellationToken)
    {
        var projects = await _livroAutorRepository.GetLivrosAsync(cancellationToken);
        if (projects == null)
            throw new KeyNotFoundException($"Projects not found");
       
        return _mapper.Map<List<ListarLivroAutorResult>>(projects);
    }
}
