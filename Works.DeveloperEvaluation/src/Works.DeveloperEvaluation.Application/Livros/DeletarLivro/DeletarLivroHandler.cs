using Works.DeveloperEvaluation.Domain.Repositories;
using FluentValidation;
using MediatR;

namespace Works.DeveloperEvaluation.Application.Livros.DeletarLivro;

/// <summary>
/// Handler for processing DeleteProjectCommand requests
/// </summary>
public class DeletarLivroHandler : IRequestHandler<DeletarLivroCommand, DeletarLivroResponse>
{
    private readonly ILivroRepository _livroRepository;
    
    //private readonly ITaskRepository _taskRepository;
    /// <summary>
    /// Initializes a new instance of DeleteProjectHandler
    /// </summary>
    /// <param name="projectRepository">The project repository</param>
    /// <param name="taskRepository">The task repository</param>
    /// <param name="validator">The validator for DeleteProjectCommand</param>
    public DeletarLivroHandler(ILivroRepository livroRepository)
    {
        _livroRepository = livroRepository;
    }

    /// <summary>
    /// Handles the DeleteProjectCommand request
    /// </summary>
    public async Task<DeletarLivroResponse> Handle(DeletarLivroCommand request, CancellationToken cancellationToken)
    {
        var validator = new DeletarLivroValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        //var pendentes = await _taskRepository.TaskPendingByProjectIdAsync(request.Id, cancellationToken);
        //if (pendentes != null)
        //{
        //    throw new KeyNotFoundException("Projeto não pde ser removido pois tem tarefas pendentes. Conclua ou remova as tarefas pendentes:" + pendentes  );
        //}

        var success = await _livroRepository.DeleteAsync(request.CodL, cancellationToken);
        if (!success)
            throw new KeyNotFoundException($"Livro de código {request.CodL} não encontrado.");

        return new DeletarLivroResponse { Success = true };
    }
}
