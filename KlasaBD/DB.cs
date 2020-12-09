using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Microsoft.Data.Sqlite;

namespace KlasaBD
{
    public class DB
    {
        private SqliteConnection connection;
        private const String path = "baza.db";

        /// <summary>
        /// Makes a connection to database, creates database if doesn't exist.
        /// </summary>
        public DB()
        {
            this.connection = new SqliteConnection($"Data Source={path}");
            SQLitePCL.Batteries.Init();
            bool exists = File.Exists(path);
            this.connection.Open();
            if (!exists)
            {
                var command = connection.CreateCommand();
                command.CommandText =
                    @"
                    CREATE TABLE Users
                    ( 
                        login varchar(32),
                        password varchar(32),
                        id int primary key
                    )
                ";
                command.ExecuteNonQuery();
                command = connection.CreateCommand();
                command.CommandText =
                    @"
                    CREATE TABLE Log
                    ( 
                        log_id int primary key,
                        user_login varchar(32),
                        sender text,
                        dt text,
                        message text,
                        ip text
                    )
                ";
                command.ExecuteNonQuery();
            }
        }
        /// <summary>
        /// Adds new user to database, returns false if user of given login already exists.
        /// </summary>
        /// <param name="login">user login</param>
        /// <param name="password">user password</param>
        /// <returns></returns>
        public bool AddUser(string login, string password)
        {
            login = login.Trim(' ');
            password = password.Trim(' ');
            if (login.Length != 0 && password.Length != 0)
            {
                var command = connection.CreateCommand();

                command.CommandText =
                $@"
                    SELECT password
                    FROM users
                    WHERE login='{login}'
            ";
                var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    return false;
                }
                command = connection.CreateCommand();
                command.CommandText =
                    $@"
                    INSERT INTO users (login, password)
                    VALUES  ('{login}' , '{password}');
                ";
                command.ExecuteNonQuery();
                return true;
            }
            else
            {
                return false;
            }   
        }
        public void AddLog(string login, string sender, string message, string ip)
        {
            var command = connection.CreateCommand();

            command.CommandText =
                    $@"
                    INSERT INTO Log (user_login, sender, dt, message, ip)
                    VALUES  ('{login}' , '{sender}', datetime('now', 'localtime'), '{message}', '{ip}');
                ";
            command.ExecuteNonQuery();
        }
        /// <summary>
        /// Checks if given autentication paramaeters matches parameters in database. 
        /// </summary>
        /// <param name="login">user login</param>
        /// <param name="password">user password</param>
        /// <returns></returns>
        public bool AuthenticateUser(string login, string password)
        {
            login = login.Trim(' ');
            password = password.Trim(' ');
            if (login.Length != 0 && password.Length != 0)
            {
                var command = connection.CreateCommand();

                command.CommandText =
                $@"
                    SELECT password
                    FROM users
                    WHERE login='{login}'
                ";
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        if (password.Equals(reader.GetString(0)))
                        {
                            return true;
                        }
                    }
                }
                return false;
            } else
            {
                return false;
            }
        }
    }
}
