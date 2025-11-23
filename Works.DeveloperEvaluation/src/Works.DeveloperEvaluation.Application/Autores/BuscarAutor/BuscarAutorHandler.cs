using AutoMapper;
using MediatR;
using Works.DeveloperEvaluation.Domain.Repositories;
using Works.DeveloperEvaluation.Domain.Entities;
namespace Works.DeveloperEvaluation.Application.Autores.BuscarAutor;

/// <summary>
/// Handler for processing GetProjectCommand requests
/// </summary>
public class BuscarAutorHandler : IRequestHandler<BuscarAutorCommand, BuscarAutorResult>
{
    private readonly IAutorRepository _autorRepository;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of ListProjectHandler
    /// </summary>
    public BuscarAutorHandler(
        IAutorRepository autorRepository,
        IMapper mapper)
    {
        _autorRepository = autorRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Handles the ListProjectCommand request
    /// </summary>
    public async Task<BuscarAutorResult> Handle(BuscarAutorCommand command, CancellationToken cancellationToken)
    {
        var livros = await _autorRepository.GetByIdAsync(command.CodAu);
           
        return _mapper.Map<BuscarAutorResult>(livros);
    }
}
