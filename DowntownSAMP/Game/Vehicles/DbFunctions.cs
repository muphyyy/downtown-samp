using MySql.Data.MySqlClient;
using SampSharp.GameMode.Definitions;
using SampSharp.GameMode.World;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;
using System.Threading.Tasks;

namespace DowntownSAMP.Game.Vehicles
{
    public class DbFunctions
    {
        public async static Task SpawnVehicles(BasePlayer owner, int ownerid)
        {
            using (MySqlConnection connection = new MySqlConnection(Data.DbHandler.GetConnectionString()))
            {
                await connection.OpenAsync().ConfigureAwait(false);

                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM vehicles WHERE owner = @owner";
                command.Parameters.AddWithValue("@owner", ownerid);

                DbDataReader reader = await command.ExecuteReaderAsync().ConfigureAwait(false);

                if (reader.HasRows)
                {
                    await reader.ReadAsync().ConfigureAwait(false);
                    {
                        BaseVehicle veh = BaseVehicle.CreateStatic((VehicleModelType)reader.GetInt32(reader.GetOrdinal("model")), new SampSharp.GameMode.Vector3(reader.GetDouble(reader.GetOrdinal("x")), reader.GetDouble(reader.GetOrdinal("y")), reader.GetDouble(reader.GetOrdinal("z"))), (float)reader.GetDouble(reader.GetOrdinal("z")), reader.GetInt32(reader.GetOrdinal("color1")), reader.GetInt32(reader.GetOrdinal("color2")));
                        veh.SetNumberPlate(reader.GetString(reader.GetOrdinal("numberplate")));

                        Data.Classes.Vehicle vehicle = new Data.Classes.Vehicle();
                        vehicle.idDb = reader.GetInt32(reader.GetOrdinal("id"));
                        vehicle.owner = owner;
                        vehicle.veh = veh;
                        Data.Lists.Vehicles.Add(vehicle);
                    }
                }
            }
        }

        public static async Task SaveVehiclePos(int id, double x, double y, double z)
        {
            using (MySqlConnection connection = new MySqlConnection(Data.DbHandler.GetConnectionString()))
            {
                await connection.OpenAsync().ConfigureAwait(false);

                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "UPDATE vehicles SET x = @x, y = @y, z = @z WHERE id = @id LIMIT 1";
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@x", x);
                command.Parameters.AddWithValue("@y", y);
                command.Parameters.AddWithValue("@z", z);

                await command.ExecuteNonQueryAsync().ConfigureAwait(false);
            }
        }
    }
}
