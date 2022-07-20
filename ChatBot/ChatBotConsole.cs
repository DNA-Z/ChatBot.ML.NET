using ChatBot.ML.Model;
using ChatBot.Persistence.Persistence.mssql;
using System.Configuration;

namespace ChatBot
{
    public class ChatBotConsole
    {
        public void GetSay()
        {
            string conStr = ConfigurationManager.ConnectionStrings["ChatbotConnectionString"].ConnectionString;
            UseML mL = new UseML();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Добро пожаловать\nНажмите любу клавишу и начните общение с ИИ\n(например, спросите что-то или поздоровайтесь)" +
                "\nДля завершения - нажмите клавишу Esc\n\n");
            string request = String.Empty;

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                request = Console.ReadLine();
                if(request == String.Empty)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Выход");
                    Console.ResetColor();
                    return;
                }
                var proc = new StoredProcedure();
                int predicate = mL.PredicateML(request);
                string response = proc.CreateProc(conStr, predicate);
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine(response);
            }
        }
    }
}
