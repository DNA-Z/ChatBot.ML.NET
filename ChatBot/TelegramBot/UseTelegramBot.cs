using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace ChatBot.TelegramBot
{
    public class UseTelegramBot
    {
        //public string MessageText { get; set; }
        //public UseTelegramBot() { }
        //public UseTelegramBot(string messageText)
        //{
        //    MessageText = messageText;
        //}

        //public string messageResponse;
        const string token = "***";

        public async Task GetBotAsync()
        {
            var botClient = new TelegramBotClient($"{token}");

            var cts = new CancellationTokenSource();

            // StartReceiving не блокирует вызывающий поток. Получение выполняется в ThreadPool.
            var receiverOptions = new ReceiverOptions
            {
                AllowedUpdates = { } // получать все типы обновлений
            };

            botClient.StartReceiving(
                HandleUpdateAsync,
                HandleErrorAsync,
                receiverOptions,
                cancellationToken: cts.Token);

            var me = await botClient.GetMeAsync();

            Console.WriteLine($"Start listening for @{me.Username}");
            Console.ReadLine();

            cts.Cancel();

            //Console.WriteLine($"Start listening for @{me.Username}");            
        }

        async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            // Только обработка обновлений сообщений: https://core.telegram.org/bots/api#message
            if (update.Type != UpdateType.Message)
                return;
            // Обрабатывать только текстовые сообщения
            if (update.Message!.Type != MessageType.Text)
                return;

            var chatId = update.Message.Chat.Id;
            var messageText = update.Message.Text;

            Console.WriteLine($"Received a '{messageText}' message in chat {chatId}.");

            Message sentMessage = await botClient.SendTextMessageAsync(
            chatId: chatId,
            text: "You said:\n" + messageText,
            cancellationToken: cancellationToken);
        }

        Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            var ErrorMessage = exception switch
            {
                ApiRequestException apiRequestException
                    => $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
                _ => exception.ToString()
            };

            Console.WriteLine(ErrorMessage);
            return Task.CompletedTask;
        }

        //public string GetUserResponse()
        //{
        //    return messageResponse;
        //}
    }
}
