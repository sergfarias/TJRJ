using Microsoft.Extensions.Logging;

namespace brf_fnc_complex_work.services;

public class ComplexTask : IComplexTask
{
    #region Properties

    private readonly ILogger<ComplexTask> _logger;

    #endregion

    #region Constructor

    public ComplexTask(ILogger<ComplexTask> logger)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    #endregion

    #region Public Methods

    public Task Execute()
    {
        _logger.LogError($"Executed complex task!");
        return Task.CompletedTask;
    }

    #endregion
}

