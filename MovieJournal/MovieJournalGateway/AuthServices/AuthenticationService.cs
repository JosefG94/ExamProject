using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;

namespace MovieJournalGateway.AuthServices
{
    public class AuthenticationService
    {
    private AuthenticationService(string baseUri)
    {
        BaseUri = baseUri;
    }

    private static AuthenticationService _instance;

    public static AuthenticationService Instance
    {
        get { return _instance ?? (_instance = new AuthenticationService(ConfigurationManager.AppSettings["APIUri"])); }
    }

    public string BaseUri { get; private set; }

    public async Task<T> AuthenticateAsync<T>(string userName, string password)
    {
        using (var client = new HttpClient())
        {
            var result = await client.PostAsync(BuildActionUri("/Token"), new FormUrlEncodedContent(new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("grant_type", "password"),
                    new KeyValuePair<string, string>("userName", userName),
                    new KeyValuePair<string, string>("password", password)
                }));

            string json = await result.Content.ReadAsStringAsync();
            if (result.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<T>(json);
            }

            throw new AuthenticationException(result.StatusCode, json);
        }
    }

    public async Task<T> GetAsync<T>(string action, string bearerToken = null)
    {
        using (var client = new BTokenHttpClient())
        {
            if (!bearerToken.IsNullOrWhiteSpace())
            {
                //Add the authorization header
                client.DefaultRequestHeaders.Authorization =
                    AuthenticationHeaderValue.Parse("Bearer " + bearerToken);
            }

            var result = await client.GetAsync(BuildActionUri(action));

            string json = await result.Content.ReadAsStringAsync();
            if (result.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<T>(json);
            }

            throw new AuthenticationException(result.StatusCode, json);
        }
    }

    public async Task PutAsync<T>(string action, T data)
    {
        using (var client = new BTokenHttpClient())
        {
            var result = await client.PutAsJsonAsync(BuildActionUri(action), data);
            if (result.IsSuccessStatusCode)
            {
                return;
            }

            string json = await result.Content.ReadAsStringAsync();
            throw new AuthenticationException(result.StatusCode, json);
        }
    }

    public async Task PostAsync<T>(string action, T data)
    {
        using (var client = new BTokenHttpClient())
        {
            var result = await client.PostAsJsonAsync(BuildActionUri(action), data);
            if (result.IsSuccessStatusCode)
            {
                return;
            }

            string json = await result.Content.ReadAsStringAsync();
            throw new AuthenticationException(result.StatusCode, json);
        }
    }

    private string BuildActionUri(string action)
    {
        return BaseUri + action;
    }
    }
}
