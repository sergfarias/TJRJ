using AutoMapper;
using Works.DeveloperEvaluation.Application.Assuntos.ListarAssunto;
using Works.DeveloperEvaluation.Domain.Repositories;
using MediatR;
namespace Works.DeveloperEvaluation.Application.Assuntos.ListarAssunto;

/// <summary>
/// Handler for processing GetProjectCommand requests
/// </summary>
public class ListarAssuntoHandler : IRequestHandler<ListarAssuntoCommand, List<ListarAssuntoResult>>
{
    private readonly IAssuntoRepository _assuntoRepository;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of ListProjectHandler
    /// </summary>
    public ListarAssuntoHandler(
        IAssuntoRepository assuntoRepository,
        IMapper mapper)
    {
        _assuntoRepository = assuntoRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Handles the ListProjectCommand request
    /// </summary>
    public async Task<List<ListarAssuntoResult>> Handle(ListarAssuntoCommand command, CancellationToken cancellationToken)
    {
        var projects = await _assuntoRepository.GetAssuntosAsync(cancellationToken);
        if (projects == null)
            throw new KeyNotFoundException($"Assunto not found");
       
        return _mapper.Map<List<ListarAssuntoResult>>(projects);
    }
}
