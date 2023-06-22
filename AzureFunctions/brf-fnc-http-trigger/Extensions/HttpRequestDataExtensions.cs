using brf_fnc_http_trigger.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.Functions.Worker.Http;
using Newtonsoft.Json;

namespace brf_fnc_http_trigger.Extensions;

public static class HttpRequestDataExtensions
{
    public static async Task<UserGroup?> ToUserGroup(this HttpRequestData req)
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
