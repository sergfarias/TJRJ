using AutoMapper;
using MediatR;
using Works.DeveloperEvaluation.Domain.Repositories;
using Works.DeveloperEvaluation.Domain.Entities;
namespace Works.DeveloperEvaluation.Application.Assuntos.BuscarAssunto;

/// <summary>
/// Handler for processing GetProjectCommand requests
/// </summary>
public class BuscarAssuntoHandler : IRequestHandler<BuscarAssuntoCommand, BuscarAssuntoResult>
{
    private readonly IAssuntoRepository _assuntoRepository;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of ListProjectHandler
    /// </summary>
    public BuscarAssuntoHandler(
        IAssuntoRepository assuntoRepository,
        IMapper mapper)
    {
        _assuntoRepository = assuntoRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Handles the ListProjectCommand request
    /// </summary>
    public async Task<BuscarAssuntoResult> Handle(BuscarAssuntoCommand command, CancellationToken cancellationToken)
    {
        var livros = await _assuntoRepository.GetByIdAsync(command.CodAs);
           
        return _mapper.Map<BuscarAssuntoResult>(livros);
    }
}
