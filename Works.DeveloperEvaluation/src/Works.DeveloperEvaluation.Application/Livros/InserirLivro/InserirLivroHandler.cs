using AutoMapper;
using MediatR;
using Works.DeveloperEvaluation.Domain.Repositories;
using Works.DeveloperEvaluation.Domain.Entities;
namespace Works.DeveloperEvaluation.Application.Livros.InserirLivro;

/// <summary>
/// Handler for processing CreateSaleCommand requests
/// </summary>
public class InserirLivroHandler : IRequestHandler<InserirLivroCommand, InserirLivroResult>
{
    private readonly ILivroRepository _livroRepository;
    //private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
  
    /// <summary>
    /// Initializes a new instance of CreateProjectHandler
    /// </summary>
    public InserirLivroHandler(ILivroRepository livroRepository, IMapper mapper)
    {
        _livroRepository = livroRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Handles the CreateProjectCommand request
    /// </summary>
    public async Task<InserirLivroResult> Handle(InserirLivroCommand command, CancellationToken cancellationToken)
    {
        var livro = _mapper.Map<Livro>(command);
        //livro.Id = ;

        //_ = await _userRepository.GetByIdAsync(project.UserId, cancellationToken) ?? throw new KeyNotFoundException("Usuário (" + project.UserId + ") do projeto não encontrado.");
        
        //if (project?.Tasks?.Count > 20)
        //{
        //    throw new InvalidOperationException("Projeto não pode ter mais e 20 tarefas.");
        //}

        //foreach (var item in project.Tasks)
        //{
        //    item.ProjectId = project.Id;
        //    item.CreatedAt = DateTime.Now;
        //    item.Status = Domain.Enums.TaskStatus.Pending;
        //}
        //project.Status = Domain.Enums.ProjectStatus.Active;
        //project.CreatedAt = DateTime.Now;

        var inserirLivro = await _livroRepository.CreateAsync(livro, cancellationToken);
        var result = _mapper.Map<InserirLivroResult>(inserirLivro);
        return result;
    }
}
