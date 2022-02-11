using System;
//using System.Collections.Generic;
//using System.Data;
using System.Data.SQLite;
//using Xunit;

namespace SQL
{
    public class SQL_Helper
    {
        // Метод что бы открыть связь с БД (типо как делали в BaseTest с браузером или API_Helper). 
        public static SQLiteConnection OpenConnectionDB (string localPathToDB)
        {
            // Создаем строку, по которой код будет коннектиться с БД.
            String connectionString = localPathToDB;
            // Создаем связь под названием westeros и открываем эту связь с БД (БД называется westeros).
            SQLiteConnection westeros = new SQLiteConnection(connectionString);
            westeros.Open();
            return westeros;
        }

        // Метод, который отдает команды Базе Данных.
        // SqlCommand(String, SqlConnection).Инициализирует новый экземпляр класса SqlCommand текстом запроса и подключением SqlConnection.
        public static SQLiteCommand ManageDB(string manage, SQLiteConnection westeros)
        {
            SQLiteCommand cmd = westeros.CreateCommand();
            cmd.CommandText = manage;
            return cmd;
        }

        // Метод, который прерывает связь с БД.
        public static void CloseConnectionDB(SQLiteConnection westeros)
        {
            westeros.Close();
        }
    }
}