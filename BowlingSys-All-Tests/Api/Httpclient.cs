using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Serilog;

namespace BowlingSYS_Tests.Httpclient;
public class Httpclient : IDisposable
{
    private readonly HttpClient _client;
    private readonly ILogger _logger;

    public Httpclient(ILogger logger)
    {
        _client = new HttpClient();
        _logger = logger;
    }

    public Httpclient(string baseUrl, ILogger logger)
    {
        _client = new HttpClient
        {
            BaseAddress = new Uri(baseUrl)
        };
        _logger = logger;
    }

    public async Task<string> GetAsync(string endpoint, Dictionary<string, string?> queryParams = null)
    {
        try
        {
            string url = endpoint;

            if (queryParams != null && queryParams.Count > 0)
            {
                var query = HttpUtility.ParseQueryString(string.Empty);
                foreach (var param in queryParams)
                {
                    if (!string.IsNullOrEmpty(param.Value)) 
                    {
                        query[param.Key] = param.Value;
                    }
                }
                url += "?" + query.ToString();
            }

            _logger.Information("Sending GET request to {Url}", url);
            HttpResponseMessage response = await _client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            string result = await response.Content.ReadAsStringAsync();
            _logger.Information("GET request to {Url} succeeded", url);
            return result;
        }
        catch (Exception ex)
        {
            _logger.Error(ex, "GET request to {Endpoint} failed", endpoint);
            throw;
        }
    }


    public async Task<string> PostAsync(string endpoint, string content, string mediaType = "application/json")
    {
        try
        {
            _logger.Information("Sending POST request to {Endpoint} with content {Content}", endpoint, content);
            HttpContent httpContent = new StringContent(content, Encoding.UTF8, mediaType);
            HttpResponseMessage response = await _client.PostAsync(endpoint, httpContent);
            response.EnsureSuccessStatusCode();
            string result = await response.Content.ReadAsStringAsync();
            _logger.Information("POST request to {Endpoint} succeeded", endpoint);
            return result;
        }
        catch (Exception ex)
        {
            _logger.Error(ex, "POST request to {Endpoint} failed", endpoint);
            throw;
        }
    }

    public void Dispose()
    {
        _client.Dispose();
        _logger.Information("HttpClient instance disposed.");
    }
}
