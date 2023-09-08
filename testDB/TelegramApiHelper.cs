using System;
using System.Net.Http;
using System.Threading.Tasks;

public class TelegramApiHelper
{
    private readonly string apiBaseUrl;
    private readonly HttpClient httpClient;

    public TelegramApiHelper(string apiToken)
    {
        this.apiBaseUrl = $"https://api.telegram.org/bot{apiToken}/";
        this.httpClient = new HttpClient();
    }

    // Send a GET request to the Telegram API
    public async Task<string> SendGetRequestAsync(string endpoint)
    {
        try
        {
            var response = await httpClient.GetAsync($"{apiBaseUrl}{endpoint}");
            response.EnsureSuccessStatusCode(); // Ensure a successful response
            return await response.Content.ReadAsStringAsync();
        }
        catch (HttpRequestException ex)
        {
            // Handle exceptions here
            Console.WriteLine($"Error sending GET request: {ex.Message}");
            throw;
        }
    }

    // Send a POST request to the Telegram API
    public async Task<string> SendPostRequestAsync(string endpoint, HttpContent content)
    {
        try
        {
            var response = await httpClient.PostAsync($"{apiBaseUrl}{endpoint}", content);
            response.EnsureSuccessStatusCode(); // Ensure a successful response
            return await response.Content.ReadAsStringAsync();
        }
        catch (HttpRequestException ex)
        {
            // Handle exceptions here
            Console.WriteLine($"Error sending POST request: {ex.Message}");
            throw;
        }
    }
}