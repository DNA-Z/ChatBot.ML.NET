using System.Data.SqlClient;

namespace ChatBot.Persistence.Persistence.mssql
{
    internal class StoredProcedure
    {
        public string CreateProc(string connectStr, int category)
        {
            using (SqlConnection connection = new SqlConnection(connectStr))
            {
                SqlCommand cmd = new SqlCommand("spRespCategory", connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@Category", category);

                connection.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();

                return reader[0].ToString();
            }
        }
    }
}
