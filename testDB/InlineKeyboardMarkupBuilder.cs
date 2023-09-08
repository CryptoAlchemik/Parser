using Domain.Entities;
using Telegram.Bot;
using Telegram.Bot.Types.ReplyMarkups;
using static TelegramMessageParser;

namespace TgBot
{
        public class InlineKeyboardMarkupBuilder
        {
        //private readonly TelegramBotClient _botClient;

        //public InlineKeyboardMarkupBuilder(TelegramBotClient botClient)
        //{
        //    _botClient = botClient;
        //}
        public static InlineKeyboardMarkup BuildStartMenu(UserTg usertg)
        {
            var keyboardButtons = new List<InlineKeyboardButton[]>();

            bool isAdmin = usertg.IsAdmin;

            keyboardButtons.Add(new[]
                {
                InlineKeyboardButton.WithCallbackData("1. P2P Currency Exchange", "p2p_exchange"),
                InlineKeyboardButton.WithCallbackData("2. P2P Second Hand", "p2p_second_hand"),
                InlineKeyboardButton.WithCallbackData("3. Events Around", "events_around"),
                InlineKeyboardButton.WithCallbackData("4. Create Advertise", "create_advertise"),
                InlineKeyboardButton.WithCallbackData("5. My Profile", "my_profile"),
                InlineKeyboardButton.WithCallbackData("6. Contact Support", "contact_support"),
                });

            if (isAdmin)
            {
                keyboardButtons.Add(new[]
                {
                InlineKeyboardButton.WithCallbackData("7. Sources Settings", "sources_settings"),
                InlineKeyboardButton.WithCallbackData("8. Manage Advertises", "manage_advertises"),
                });
            }

            return new InlineKeyboardMarkup(keyboardButtons);
        }



        private async void Bot_OnCallbackQuery(UserTg userTg, CallbackQueryEventArgs e)
        {
            var callbackData = e.CallbackQuery.Data;
            var chatId = e.CallbackQuery.Message.Chat.Id;

            switch (callbackData)
            {
                case "p2p_exchange":
                    await HandleP2PExchange(chatId);
                    break;
                case "p2p_second_hand":
                    await HandleP2PSecondHand(chatId);
                    break;
                    // Add more cases for other options
            }
        }

        private Task HandleP2PSecondHand(object chatId)
        {
            throw new NotImplementedException();
        }

        private Task HandleP2PExchange(object chatId)
        {
            throw new NotImplementedException();
        }
    }

}
