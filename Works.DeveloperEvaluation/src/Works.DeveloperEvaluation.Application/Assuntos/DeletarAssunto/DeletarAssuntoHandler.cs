using Works.DeveloperEvaluation.Domain.Repositories;
using FluentValidation;
using MediatR;

namespace Works.DeveloperEvaluation.Application.Assuntos.DeletarAssunto;

/// <summary>
/// Handler for processing DeleteProjectCommand requests
/// </summary>
public class DeletarAssuntoHandler : IRequestHandler<DeletarAssuntoCommand, DeletarAssuntoResponse>
{
    private readonly IAssuntoRepository _assuntoRepository;
    
    //private readonly ITaskRepository _taskRepository;
    /// <summary>
    /// Initializes a new instance of DeleteProjectHandler
    /// </summary>
    /// <param name="projectRepository">The project repository</param>
    /// <param name="taskRepository">The task repository</param>
    /// <param name="validator">The validator for DeleteProjectCommand</param>
    public DeletarAssuntoHandler(IAssuntoRepository assuntoRepository)
    {
        _assuntoRepository = assuntoRepository;
    }

    /// <summary>
    /// Handles the DeleteProjectCommand request
    /// </summary>
    public async Task<DeletarAssuntoResponse> Handle(DeletarAssuntoCommand request, CancellationToken cancellationToken)
    {
        var validator = new DeletarAssuntoValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        //var pendentes = await _taskRepository.TaskPendingByProjectIdAsync(request.Id, cancellationToken);
        //if (pendentes != null)
        //{
        //    throw new KeyNotFoundException("Projeto não pde ser removido pois tem tarefas pendentes. Conclua ou remova as tarefas pendentes:" + pendentes  );
        //}

        var success = await _assuntoRepository.DeleteAsync(request.CodAs, cancellationToken);
        if (!success)
            throw new KeyNotFoundException($"Assunto de código {request.CodAs} não encontrado.");

        return new DeletarAssuntoResponse { Success = true };
    }
}
