using Works.DeveloperEvaluation.Domain.Repositories;
using FluentValidation;
using MediatR;

namespace Works.DeveloperEvaluation.Application.LivrosAutores.DeletarLivroAutor;

/// <summary>
/// Handler for processing DeleteProjectCommand requests
/// </summary>
public class DeletarLivroAutorHandler : IRequestHandler<DeletarLivroAutorCommand, DeletarLivroAutorResponse>
{
    private readonly ILivroAutorRepository _livroAutorRepository;
    
    //private readonly ITaskRepository _taskRepository;
    /// <summary>
    /// Initializes a new instance of DeleteProjectHandler
    /// </summary>
    /// <param name="projectRepository">The project repository</param>
    /// <param name="taskRepository">The task repository</param>
    /// <param name="validator">The validator for DeleteProjectCommand</param>
    public DeletarLivroAutorHandler(ILivroAutorRepository livroAutorRepository)
    {
        _livroAutorRepository = livroAutorRepository;
    }

    /// <summary>
    /// Handles the DeleteProjectCommand request
    /// </summary>
    public async Task<DeletarLivroAutorResponse> Handle(DeletarLivroAutorCommand request, CancellationToken cancellationToken)
    {
        var validator = new DeletarLivroAutorValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        //var pendentes = await _taskRepository.TaskPendingByProjectIdAsync(request.Id, cancellationToken);
        //if (pendentes != null)
        //{
        //    throw new KeyNotFoundException("Projeto não pde ser removido pois tem tarefas pendentes. Conclua ou remova as tarefas pendentes:" + pendentes  );
        //}

        var success = await _livroAutorRepository.DeleteAsync(request.Livro_CodL, cancellationToken);
        if (!success)
            throw new KeyNotFoundException($"Livro de código {request.Livro_CodL} não encontrado.");

        return new DeletarLivroAutorResponse { Success = true };
    }
}
