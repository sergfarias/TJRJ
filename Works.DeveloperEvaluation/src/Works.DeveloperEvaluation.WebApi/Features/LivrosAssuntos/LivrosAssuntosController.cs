using AutoMapper;
using Works.DeveloperEvaluation.Application.LivrosAssuntos.InserirLivroAssunto;
using Works.DeveloperEvaluation.WebApi.Common;
using Works.DeveloperEvaluation.WebApi.Features.Livros.InserirLivro;
using Works.DeveloperEvaluation.WebApi.Features.LivrosAssuntos.InserirLivroAssunto;
using MediatR;
using Microsoft.AspNetCore.Mvc;
namespace Works.DeveloperEvaluation.WebApi.Features.Livros;

/// <summary>
/// Controller for managing project operations
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class LivrosAssuntosController : BaseController
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of ProjectsController
    /// </summary>
    /// <param name="mediator">The mediator instance</param>
    /// <param name="mapper">The AutoMapper instance</param>
    public LivrosAssuntosController(IMediator mediator, IMapper mapper)
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
    [HttpPost("InserirLivroAssunto")]
    [ProducesResponseType(typeof(ApiResponseWithData<GetLivroAssuntoResponse>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> InserirLivroAssunto([FromBody] InserirLivroAssuntoRequest request, CancellationToken cancellationToken)
    {
        //var validator = new InserirLivroAssuntoRequestValidator();
        //var validationResult = await validator.ValidateAsync(request, cancellationToken);

        //if (!validationResult.IsValid)
        //    return BadRequest(validationResult.Errors);

        var command = _mapper.Map<InserirLivroAssuntoCommand>(request);
        var response = await _mediator.Send(command, cancellationToken);

        return Created(string.Empty, new ApiResponseWithData<GetLivroAssuntoResponse>
        {
            Success = true,
            Message = "Livro/assunto inserido com sucesso!",
            Data = _mapper.Map<GetLivroAssuntoResponse>(response)
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
