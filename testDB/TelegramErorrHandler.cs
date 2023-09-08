using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TgBot
{

    public class TelegramErrorHandler
    {
        private readonly string logFilePath;

        public TelegramErrorHandler(string logFilePath)
        {
            this.logFilePath = logFilePath;
        }

        // Handle errors by logging them
        public async Task HandleErrorAsync(Exception ex)
        {
            // Log the error
            LogError(ex);

            // Handle specific error scenarios as needed
            if (ex is HttpRequestException)
            {
                // Handle HTTP request errors (e.g., Telegram API request failed)
                Console.WriteLine("HTTP request error occurred.");
            }
            else if (ex is JsonException)
            {
                // Handle JSON parsing errors
                Console.WriteLine("JSON parsing error occurred.");
            }
            else
            {
                // Handle other types of errors
                Console.WriteLine("An unexpected error occurred.");
            }
        }

        // Log errors to a text file
        private void LogError(Exception ex)
        {
            try
            {
                using (StreamWriter writer = File.AppendText(logFilePath))
                {
                    writer.WriteLine($"[{DateTime.UtcNow}] Error: {ex.Message}");
                    writer.WriteLine($"StackTrace: {ex.StackTrace}");
                    writer.WriteLine();
                }
            }
            catch (Exception logEx)
            {
                // Handle any errors that occur while logging
                Console.WriteLine($"Error while logging: {logEx.Message}");
            }
        }
    }

}
