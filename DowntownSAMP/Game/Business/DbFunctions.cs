using MySql.Data.MySqlClient;
using SampSharp.GameMode;
using SampSharp.GameMode.World;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;
using System.Threading.Tasks;

namespace DowntownSAMP.Game.Business
{
    public class DbFunctions
    {
        public async static Task SpawnBusiness()
        {
            using (MySqlConnection connection = new MySqlConnection(Data.DbHandler.GetConnectionString()))
            {
                await connection.OpenAsync().ConfigureAwait(false);

                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM business";

                DbDataReader reader = await command.ExecuteReaderAsync().ConfigureAwait(false);

                if (reader.HasRows)
                {
                    await reader.ReadAsync().ConfigureAwait(false);
                    {
                        Data.Classes.Business negocio = new Data.Classes.Business();
                        negocio.idDb = reader.GetInt32(reader.GetOrdinal("id"));
                        negocio.owner = reader.GetInt32(reader.GetOrdinal("owner"));
                        negocio.type = reader.GetInt32(reader.GetOrdinal("type"));
                        negocio.price = reader.GetInt32(reader.GetOrdinal("price"));
                        negocio.idDb = reader.GetInt32(reader.GetOrdinal("id"));
                        negocio.safe = reader.GetInt32(reader.GetOrdinal("safe"));
                        negocio.name = reader.GetString(reader.GetOrdinal("name"));
                        negocio.position = new Vector3(reader.GetDouble(reader.GetOrdinal("x")), reader.GetDouble(reader.GetOrdinal("y")), reader.GetDouble(reader.GetOrdinal("z")));

                        SampSharp.Streamer.World.DynamicTextLabel label = new SampSharp.Streamer.World.DynamicTextLabel($"{negocio.name}\nPulsa F para interactuar", new SampSharp.GameMode.SAMP.Color(255, 255, 255), negocio.position, 3f);
                        SampSharp.Streamer.World.DynamicPickup pickup;
                        SampSharp.Streamer.World.DynamicMapIcon icon;

                        switch (negocio.type)
                        {
                            case 1:
                                pickup = new SampSharp.Streamer.World.DynamicPickup(1274, 1, negocio.position);
                                icon = new SampSharp.Streamer.World.DynamicMapIcon(negocio.position, 55);
                                break;

                            default:
                                pickup = new SampSharp.Streamer.World.DynamicPickup(1274, 1, negocio.position);
                                icon = new SampSharp.Streamer.World.DynamicMapIcon(negocio.position, 55);
                                break;
                        }

                        pickup.PickedUp += Game.Business.Responses.pickUpBusinessResponse;

                        negocio.label = label;
                        negocio.pickup = pickup;
                        negocio.icon = icon;

                        Data.Lists.Business.Add(negocio);
                    }
                }
            }
        }

        public static async Task UpdateBusinessOwner(int id, int owner)
        {
            using (MySqlConnection connection = new MySqlConnection(Data.DbHandler.GetConnectionString()))
            {
                await connection.OpenAsync().ConfigureAwait(false);

                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "UPDATE business SET owner = @owner WHERE id = @id LIMIT 1";
                command.Parameters.AddWithValue("@owner", owner);
                command.Parameters.AddWithValue("@id", id);

                await command.ExecuteNonQueryAsync().ConfigureAwait(false);
            }
        }

        public static string getNameOfTypeOfBusiness(int type)
        {
            switch (type)
            {
                case 1:
                    return "Concesionario";
            }
            return "";
        }
    }
}
