using System;
using System.Collections.Generic;
using Newtonsoft.Json;

public class TelegramMessageParser
{
    public TelegramMessageParser()
    {
        // You can add any initialization logic here
    }

    // Parse and extract information from an incoming message JSON
    public MessageInfo ParseMessage(string messageJson)
    {
        try
        {
            // Deserialize the JSON into a Message object
            Message message = JsonConvert.DeserializeObject<Message>(messageJson);

            if (message != null)
            {
                // Extract relevant information from the Message object
                int messageId = message.MessageId;
                int chatId = message.Chat.Id;
                int userId = message.From.Id;
                string messageText = message.Text;

                // Create and return a MessageInfo object with the extracted information
                return new MessageInfo
                {
                    MessageId = messageId,
                    ChatId = chatId,
                    Text = messageText
                };
            }
        }
        catch (Exception ex)
        {
            // Handle exceptions here
            Console.WriteLine($"Error parsing message: {ex.Message}");
        }

        // Return null if parsing fails
        return null;
    }

    // Create a class for deserializing the incoming message JSON

    public class Message
    {
        public int MessageId { get; set; }
        public User From { get; set; }
        public Chat Chat { get; set; }
        public int Date { get; set; }
        public string Text { get; set; }
    }

    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
    }

    public class Chat
    {
        public int Id { get; set; }
        public string Type { get; set; }
        // Add more properties as needed for your use case
    }

    // Create a class to store extracted message information
    public class MessageInfo
    {
        public int MessageId { get; set; }
        public int ChatId { get; set; }
        public string Text { get; set; }
    }
}
