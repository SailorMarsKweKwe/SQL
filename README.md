# SQL

(из docs.microsoft.com)

SqlCommand(String, SqlConnection)
Инициализирует новый экземпляр класса SqlCommand текстом запроса и подключением SqlConnection.



Примеры
В следующем примере создается SqlCommand и задаются некоторые из его свойств.



private static void CreateCommand(string queryString,
    string connectionString)
{
    using (SqlConnection connection = new SqlConnection(
               connectionString))
    {
        SqlCommand command = new SqlCommand(
            queryString, connection);
        connection.Open();
        SqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            Console.WriteLine(String.Format("{0}, {1}",
                reader[0], reader[1]));
        }
    }
}








