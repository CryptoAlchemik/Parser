using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public class UpdateHandler
{
    private readonly TelegramChatDataRetriever chatDataRetriever;
    private readonly TelegramMessageSender messageSender;

    public UpdateHandler(string apiToken)
    {
        this.chatDataRetriever = new TelegramChatDataRetriever(apiToken);
        this.messageSender = new TelegramMessageSender(apiToken);
    }

    public async Task StartHandlingUpdatesAsync()
    {
        int offset = 0; // Start with the first update

        while (true)
        {
            try
            {
                // Get updates from the Telegram API
                List<TelegramChatDataRetriever.Update> updates = await chatDataRetriever.GetUpdatesAsync(offset);

                // Process each update
                foreach (var update in updates)
                {
                    // Update the offset to avoid processing the same update multiple times
                    offset = update.UpdateId + 1;

                    // Handle the update (e.g., reply to a message)
                    await HandleUpdateAsync(update);
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions here
                Console.WriteLine($"Error handling updates: {ex.Message}");
            }

            // Add a delay to avoid excessive polling of the Telegram API
            await Task.Delay(TimeSpan.FromSeconds(1));
        }
    }

    // Handle individual updates (e.g., reply to a message)
    private async Task HandleUpdateAsync(TelegramChatDataRetriever.Update update)
    {
        // Check if the update contains a message
        if (update.Message != null)
        {
            int chatId = update.Message.Chat.Id;
            string messageText = update.Message.Text;

            // Implement your logic to handle the message
            // For example, you can reply to the message
            if (!string.IsNullOrWhiteSpace(messageText))
            {
                await messageSender.SendMessageAsync(chatId, "You said: " + messageText);
            }
        }
    }
}
