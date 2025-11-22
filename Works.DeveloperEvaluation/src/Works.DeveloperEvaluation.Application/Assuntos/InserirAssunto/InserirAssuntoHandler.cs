using AutoMapper;
using Works.DeveloperEvaluation.Application.Assuntos.InserirAssunto;
using Works.DeveloperEvaluation.Domain.Entities;
using Works.DeveloperEvaluation.Domain.Repositories;
using MediatR;
namespace Works.DeveloperEvaluation.Application.Livros.InserirLivro;

/// <summary>
/// Handler for processing CreateSaleCommand requests
/// </summary>
public class InserirAssuntoHandler : IRequestHandler<InserirAssuntoCommand, InserirAssuntoResult>
{
    private readonly IAssuntoRepository _assuntoRepository;
    //private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
  
    /// <summary>
    /// Initializes a new instance of CreateProjectHandler
    /// </summary>
    public InserirAssuntoHandler(IAssuntoRepository assuntoRepository, IMapper mapper)
    {
        _assuntoRepository = assuntoRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Handles the CreateProjectCommand request
    /// </summary>
    public async Task<InserirAssuntoResult> Handle(InserirAssuntoCommand command, CancellationToken cancellationToken)
    {
        var assunto = _mapper.Map<Assunto>(command);
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

        var inserirAssunto = await _assuntoRepository.CreateAsync(assunto, cancellationToken);
        var result = _mapper.Map<InserirAssuntoResult>(inserirAssunto);
        return result;
    }
}
