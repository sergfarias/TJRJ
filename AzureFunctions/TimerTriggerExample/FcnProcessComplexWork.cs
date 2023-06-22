using System;
using brf_fnc_complex_work.services;
using Entities;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace TimerTriggerExample;

public class FcnProcessComplexWork
{
    #region Properties

    private readonly ILogger _logger;
    private readonly IComplexTask _complexTask;

    #endregion

    #region Constructor

    public FcnProcessComplexWork(
        ILoggerFactory loggerFactory,
        IComplexTask complexTask)
    {
        _logger = loggerFactory.CreateLogger<FcnProcessComplexWork>();
        _complexTask = complexTask;
    }

    #endregion

    #region Function

    [Function("FcnProcessComplexWork")]
    public void Run([TimerTrigger("%trigger%")] MyInfo myTimer)
    {
        _logger.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
        _logger.LogInformation($"Next timer schedule at: {myTimer.ScheduleStatus.Next}");

        _complexTask.Execute();
    }

    #endregion

}
