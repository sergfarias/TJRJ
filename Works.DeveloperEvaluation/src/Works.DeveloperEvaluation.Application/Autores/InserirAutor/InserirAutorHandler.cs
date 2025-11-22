using AutoMapper;
//using Works.DeveloperEvaluation.Application.Assuntos.InserirAssunto;
using Works.DeveloperEvaluation.Domain.Entities;
using Works.DeveloperEvaluation.Domain.Repositories;
using MediatR;
namespace Works.DeveloperEvaluation.Application.Autores.InserirAutor;

/// <summary>
/// Handler for processing CreateSaleCommand requests
/// </summary>
public class InserirAutorHandler : IRequestHandler<InserirAutorCommand, InserirAutorResult>
{
    private readonly IAutorRepository _autorRepository;
    //private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
  
    /// <summary>
    /// Initializes a new instance of CreateProjectHandler
    /// </summary>
    public InserirAutorHandler(IAutorRepository autorRepository, IMapper mapper)
    {
        _autorRepository = autorRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Handles the CreateProjectCommand request
    /// </summary>
    public async Task<InserirAutorResult> Handle(InserirAutorCommand command, CancellationToken cancellationToken)
    {
        var autor = _mapper.Map<Autor>(command);
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

        var inserirAutor = await _autorRepository.CreateAsync(autor, cancellationToken);
        var result = _mapper.Map<InserirAutorResult>(inserirAutor);
        return result;
    }
}
