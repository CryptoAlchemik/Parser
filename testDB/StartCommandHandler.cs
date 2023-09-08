using Application.UserTgs.Commands;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using static TelegramMessageParser;

namespace TgBot
{
    public class StartCommandHandler 
    {
        private readonly TelegramBotClient _botClient;
        public GetUserTgQuery? _getUserTgQuery;
        public CreateUserTgCommand<UserTg> _createUserTgCommand;
  

        public StartCommandHandler(TelegramBotClient botClient)
        {
            _botClient = botClient;
        }

        private async Task HandleStartCommandAsync(Message message)
        {
            var chatId = message.Chat.Id;
            var userId = message.From.Id;


            // Collect user data (you can customize this part)
            var userInfo = new UserTg
            {
                ChatId = message.From.Id,   
                FirstName = message.From.FirstName,
                LastName = message.From.LastName,
                UserName = message.From.Username,
            };
            // Save user data (you can customize this part)
            await _createUserTgCommand.CreateEntityAsync(userInfo);
                
            // Send a welcome message or menu
            await SendWelcomeMessageAsync(userInfo);

            // Add logic to send the menu or perform other actions
        }

        private async Task SendWelcomeMessageAsync(UserTg userTg)
        {
            var welcomeMessage = Convert.ToString(InlineKeyboardMarkupBuilder.BuildStartMenu(userTg));
            await _botClient.SendTextMessageAsync(userTg.ChatId, welcomeMessage);
           
        }

    }

}
