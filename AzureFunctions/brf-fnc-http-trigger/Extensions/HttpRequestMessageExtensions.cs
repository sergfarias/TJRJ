using brf_fnc_http_trigger.Entities;
using Newtonsoft.Json;

namespace brf_fnc_http_trigger.Extensions;

public static class HttpRequestMessageExtensions
{
    public static async Task<UserGroup?> ToUserGroup(this HttpRequestMessage req)
    {
        string payload = await req?.Content?.ReadAsStringAsync();

        if (string.IsNullOrEmpty(payload))
            return null;

        return JsonConvert.DeserializeObject<UserGroup>(payload);
    }
}
