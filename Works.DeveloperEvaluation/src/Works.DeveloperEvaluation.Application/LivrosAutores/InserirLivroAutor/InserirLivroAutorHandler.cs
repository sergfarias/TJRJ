using AutoMapper;
using Works.DeveloperEvaluation.Application.LivrosAutores.InserirLivroAutor;
using Works.DeveloperEvaluation.Common.Security;
using Works.DeveloperEvaluation.Domain.Entities;
using Works.DeveloperEvaluation.Domain.Repositories;
using MediatR;
namespace Works.DeveloperEvaluation.Application.Livros.InserirLivro;

/// <summary>
/// Handler for processing CreateSaleCommand requests
/// </summary>
public class InserirLivroAutorHandler : IRequestHandler<InserirLivroAutorCommand, InserirLivroAutorResult>
{
    private readonly ILivroAutorRepository _livroAutorRepository;
    //private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
  
    /// <summary>
    /// Initializes a new instance of CreateProjectHandler
    /// </summary>
    public InserirLivroAutorHandler(ILivroAutorRepository livroAutorRepository, IMapper mapper)
    {
        _livroAutorRepository = livroAutorRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Handles the CreateProjectCommand request
    /// </summary>
    public async Task<InserirLivroAutorResult> Handle(InserirLivroAutorCommand command, CancellationToken cancellationToken)
    {
        var livro = _mapper.Map<LivroAutor>(command);
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

        var inserirLivro = await _livroAutorRepository.CreateAsync(livro, cancellationToken);
        var result = _mapper.Map<InserirLivroAutorResult>(inserirLivro);
        return result;
    }
}
