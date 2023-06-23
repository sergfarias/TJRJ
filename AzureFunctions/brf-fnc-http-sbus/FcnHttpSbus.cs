using System.Net;
using brf_fnc_http_trigger.Entities;
using brf_fnc_http_trigger.Extensions;
using brf_fnc_http_trigger.Services;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace brf_fnc_http_sbus
{
    public class FcnHttpSbus
    {
        #region Properties

        private readonly ILogger _logger;
        private readonly IMyHttpService _myHttpService;

        #endregion

        #region Constructor

        public FcnHttpSbus(
            ILoggerFactory loggerFactory,
            IMyHttpService myHttpService)
        {
            _logger = loggerFactory.CreateLogger<FcnHttpSbus>();
            _myHttpService = myHttpService ?? throw new ArgumentNullException(nameof(myHttpService));
        }

        #endregion

        #region Function

        [Function("FcnHttpSbus")]
        [ServiceBusOutput("brf-sb-usergroup",
                          ServiceBusEntityType.Queue,
                          Connection = "ServiceBusConnection")]
        public async Task<UserGroup?> RunAsync(
        [HttpTrigger(AuthorizationLevel.Function, "post")]
          HttpRequestData req)
     
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            var userGroup = await req.ToUserGroup();

            if (userGroup is null)            
                return null;            

            await _myHttpService.Save(userGroup);

            return userGroup;
        }

        #endregion
    }
}
