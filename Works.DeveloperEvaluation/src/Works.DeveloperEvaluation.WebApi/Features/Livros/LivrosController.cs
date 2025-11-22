using MediatR;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Works.DeveloperEvaluation.WebApi.Common;
using Works.DeveloperEvaluation.Application.Livros.ListarLivro;
using Works.DeveloperEvaluation.Application.Livros.InserirLivro;
using Works.DeveloperEvaluation.WebApi.Features.Livros.ListarLivro;
using Works.DeveloperEvaluation.Application.Livros.AlterarLivro;
using Works.DeveloperEvaluation.WebApi.Features.Livros.InserirLivro;
using Works.DeveloperEvaluation.WebApi.Features.Livros.AlterarLivro;
using Works.DeveloperEvaluation.WebApi.Features.Livros.BuscarLivro;
using Works.DeveloperEvaluation.Application.Livros.BuscarLivro;
using Works.DeveloperEvaluation.Application.Livros.DeletarLivro;
using Works.DeveloperEvaluation.WebApi.Features.Livros.DeletarLivro;
namespace Works.DeveloperEvaluation.WebApi.Features.Livros;

/// <summary>
/// Controller for managing project operations
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class LivrosController : BaseController
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of ProjectsController
    /// </summary>
    /// <param name="mediator">The mediator instance</param>
    /// <param name="mapper">The AutoMapper instance</param>
    public LivrosController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    /// <summary>
    /// Creates a new project
    /// </summary>
    /// <param name="request">The project creation request</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created project details</returns>
    [HttpPost("InserirLivro")]
    [ProducesResponseType(typeof(ApiResponseWithData<GetLivroResponse>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> InserirLivro([FromBody] InserirLivroRequest request, CancellationToken cancellationToken)
    {
        var validator = new InserirLivroRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = _mapper.Map<InserirLivroCommand>(request);
        var response = await _mediator.Send(command, cancellationToken);

        return Created(string.Empty, new ApiResponseWithData<GetLivroResponse>
        {
            Success = true,
            Message = "Livro inserido com sucesso!",
            Data = _mapper.Map<GetLivroResponse>(response)
        });
    }

    /// <summary>
    /// Modified a project
    /// </summary>
    /// <param name="request">The project Modified request</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The Modified project details</returns>
    [HttpPut("AlterarLivro")]
    [ProducesResponseType(typeof(ApiResponseWithData<AlterarLivroResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> AlterarLivro([FromBody] AlterarLivroRequest request, CancellationToken cancellationToken)
    {
        var validator = new AlterarLivroRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = _mapper.Map<AlterarLivroCommand>(request);
        var response = await _mediator.Send(command, cancellationToken);

        return Created(string.Empty, new ApiResponseWithData<AlterarLivroResponse>
        {
            Success = true,
            Message = "Livro alterado com sucesso!",
            Data = _mapper.Map<AlterarLivroResponse>(response)
        });
    }

    /// <summary>
    /// Modified a project
    /// </summary>
    /// <param name="request">The project Modified request</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The Modified project details</returns>
    [HttpDelete("DeletarLivro/{id}")]
    [ProducesResponseType(typeof(ApiResponseWithData<DeletarLivroResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> DeletarLivro([FromRoute] int Id, CancellationToken cancellationToken)
    {
        //var validator = new DeletarLivroRequestValidator();
        //var validationResult = await validator.ValidateAsync(request, cancellationToken);

        //if (!validationResult.IsValid)
        //    return BadRequest(validationResult.Errors);

        //var request = new BuscarLivroRequest { CodL = Id };

        var command = new DeletarLivroCommand(Id); ///_mapper.Map<DeletarLivroCommand>(request);
        var response = await _mediator.Send(command, cancellationToken);

        return Created(string.Empty, new ApiResponseWithData<DeletarLivroResponse>
        {
            Success = true,
            Message = "Livro deletado com sucesso!",
            Data = _mapper.Map<DeletarLivroResponse>(response)
        });
    }




    /// <summary>
    /// Retrieves a project by their IDUser
    /// </summary>
    /// <param name="id">The unique identifier of the user</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The user details if found</returns>
    [HttpGet("LivroById/{id}")]
    [ProducesResponseType(typeof(ApiResponseWithData<BuscarLivroResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> LivroById([FromRoute] int Id, CancellationToken cancellationToken)
    {
        var request = new BuscarLivroRequest { CodL = Id };

        var command = _mapper.Map<BuscarLivroCommand>(request);
        var response = await _mediator.Send(command, cancellationToken);

        return Ok(new ApiResponseWithData<BuscarLivroResponse>
        {
            Success = true,
            Message = "Livro do código("+ Id + ") recuperado(s) com sucesso!",
            Data = _mapper.Map<BuscarLivroResponse>(response)
        });
    }


    /// <summary>
    /// Retrieves a project by their IDUser
    /// </summary>
    /// <param name="id">The unique identifier of the user</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The user details if found</returns>
    [HttpGet("TodosLivros")]
    [ProducesResponseType(typeof(ApiResponseWithData<ListarLivroResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> ListarLivro([FromRoute] CancellationToken cancellationToken)
    {
        var request = new ListarLivroRequest { };

        var command = _mapper.Map<ListarLivroCommand>(request);
        var response = await _mediator.Send(command, cancellationToken);

        return Ok(new ApiResponseWithData<List<ListarLivroResponse>>
        {
            Success = true,
            Message = "Projeto(s) do usuário recuperado(s) com sucesso!",
            Data =_mapper.Map<List<ListarLivroResponse>>(response)
        });

    }

}
