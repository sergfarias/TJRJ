using AutoMapper;
using Works.DeveloperEvaluation.Domain.Entities;
using Works.DeveloperEvaluation.Domain.Repositories;
using FluentValidation;
using MediatR;
namespace Works.DeveloperEvaluation.Application.Autores.AlterarAutor;

/// <summary>
/// Handler for processing ModifiedSaleCommand requests
/// </summary>
public class AlterarAutorHandler : IRequestHandler<AlterarAutorCommand, AlterarAutorResult>
{
    private readonly IAutorRepository _autorRepository;
    //private readonly ITaskRepository _taskRepository;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of ModifieldProjectHandler
    /// </summary>
    public AlterarAutorHandler(IAutorRepository autorRepository, IMapper mapper)
    {
        _autorRepository = autorRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Handles the ModifieldProjectCommand request
    /// </summary>
    public async Task<AlterarAutorResult> Handle(AlterarAutorCommand command, CancellationToken cancellationToken)
    {
        var autor = _mapper.Map<Autor>(command);

        var livroDB = await _autorRepository.GetByIdAsync(autor.CodAu, cancellationToken);
        if (livroDB == null)
        {
            throw new ValidationException("Autor de código " + autor.CodAu + " não encontrado.");
        }
        else
        {
            //Deleta itens antigos
            //await _taskRepository.DeleteTasksAsync(projectDB.Id, cancellationToken);

            //foreach (var item in project.Tasks)
            //{
            //    item.ProjectId = projectDB.Id;
            //    item.UpdatedAt = DateTime.Now;
            //    projectDB.Tasks.Add(item);
            //}

            //projectDB.UpdatedAt = DateTime.Now;

            var alterarLivro = await _autorRepository.UpdateAsync(livroDB, cancellationToken);
            var result = _mapper.Map<AlterarAutorResult>(alterarLivro);
            return result;

        }

    }
}
