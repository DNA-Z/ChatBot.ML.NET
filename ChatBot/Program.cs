using ChatBot;
using ChatBot.ML.Model;
using ChatBot.Persistence.Context;
using ChatBot.Persistence.Persistence.mssql;
using ChatBot.TelegramBot;
using System.Configuration;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;


ChatBotConsole chatBot = new ChatBotConsole();
chatBot.GetSay();

//UseTelegramBot telegram = new UseTelegramBot();
//string response = telegram.GetUserResponse();

//UseTelegramBot telegramBot = new UseTelegramBot(message);

//telegram.GetBotAsync().Wait();

Console.ReadKey();