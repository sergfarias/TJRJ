using brf_fnc_http_trigger.Entities;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace brf_fnc_http_trigger.Services;

public class MyHttpService : IMyHttpService
{
    #region Properties

    private readonly ILogger<MyHttpService> _logger;

    #endregion

    #region Constructor

    public MyHttpService(ILogger<MyHttpService> logger)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    #endregion

    #region Public Methods

    public Task Save(UserGroup userGroup)
    {
        
        _logger.LogError($"Saving userGroup:");
        _logger.LogError($"{JsonConvert.SerializeObject(userGroup)}");
        return Task.CompletedTask;
    }

    #endregion

}
