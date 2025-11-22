using AutoMapper;
using MediatR;
using Works.DeveloperEvaluation.Domain.Repositories;
using Works.DeveloperEvaluation.Domain.Entities;
namespace Works.DeveloperEvaluation.Application.Livros.BuscarLivro;

/// <summary>
/// Handler for processing GetProjectCommand requests
/// </summary>
public class BuscarLivroHandler : IRequestHandler<BuscarLivroCommand, BuscarLivroResult>
{
    private readonly ILivroRepository _livroRepository;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of ListProjectHandler
    /// </summary>
    public BuscarLivroHandler(
        ILivroRepository livroRepository,
        IMapper mapper)
    {
        _livroRepository = livroRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Handles the ListProjectCommand request
    /// </summary>
    public async Task<BuscarLivroResult> Handle(BuscarLivroCommand command, CancellationToken cancellationToken)
    {
        var livros = await _livroRepository.GetByIdAsync(command.Codl);
           
        return _mapper.Map<BuscarLivroResult>(livros);
    }
}
