using AutoMapper;
using Works.DeveloperEvaluation.Common.Security;
using Works.DeveloperEvaluation.Domain.Entities;
using Works.DeveloperEvaluation.Domain.Repositories;
using MediatR;
namespace Works.DeveloperEvaluation.Application.LivrosAssuntos.InserirLivroAssunto;

/// <summary>
/// Handler for processing CreateSaleCommand requests
/// </summary>
public class InserirLivroAssuntoHandler : IRequestHandler<InserirLivroAssuntoCommand, InserirLivroAssuntoResult>
{
    private readonly ILivroAssuntoRepository _livroAssuntoRepository;
    //private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
  
    /// <summary>
    /// Initializes a new instance of CreateProjectHandler
    /// </summary>
    public InserirLivroAssuntoHandler(ILivroAssuntoRepository livroAssuntoRepository, IMapper mapper)
    {
        _livroAssuntoRepository = livroAssuntoRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Handles the CreateProjectCommand request
    /// </summary>
    public async Task<InserirLivroAssuntoResult> Handle(InserirLivroAssuntoCommand command, CancellationToken cancellationToken)
    {
        var livro = _mapper.Map<LivroAssunto>(command);
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

        var inserirLivro = await _livroAssuntoRepository.CreateAsync(livro, cancellationToken);
        var result = _mapper.Map<InserirLivroAssuntoResult>(inserirLivro);
        return result;
    }
}
