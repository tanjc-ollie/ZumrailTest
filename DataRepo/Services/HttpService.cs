using System.Net;
using DataRepo.Interfaces;

namespace DataRepo.Services;

public class HttpService : IHttpService
{
    private HttpClient _httpClient;

    public HttpService()
    {
        _httpClient = new HttpClient();
    }

    public async Task<string> GetAsync(string url, Dictionary<string, string> parameters)
    {
        string strParams = string.Empty;

        if (parameters?.Count > 0)
        {
            for (int i = 0; i < parameters.Count; i ++)
            {
                strParams += parameters.ElementAt(i).Key + "=" + WebUtility.UrlEncode(parameters.ElementAt(i).Value);

                if (i < parameters.Count - 1)
                    strParams += "&";
            }
        }
        
        try
        {
            string endpoint = url + "?" + strParams;
            using HttpResponseMessage response = await _httpClient.GetAsync(endpoint).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();
        
            return await response.Content.ReadAsStringAsync();
        }
        catch(HttpRequestException ex)
        {
            // some form of logging
            Console.WriteLine("Exception occured [HttpService:GetAsync] " + Environment.NewLine + ex.Message);
        }

        return await Task.FromResult(string.Empty);
    }
}
