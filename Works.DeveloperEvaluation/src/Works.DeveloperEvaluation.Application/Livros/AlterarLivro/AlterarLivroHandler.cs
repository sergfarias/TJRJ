using AutoMapper;
using Works.DeveloperEvaluation.Domain.Entities;
using Works.DeveloperEvaluation.Domain.Repositories;
using FluentValidation;
using MediatR;
namespace Works.DeveloperEvaluation.Application.Livros.AlterarLivro;

/// <summary>
/// Handler for processing ModifiedSaleCommand requests
/// </summary>
public class AlterarLivroHandler : IRequestHandler<AlterarLivroCommand, AlterarLivroResult>
{
    private readonly ILivroRepository _livroRepository;
    //private readonly ITaskRepository _taskRepository;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of ModifieldProjectHandler
    /// </summary>
    public AlterarLivroHandler(ILivroRepository livroRepository, IMapper mapper)
    {
        _livroRepository = livroRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Handles the ModifieldProjectCommand request
    /// </summary>
    public async Task<AlterarLivroResult> Handle(AlterarLivroCommand command, CancellationToken cancellationToken)
    {
        var livro = _mapper.Map<Livro>(command);

        var livroDB = await _livroRepository.GetByIdAsync(livro.CodL, cancellationToken);
        if (livroDB == null)
        {
            throw new ValidationException("Livro de código " + livro.CodL + " não encontrado.");
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

            var alterarLivro = await _livroRepository.UpdateAsync(livroDB, cancellationToken);
            var result = _mapper.Map<AlterarLivroResult>(alterarLivro);
            return result;

        }

    }
}
