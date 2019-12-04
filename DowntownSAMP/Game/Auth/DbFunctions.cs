using BCrypt;
using MySql.Data.MySqlClient;
using SampSharp.GameMode.World;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;
using System.Threading.Tasks;

namespace DowntownSAMP.Game.Auth
{
    class DbFunctions
    {
        public static async Task<string> GetSaltPlayer(string username)
        {
            string salt = "";
            using (MySqlConnection connection = new MySqlConnection(Data.DbHandler.GetConnectionString()))
            {
                await connection.OpenAsync().ConfigureAwait(false);

                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM users WHERE username = @username";
                command.Parameters.AddWithValue("@username", username);

                DbDataReader reader = await command.ExecuteReaderAsync().ConfigureAwait(false);

                if (reader.HasRows)
                {
                    await reader.ReadAsync().ConfigureAwait(false);
                    {
                        salt = reader.GetString(reader.GetOrdinal("salt"));
                    }
                }
                return salt;
            }
        }

        public async static Task<bool> LoginPlayer(BasePlayer client, string username, string password)
        {
            string saltuser = await GetSaltPlayer(username);
            string penc = BCryptHelper.HashPassword(password, saltuser);

            using (MySqlConnection connection = new MySqlConnection(Data.DbHandler.GetConnectionString()))
            {
                await connection.OpenAsync().ConfigureAwait(false);

                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM users WHERE username = @username AND password = @password";
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@password", penc);

                DbDataReader reader = await command.ExecuteReaderAsync().ConfigureAwait(false);

                if (reader.HasRows)
                {
                    await reader.ReadAsync().ConfigureAwait(false);
                    {
                        Data.Classes.Player player = new Data.Classes.Player();
                        player.idDb = reader.GetInt32(reader.GetOrdinal("id"));
                        player.genre = reader.GetInt32(reader.GetOrdinal("genre"));
                        player.age = reader.GetInt32(reader.GetOrdinal("age"));
                        player.lastSkin = reader.GetInt32(reader.GetOrdinal("skin"));
                        player.username = username;
                        player.lastPos = new SampSharp.GameMode.Vector3(reader.GetDouble(reader.GetOrdinal("x")), reader.GetDouble(reader.GetOrdinal("y")), reader.GetDouble(reader.GetOrdinal("z")));
                        player.client = client;

                        Data.Lists.Players.Add(player);
                    }
                }
                return reader.HasRows;
            }
        }

        public async static Task<bool> CheckIfPlayerRegistered(string username)
        {
            bool checkName = false;
            using (MySqlConnection connection = new MySqlConnection(Data.DbHandler.GetConnectionString()))
            {
                await connection.OpenAsync().ConfigureAwait(false);

                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM users WHERE username = @playerName";
                command.Parameters.AddWithValue("@playerName", username);

                DbDataReader reader = await command.ExecuteReaderAsync().ConfigureAwait(false);
                checkName = reader.HasRows;
                return checkName;
            }
        }

        public async static Task<bool> CheckIfEmailRegistered(string email)
        {
            bool checkName = false;
            using (MySqlConnection connection = new MySqlConnection(Data.DbHandler.GetConnectionString()))
            {
                await connection.OpenAsync().ConfigureAwait(false);

                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM users WHERE email = @email";
                command.Parameters.AddWithValue("@email", email);

                DbDataReader reader = await command.ExecuteReaderAsync().ConfigureAwait(false);
                checkName = reader.HasRows;
                return checkName;
            }
        }

        public async static Task<int> RegisterPlayer(string username, string password, string email, int age, int genre, int skin)
        {
            if (await CheckIfPlayerRegistered(username)) return 0;
            else
            {
                using (MySqlConnection connection = new MySqlConnection(Data.DbHandler.GetConnectionString()))
                {
                    await connection.OpenAsync().ConfigureAwait(false);
                    MySqlCommand command = connection.CreateCommand();

                    string pSalt = BCryptHelper.GenerateSalt();
                    string pEncrypt = BCryptHelper.HashPassword(password, pSalt);

                    command.CommandText = "INSERT INTO users (username, password, salt, email, age, genre, skin) VALUES (@username, @password, @salt, @email, @age, @genre, @skin)";
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@password", pEncrypt);
                    command.Parameters.AddWithValue("@salt", pSalt);
                    command.Parameters.AddWithValue("@email", email);
                    command.Parameters.AddWithValue("@age", age);
                    command.Parameters.AddWithValue("@genre", genre);
                    command.Parameters.AddWithValue("@skin", skin);

                    await command.ExecuteNonQueryAsync().ConfigureAwait(false);
                    return (int)command.LastInsertedId;
                }
            }
        }

        public static async Task SaveAccount(string username, double x, double y, double z)
        {
            using (MySqlConnection connection = new MySqlConnection(Data.DbHandler.GetConnectionString()))
            {
                await connection.OpenAsync().ConfigureAwait(false);

                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "UPDATE users SET x = @x, y = @y, z = @z WHERE username = @username LIMIT 1";
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@x", x);
                command.Parameters.AddWithValue("@y", y);
                command.Parameters.AddWithValue("@z", z);

                await command.ExecuteNonQueryAsync().ConfigureAwait(false);
            }
        }
    }
}
