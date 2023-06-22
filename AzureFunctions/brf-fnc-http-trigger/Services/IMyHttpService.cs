using brf_fnc_http_trigger.Entities;

namespace brf_fnc_http_trigger.Services;

public interface IMyHttpService
{
    public Task Save(UserGroup userGroup);
}
