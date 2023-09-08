using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using static TelegramMessageParser;

public class TelegramChatDataRetriever
{
    private readonly TelegramApiHelper telegramApiHelper;

    public TelegramChatDataRetriever(string apiToken)
    {
        this.telegramApiHelper = new TelegramApiHelper(apiToken);
    }

    // Get updates from Telegram API
    public async Task<List<Update>> GetUpdatesAsync(int offset = 0)
    {
        try
        {
            string endpoint = $"getUpdates?offset={offset}";
            string response = await telegramApiHelper.SendGetRequestAsync(endpoint);

            // Deserialize the JSON response into a list of updates
            List<Update> updates = JsonConvert.DeserializeObject<List<Update>>(response);

            return updates;
        }
        catch (Exception ex)
        {
            // Handle exceptions here
            Console.WriteLine($"Error getting updates: {ex.Message}");
            throw;
        }
    }

    // Create a class for deserializing the update JSON
    public class Update
    {
        public int UpdateId { get; set; }
        public Message Message { get; set; }
    }


}
