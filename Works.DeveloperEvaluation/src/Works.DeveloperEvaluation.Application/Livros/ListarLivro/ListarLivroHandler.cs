using AutoMapper;
using MediatR;
using Works.DeveloperEvaluation.Domain.Repositories;
using Works.DeveloperEvaluation.Domain.Entities;
namespace Works.DeveloperEvaluation.Application.Livros.ListarLivro;

/// <summary>
/// Handler for processing GetProjectCommand requests
/// </summary>
public class ListarLivroHandler: IRequestHandler<ListarLivroCommand, List<ListarLivroResult>>
{
    private readonly ILivroRepository _livroRepository;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of ListProjectHandler
    /// </summary>
    public ListarLivroHandler(
        ILivroRepository livroRepository,
        IMapper mapper)
    {
        _livroRepository = livroRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Handles the ListProjectCommand request
    /// </summary>
    public async Task<List<ListarLivroResult>> Handle(ListarLivroCommand command, CancellationToken cancellationToken)
    {
        var livros = new List<Livro>();

        if (command.Codl == 0)
        {
            var projects = await _livroRepository.GetLivrosAsync(cancellationToken);
            if (projects == null)
                throw new KeyNotFoundException($"Projects not found");
            else
                livros.AddRange(projects);
        }
        else
        {
            var projects = await _livroRepository.GetByIdAsync(command.Codl);
            livros.Add(projects);
        }


        return _mapper.Map<List<ListarLivroResult>>(livros);
    }
}
