using AutoMapper;
using Works.DeveloperEvaluation.Application.Autores.ListarAutor;
using Works.DeveloperEvaluation.Domain.Repositories;
using MediatR;
namespace Works.DeveloperEvaluation.Application.Autores.InserirAutor;

/// <summary>
/// Handler for processing GetProjectCommand requests
/// </summary>
public class ListarAutorHandler : IRequestHandler<ListarAutorCommand, List<ListarAutorResult>>
{
    private readonly IAutorRepository _autorRepository;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of ListProjectHandler
    /// </summary>
    public ListarAutorHandler(
        IAutorRepository autorRepository,
        IMapper mapper)
    {
        _autorRepository = autorRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Handles the ListProjectCommand request
    /// </summary>
    public async Task<List<ListarAutorResult>> Handle(ListarAutorCommand command, CancellationToken cancellationToken)
    {
        var projects = await _autorRepository.GetAutoresAsync(cancellationToken);
        if (projects == null)
            throw new KeyNotFoundException($"Autor not found");
       
        return _mapper.Map<List<ListarAutorResult>>(projects);
    }
}
