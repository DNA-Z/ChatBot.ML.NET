using System.Configuration;
using System.Data.SqlClient;

namespace ChatBot.Persistence.Persistence.mssql
{
    public class SrtingConnection
    {
        public void CreateStringConnection()
        {
            SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
            sqlConnectionStringBuilder.DataSource = @".\SQLEXPRESS";
            sqlConnectionStringBuilder.InitialCatalog = "SocialNetworkDB";
            sqlConnectionStringBuilder.IntegratedSecurity = true;
            sqlConnectionStringBuilder.Pooling = true;

            var setting = new ConnectionStringSettings
            {
                Name = "SocialNetworkConnectionString",
                ConnectionString = sqlConnectionStringBuilder.ConnectionString,
            };

            Configuration config;
            config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.ConnectionStrings.ConnectionStrings.Add(setting);

            ConnectionStringsSection section = config.GetSection("connectionStrings") as ConnectionStringsSection;

            if (section != null)
                section.SectionInformation.ProtectSection("DataProtectionConfigurationProvider");

            config.Save();
        }

        public string ReadStringConnection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["SocialNetworkConnectionString"].ConnectionString;

            return connectionString;
        }
    }
}
