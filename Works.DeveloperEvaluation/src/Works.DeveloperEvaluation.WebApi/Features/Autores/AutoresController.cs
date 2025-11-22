using AutoMapper;
using Works.DeveloperEvaluation.Application.Autores.AlterarAutor;
using Works.DeveloperEvaluation.Application.Autores.InserirAutor;
using Works.DeveloperEvaluation.WebApi.Common;
using Works.DeveloperEvaluation.WebApi.Features.Autores.AlterarAutor;
using Works.DeveloperEvaluation.WebApi.Features.Autores.InserirAutor;
using Works.DeveloperEvaluation.WebApi.Features.Autors.InserirAutor;
using MediatR;
using Microsoft.AspNetCore.Mvc;
namespace Works.DeveloperEvaluation.WebApi.Features.Autores;

/// <summary>
/// Controller for managing project operations
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class AutoresController : BaseController
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of ProjectsController
    /// </summary>
    /// <param name="mediator">The mediator instance</param>
    /// <param name="mapper">The AutoMapper instance</param>
    public AutoresController(IMediator mediator, IMapper mapper)
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
    [HttpPost("InserirAutor")]
    [ProducesResponseType(typeof(ApiResponseWithData<GetAutorResponse>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> InserirAutor([FromBody] InserirAutorRequest request, CancellationToken cancellationToken)
    {
        var validator = new InserirAutorRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = _mapper.Map<InserirAutorCommand>(request);
        var response = await _mediator.Send(command, cancellationToken);

        return Created(string.Empty, new ApiResponseWithData<GetAutorResponse>
        {
            Success = true,
            Message = "Autor inserido com sucesso!",
            Data = _mapper.Map<GetAutorResponse>(response)
        });
    }

    /// <summary>
    /// Modified a project
    /// </summary>
    /// <param name="request">The project Modified request</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The Modified project details</returns>
    [HttpPut("AlterarAutor")]
    [ProducesResponseType(typeof(ApiResponseWithData<AlterarAutorResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> ModifiedSale([FromBody] AlterarAutorRequest request, CancellationToken cancellationToken)
    {
        var validator = new AlterarAutorRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = _mapper.Map<AlterarAutorCommand>(request);
        var response = await _mediator.Send(command, cancellationToken);

        return Created(string.Empty, new ApiResponseWithData<AlterarAutorResponse>
        {
            Success = true,
            Message = "Autor alterado com sucesso!",
            Data = _mapper.Map<AlterarAutorResponse>(response)
        });
    }

    /// <summary>
    /// Retrieves a project by their IDUser
    /// </summary>
    /// <param name="id">The unique identifier of the user</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The user details if found</returns>
    //[HttpGet("LivroById/{id}")]
    //[ProducesResponseType(typeof(ApiResponseWithData<ListarLivroResponse>), StatusCodes.Status200OK)]
    //[ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    //[ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    //public async Task<IActionResult> ListProjectByIdUser([FromRoute] Guid idUser, CancellationToken cancellationToken)
    //{
    //    var request = new ListProjectRequest { IdUser = idUser };
        
    //    var command = _mapper.Map<ListarLivroCommand>(request);
    //    var response = await _mediator.Send(command, cancellationToken);

    //    return Ok(new ApiResponseWithData<List<ListarLivroResponse>>
    //    {
    //        Success = true,
    //        Message = "Projeto(s) do usuário("+ idUser + ") recuperado(s) com sucesso!",
    //        Data = _mapper.Map<List<ListarLivroResponse>>(response)
    //    });
    //}

}
