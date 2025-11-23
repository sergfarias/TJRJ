using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Works.DeveloperEvaluation.Application.Assuntos.AlterarAssunto;
using Works.DeveloperEvaluation.Application.Assuntos.BuscarAssunto;
using Works.DeveloperEvaluation.Application.Assuntos.DeletarAssunto;
using Works.DeveloperEvaluation.Application.Assuntos.InserirAssunto;
using Works.DeveloperEvaluation.Application.Assuntos.ListarAssunto;
using Works.DeveloperEvaluation.Application.Livros.BuscarLivro;
using Works.DeveloperEvaluation.Application.Livros.DeletarLivro;
using Works.DeveloperEvaluation.Application.Livros.ListarLivro;
using Works.DeveloperEvaluation.WebApi.Common;
using Works.DeveloperEvaluation.WebApi.Features.Assuntos.AlterarAssunto;
using Works.DeveloperEvaluation.WebApi.Features.Assuntos.BuscarAssunto;
using Works.DeveloperEvaluation.WebApi.Features.Assuntos.InserirAssunto;
using Works.DeveloperEvaluation.WebApi.Features.Assuntos.ListarAssunto;
using Works.DeveloperEvaluation.WebApi.Features.Livros.BuscarLivro;
using Works.DeveloperEvaluation.WebApi.Features.Livros.ListarLivro;
namespace Works.DeveloperEvaluation.WebApi.Features.Assuntos;

/// <summary>
/// Controller for managing project operations
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class AssuntosController : BaseController
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of ProjectsController
    /// </summary>
    /// <param name="mediator">The mediator instance</param>
    /// <param name="mapper">The AutoMapper instance</param>
    public AssuntosController(IMediator mediator, IMapper mapper)
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
    [HttpPost("InserirAssunto")]
    [ProducesResponseType(typeof(ApiResponseWithData<GetAssuntoResponse>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> InserirAssunto([FromBody] InserirAssuntoRequest request, CancellationToken cancellationToken)
    {
        var validator = new InserirAssuntoRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = _mapper.Map<InserirAssuntoCommand>(request);
        var response = await _mediator.Send(command, cancellationToken);

        return Created(string.Empty, new ApiResponseWithData<GetAssuntoResponse>
        {
            Success = true,
            Message = "Assunto inserido com sucesso!",
            Data = _mapper.Map<GetAssuntoResponse>(response)
        });
    }

    /// <summary>
    /// Modified a project
    /// </summary>
    /// <param name="request">The project Modified request</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The Modified project details</returns>
    [HttpPut("AlterarAssunto")]
    [ProducesResponseType(typeof(ApiResponseWithData<AlterarAssuntoResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> ModifiedSale([FromBody] AlterarAssuntoRequest request, CancellationToken cancellationToken)
    {
        var validator = new AlterarAssuntoRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = _mapper.Map<AlterarAssuntoCommand>(request);
        var response = await _mediator.Send(command, cancellationToken);

        return Created(string.Empty, new ApiResponseWithData<AlterarAssuntoResponse>
        {
            Success = true,
            Message = "Assunto alterado com sucesso!",
            Data = _mapper.Map<AlterarAssuntoResponse>(response)
        });
    }

    /// <summary>
    /// Modified a project
    /// </summary>
    /// <param name="request">The project Modified request</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The Modified project details</returns>
    [HttpDelete("DeletarAssunto/{id}")]
    [ProducesResponseType(typeof(ApiResponseWithData<DeletarAssuntoResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> DeletarAssunto([FromRoute] int Id, CancellationToken cancellationToken)
    {
        //var validator = new DeletarLivroRequestValidator();
        //var validationResult = await validator.ValidateAsync(request, cancellationToken);

        //if (!validationResult.IsValid)
        //    return BadRequest(validationResult.Errors);

        //var request = new BuscarLivroRequest { CodL = Id };

        var command = new DeletarAssuntoCommand(Id); ///_mapper.Map<DeletarLivroCommand>(request);
        var response = await _mediator.Send(command, cancellationToken);

        return Created(string.Empty, new ApiResponseWithData<DeletarAssuntoResponse>
        {
            Success = true,
            Message = "Assunto deletado com sucesso!",
            Data = _mapper.Map<DeletarAssuntoResponse>(response)
        });
    }




    /// <summary>
    /// Retrieves a project by their IDUser
    /// </summary>
    /// <param name="id">The unique identifier of the user</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The user details if found</returns>
    [HttpGet("AssuntoById/{id}")]
    [ProducesResponseType(typeof(ApiResponseWithData<BuscarAssuntoResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> AssuntoById([FromRoute] int Id, CancellationToken cancellationToken)
    {
        var request = new BuscarAssuntoRequest { CodAs = Id };

        var command = _mapper.Map<BuscarAssuntoCommand>(request);
        var response = await _mediator.Send(command, cancellationToken);

        return Ok(new ApiResponseWithData<BuscarAssuntoResponse>
        {
            Success = true,
            Message = "Assunto do código(" + Id + ") recuperado(s) com sucesso!",
            Data = _mapper.Map<BuscarAssuntoResponse>(response)
        });
    }


    /// <summary>
    /// Retrieves a project by their IDUser
    /// </summary>
    /// <param name="id">The unique identifier of the user</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The user details if found</returns>
    [HttpGet("TodosAssuntos")]
    [ProducesResponseType(typeof(ApiResponseWithData<ListarAssuntoResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> ListarAssunto([FromRoute] CancellationToken cancellationToken)
    {
        var request = new ListarAssuntoRequest { };

        var command = _mapper.Map<ListarAssuntoCommand>(request);
        var response = await _mediator.Send(command, cancellationToken);

        return Ok(new ApiResponseWithData<List<ListarAssuntoResponse>>
        {
            Success = true,
            Message = "Assunto recuperado(s) com sucesso!",
            Data = _mapper.Map<List<ListarAssuntoResponse>>(response)
        });

    }
}
