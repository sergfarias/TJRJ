using brf_fnc_http_trigger.Extensions;
using brf_fnc_http_trigger.Services;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using System.Net;

namespace brf_fnc_http_trigger;

public class FcnHttpTrigger
{
    #region Properties

    private readonly ILogger _logger;
    private readonly IMyHttpService _myHttpService;

    #endregion

    #region Constructor

    public FcnHttpTrigger(
        ILoggerFactory loggerFactory,
        IMyHttpService myHttpService)
    {
        _logger = loggerFactory.CreateLogger<FcnHttpTrigger>();
        _myHttpService = myHttpService ?? throw new ArgumentNullException(nameof(myHttpService));
    }

    #endregion

    #region Function

    [Function("FcnHttpTrigger")]
    public async Task<HttpResponseData> RunAsync(
        [HttpTrigger(AuthorizationLevel.Function, "post")]
          HttpRequestData req
     )
    {
        var response = req.CreateResponse(HttpStatusCode.OK);

        _logger.LogInformation("C# HTTP trigger function processed a request.");

        var userGroup = await req.ToUserGroup();

        if (userGroup is null)
        {
            response = req.CreateResponse(HttpStatusCode.BadRequest);
            response.WriteString("User group inválid.");
            return response;
        }

        await _myHttpService.Save(userGroup);

        return response;
    }

    #endregion
}
