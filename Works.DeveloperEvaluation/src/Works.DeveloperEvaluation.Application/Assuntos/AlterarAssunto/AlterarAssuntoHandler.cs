using AutoMapper;
using Works.DeveloperEvaluation.Domain.Entities;
using Works.DeveloperEvaluation.Domain.Repositories;
using FluentValidation;
using MediatR;
namespace Works.DeveloperEvaluation.Application.Assuntos.AlterarAssunto;

/// <summary>
/// Handler for processing ModifiedSaleCommand requests
/// </summary>
public class AlterarAssuntoHandler : IRequestHandler<AlterarAssuntoCommand, AlterarAssuntoResult>
{
    private readonly IAssuntoRepository _assuntoRepository;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of ModifieldProjectHandler
    /// </summary>
    public AlterarAssuntoHandler(IAssuntoRepository assuntoRepository, IMapper mapper)
    {
        _assuntoRepository = assuntoRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Handles the ModifieldProjectCommand request
    /// </summary>
    public async Task<AlterarAssuntoResult> Handle(AlterarAssuntoCommand command, CancellationToken cancellationToken)
    {
        var assunto = _mapper.Map<Assunto>(command);

        var livroDB = await _assuntoRepository.GetByIdAsync(assunto.CodAs, cancellationToken);
        if (livroDB == null)
        {
            throw new ValidationException("Assunto de código " + assunto.CodAs + " não encontrado.");
        }
        else
        {
            livroDB.Descricao = assunto.Descricao;
            var alterarLivro = await _assuntoRepository.UpdateAsync(livroDB, cancellationToken);
            var result = _mapper.Map<AlterarAssuntoResult>(alterarLivro);
            return result;
        }

    }
}
