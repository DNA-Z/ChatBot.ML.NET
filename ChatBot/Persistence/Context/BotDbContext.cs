using ChatBot.Persistence.Persistence.mssql;
using System.Configuration;
using System.Data.SqlClient;

namespace ChatBot.Persistence.Context
{
    public class BotDbContext
    {
        public void ToConnect()
        {
            string conStr = ConfigurationManager.ConnectionStrings["ChatbotConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(conStr))
            {
                connection.StateChange += ConnectionStateChange;

                try
                {
                    connection.Open();
                    Console.WriteLine(connection.State);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            //var setting = new ConnectionStringSettings
            //{
            //    Name = "ChatbotConnectionString",
            //    ConnectionString = SqlConnectionStringBuilder.ConnectionString,
            //};

            //Configuration config;
            //config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            //config.ConnectionStrings.ConnectionStrings.Add(setting);
        }

        private void ConnectionStateChange(object sender, System.Data.StateChangeEventArgs e)
        {
            SqlConnection connection = sender as SqlConnection;

            Console.WriteLine();
            Console.WriteLine
                (
                "Connection to" + Environment.NewLine +
                "Data Source: " + connection.DataSource + Environment.NewLine +
                "Database: " + connection.Database + Environment.NewLine +
                "State " + connection.State
                );
        }
    }
}
