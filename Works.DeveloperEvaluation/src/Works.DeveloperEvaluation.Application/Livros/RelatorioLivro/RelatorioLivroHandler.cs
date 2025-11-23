using AutoMapper;
using MediatR;
using Works.DeveloperEvaluation.Domain.Repositories;
using Works.DeveloperEvaluation.Domain.Entities;
using Works.DeveloperEvaluation.Application.Livros.ListarLivro;
namespace Works.DeveloperEvaluation.Application.Livros.RelatorioLivro;

/// <summary>
/// Handler for processing GetProjectCommand requests
/// </summary>
public class RelatorioLivroHandler : IRequestHandler<RelatorioLivroCommand, List<RelatorioLivroResult>>
{
    private readonly ILivroRepository _livroRepository;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of ListProjectHandler
    /// </summary>
    public RelatorioLivroHandler(
        ILivroRepository livroRepository,
        IMapper mapper)
    {
        _livroRepository = livroRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Handles the ListProjectCommand request
    /// </summary>
    public async Task<List<RelatorioLivroResult>> Handle(RelatorioLivroCommand command, CancellationToken cancellationToken)
    {
        var livros = new List<LivroDetalhesView>();

        //if (command.CodL == 0)
        //{
            var projects = await _livroRepository.Relatorio();
            if (projects == null)
                throw new KeyNotFoundException($"Projects not found");
            else
                livros.AddRange(projects);
        //}
        //else
        //{
        //    var projects = await _livroRepository.GetByIdAsync(command.CodL);
        //    livros.Add(projects);
        //}


        return _mapper.Map<List<RelatorioLivroResult>>(livros);
    }
}
