using AutoMapper;
using MediatR;
using Works.DeveloperEvaluation.Domain.Repositories;
namespace Works.DeveloperEvaluation.Application.LivrosAssuntos.ListarLivroAssunto;

/// <summary>
/// Handler for processing GetProjectCommand requests
/// </summary>
public class ListarLivroAssuntoHandler : IRequestHandler<ListarLivroAssuntoCommand, List<ListarLivroAssuntoResult>>
{
    private readonly ILivroAssuntoRepository _livroAssuntoRepository;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of ListProjectHandler
    /// </summary>
    public ListarLivroAssuntoHandler(
        ILivroAssuntoRepository livroAssuntoRepository,
        IMapper mapper)
    {
        _livroAssuntoRepository = livroAssuntoRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Handles the ListProjectCommand request
    /// </summary>
    public async Task<List<ListarLivroAssuntoResult>> Handle(ListarLivroAssuntoCommand command, CancellationToken cancellationToken)
    {
        var projects = await _livroAssuntoRepository.GetLivrosAsync(cancellationToken);
        if (projects == null)
            throw new KeyNotFoundException($"Projects not found");
       
        return _mapper.Map<List<ListarLivroAssuntoResult>>(projects);
    }
}
