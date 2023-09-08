// Replace "YOUR_API_TOKEN" with your actual Telegram Bot API token
string apiToken = "1456030797:AAF1tjwO7N8VNQKBpZ3kP9RTOtEUvjMVGs8";
TelegramApiHelper telegramApi = new TelegramApiHelper(apiToken);

// Example: Sending a GET request to get updates
string getUpdatesResponse = await telegramApi.SendGetRequestAsync("getUpdates");
Console.WriteLine(getUpdatesResponse);

// Example: Sending a POST request to send a message
var content = new FormUrlEncodedContent(new[]
{
    new KeyValuePair<string, string>("chat_id", "YOUR_CHAT_ID"),
    new KeyValuePair<string, string>("text", "Hello, Telegram!"),
});

string sendMessageResponse = await telegramApi.SendPostRequestAsync("sendMessage", content);
Console.WriteLine(sendMessageResponse);

// -----Chat Data Retiever

TelegramChatDataRetriever chatDataRetriever = new TelegramChatDataRetriever(apiToken);

// Example: Get updates
List<TelegramChatDataRetriever.Update> updates = await chatDataRetriever.GetUpdatesAsync();

foreach (var update in updates)
{
    Console.WriteLine($"Update ID: {update.UpdateId}");
    Console.WriteLine($"Chat ID: {update.Message.Chat.Id}");
    Console.WriteLine($"Message Text: {update.Message.Text}");
    Console.WriteLine();
}

// ----------- Send message

TelegramMessageSender messageSender = new TelegramMessageSender(apiToken);

// Replace "YOUR_CHAT_ID" with the actual chat ID where you want to send the message
int chatId = 613539894;
string messageText = "Hello, Telegram! This is a test message.";

// Example: Send a message
string response = await messageSender.SendMessageAsync(chatId, messageText);
Console.WriteLine("Message sent!");

// ------------ Handling updates

UpdateHandler updateHandler = new UpdateHandler(apiToken);

// Start handling updates
await updateHandler.StartHandlingUpdatesAsync();

// ------------- Message Parsing

TelegramMessageParser messageParser = new TelegramMessageParser();

// Replace "messageJson" with the actual JSON string representing the incoming message
string messageJson = "{\"message_id\":123,\"chat\":{\"id\":456},\"text\":\"Hello, Telegram!\"}";

TelegramMessageParser.MessageInfo messageInfo = messageParser.ParseMessage(messageJson);

if (messageInfo != null)
{
    Console.WriteLine($"Message ID: {messageInfo.MessageId}");
    Console.WriteLine($"Chat ID: {messageInfo.ChatId}");
    Console.WriteLine($"Message Text: {messageInfo.Text}");
}
