using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using Xunit;

namespace SQL
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            String connectionString = @"Data Source=/Users/innasukhina/Documents/qweqwe.db";
            List<string>names = new List<string>();
            List<int> user_ids = new List<int>();

            SQLiteConnection db = new SQLiteConnection(connectionString);
            db.Open();
            SQLiteCommand cmd = db.CreateCommand();
         
            cmd.CommandText = "SELECT * FROM client";
            SQLiteDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                names.Add(reader[0].ToString());
                user_ids.Add(Convert.ToInt32(reader[1]));
            }
            foreach(string a in names)
            {
                Console.WriteLine(a);
            }
            foreach(int a in user_ids)
            {
                Console.WriteLine(a);
            }


        }
    }
}
