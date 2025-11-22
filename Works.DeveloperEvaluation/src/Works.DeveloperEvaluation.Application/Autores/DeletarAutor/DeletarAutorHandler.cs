using Works.DeveloperEvaluation.Domain.Repositories;
using FluentValidation;
using MediatR;

namespace Works.DeveloperEvaluation.Application.Autores.DeletarAutor;

/// <summary>
/// Handler for processing DeleteProjectCommand requests
/// </summary>
public class DeletarAutorHandler : IRequestHandler<DeletarAutorCommand, DeletarAutorResponse>
{
    private readonly IAutorRepository _autorRepository;
    
    //private readonly ITaskRepository _taskRepository;
    /// <summary>
    /// Initializes a new instance of DeleteProjectHandler
    /// </summary>
    /// <param name="projectRepository">The project repository</param>
    /// <param name="taskRepository">The task repository</param>
    /// <param name="validator">The validator for DeleteProjectCommand</param>
    public DeletarAutorHandler(IAutorRepository autorRepository)
    {
        _autorRepository = autorRepository;
    }

    /// <summary>
    /// Handles the DeleteProjectCommand request
    /// </summary>
    public async Task<DeletarAutorResponse> Handle(DeletarAutorCommand request, CancellationToken cancellationToken)
    {
        var validator = new DeletarAutorValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        //var pendentes = await _taskRepository.TaskPendingByProjectIdAsync(request.Id, cancellationToken);
        //if (pendentes != null)
        //{
        //    throw new KeyNotFoundException("Projeto não pde ser removido pois tem tarefas pendentes. Conclua ou remova as tarefas pendentes:" + pendentes  );
        //}

        var success = await _autorRepository.DeleteAsync(request.CodAu, cancellationToken);
        if (!success)
            throw new KeyNotFoundException($"Autor de código {request.CodAu} não encontrado.");

        return new DeletarAutorResponse { Success = true };
    }
}
