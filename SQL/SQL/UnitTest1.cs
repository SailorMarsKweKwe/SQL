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
        public void SimpleTest1()
        {

            SQLiteConnection westeros = SQL_Helper.OpenConnectionDB(@"Data Source =/Users/innasukhina/Documents/westeros.db");
            SQLiteCommand cmd = SQL_Helper.ManageDB("SELECT family_name FROM families WHERE family_id= 4", westeros);
            var actual = cmd.ExecuteScalar();
            Assert.Equal("Arryn", actual);
            SQL_Helper.CloseConnectionDB(westeros);
        }
        [Fact]
        public void FamilyIdByHeroIdTest()
        {

            SQLiteConnection westeros = SQL_Helper.OpenConnectionDB(@"Data Source =/Users/innasukhina/Documents/westeros.db");
            SQLiteCommand cmd = SQL_Helper.ManageDB("SELECT family_id FROM westeros WHERE hero_id = (SELECT hero_id FROM" +
                                                    " heroes WHERE hero_name= 'Robert Baratheon' AND castle='Storms End')", westeros);
            var actual = cmd.ExecuteScalar();
            Assert.Equal(7, Convert.ToInt64(actual));
            SQL_Helper.CloseConnectionDB(westeros);
        }
        /*
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
        */
    }
}
