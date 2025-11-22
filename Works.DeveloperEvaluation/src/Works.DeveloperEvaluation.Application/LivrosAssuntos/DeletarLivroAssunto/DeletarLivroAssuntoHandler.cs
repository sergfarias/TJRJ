using Works.DeveloperEvaluation.Domain.Repositories;
using FluentValidation;
using MediatR;

namespace Works.DeveloperEvaluation.Application.LivrosAssuntos.DeletarLivroAssunto;

/// <summary>
/// Handler for processing DeleteProjectCommand requests
/// </summary>
public class DeletarLivroAssuntoHandler : IRequestHandler<DeletarLivroAssuntoCommand, DeletarLivroAssuntoResponse>
{
    private readonly ILivroAssuntoRepository _livroAssuntoRepository;
    
    //private readonly ITaskRepository _taskRepository;
    /// <summary>
    /// Initializes a new instance of DeleteProjectHandler
    /// </summary>
    /// <param name="projectRepository">The project repository</param>
    /// <param name="taskRepository">The task repository</param>
    /// <param name="validator">The validator for DeleteProjectCommand</param>
    public DeletarLivroAssuntoHandler(ILivroAssuntoRepository livroAssuntoRepository)
    {
        _livroAssuntoRepository = livroAssuntoRepository;
    }

    /// <summary>
    /// Handles the DeleteProjectCommand request
    /// </summary>
    public async Task<DeletarLivroAssuntoResponse> Handle(DeletarLivroAssuntoCommand request, CancellationToken cancellationToken)
    {
        var validator = new DeletarLivroAssuntoValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        //var pendentes = await _taskRepository.TaskPendingByProjectIdAsync(request.Id, cancellationToken);
        //if (pendentes != null)
        //{
        //    throw new KeyNotFoundException("Projeto não pde ser removido pois tem tarefas pendentes. Conclua ou remova as tarefas pendentes:" + pendentes  );
        //}

        var success = await _livroAssuntoRepository.DeleteAsync(request.Livro_CodL, cancellationToken);
        if (!success)
            throw new KeyNotFoundException($"Livro de código {request.Livro_CodL} não encontrado.");

        return new DeletarLivroAssuntoResponse { Success = true };
    }
}
