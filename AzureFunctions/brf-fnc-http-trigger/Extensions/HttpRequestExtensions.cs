using brf_fnc_http_trigger.Entities;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace brf_fnc_http_trigger.Extensions;

public static class HttpRequestExtensions
{
    public static async Task<UserGroup?> ToUserGroup(this HttpRequest req)
    {
        string payload = String.Empty;
        using (StreamReader streamReader = new StreamReader(req.Body))
        {
            payload = await streamReader.ReadToEndAsync();
        }        

        if (string.IsNullOrEmpty(payload))
            return null;

        return JsonConvert.DeserializeObject<UserGroup>(payload);
    }
}
