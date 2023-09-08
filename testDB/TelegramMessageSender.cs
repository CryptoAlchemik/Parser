using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

public class TelegramMessageSender
{
    private readonly TelegramApiHelper telegramApiHelper;

    public TelegramMessageSender(string apiToken)
    {
        this.telegramApiHelper = new TelegramApiHelper(apiToken);
    }

    // Send a text message to a chat
    public async Task<string> SendMessageAsync(int chatId, string text)
    {
        try
        {
            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("chat_id", chatId.ToString()),
                new KeyValuePair<string, string>("text", text),
            });

            string response = await telegramApiHelper.SendPostRequestAsync("sendMessage", content);

            // Deserialize the JSON response to extract message details if needed
            // For example, you can extract the message ID

            return response;
        }
        catch (Exception ex)
        {
            // Handle exceptions here
            Console.WriteLine($"Error sending message: {ex.Message}");
            throw;
        }
    }
}
