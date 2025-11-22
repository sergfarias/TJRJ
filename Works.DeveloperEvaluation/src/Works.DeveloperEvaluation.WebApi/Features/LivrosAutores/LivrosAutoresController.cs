using AutoMapper;
using Works.DeveloperEvaluation.Application.LivrosAutores.InserirLivroAutor;
using Works.DeveloperEvaluation.WebApi.Common;
using Works.DeveloperEvaluation.WebApi.Features.LivrosAutores.InserirLivroAutor;
using MediatR;
using Microsoft.AspNetCore.Mvc;
namespace Works.DeveloperEvaluation.WebApi.Features.Livros;

/// <summary>
/// Controller for managing project operations
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class LivrosAutoresController : BaseController
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of ProjectsController
    /// </summary>
    /// <param name="mediator">The mediator instance</param>
    /// <param name="mapper">The AutoMapper instance</param>
    public LivrosAutoresController(IMediator mediator, IMapper mapper)
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
    [HttpPost("InserirLivroAutor")]
    [ProducesResponseType(typeof(ApiResponseWithData<GetLivroAutorResponse>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> InserirLivroAutor([FromBody] InserirLivroAutorRequest request, CancellationToken cancellationToken)
    {
        //var validator = new InserirLivroAutorRequestValidator();
        //var validationResult = await validator.ValidateAsync(request, cancellationToken);

        //if (!validationResult.IsValid)
        //    return BadRequest(validationResult.Errors);

        var command = _mapper.Map<InserirLivroAutorCommand>(request);
        var response = await _mediator.Send(command, cancellationToken);

        return Created(string.Empty, new ApiResponseWithData<GetLivroAutorResponse>
        {
            Success = true,
            Message = "Livro/assunto inserido com sucesso!",
            Data = _mapper.Map<GetLivroAutorResponse>(response)
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
