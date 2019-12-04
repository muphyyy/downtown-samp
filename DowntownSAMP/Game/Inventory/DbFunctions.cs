using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;
using System.Threading.Tasks;

namespace DowntownSAMP.Game.Inventory
{
    class DbFunctions
    {
        public async static Task<Data.Classes.Inventory> SpawnInventoryItems(int idpj)
        {
            Data.Classes.Inventory inventory = new Data.Classes.Inventory();

            using (MySqlConnection connection = new MySqlConnection(Data.DbHandler.GetConnectionString()))
            {
                await connection.OpenAsync().ConfigureAwait(false);

                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM items WHERE owner = @idpj";
                command.Parameters.AddWithValue("@idpj", idpj);

                DbDataReader reader = await command.ExecuteReaderAsync().ConfigureAwait(false);

                if (reader.HasRows)
                {
                    await reader.ReadAsync().ConfigureAwait(false);
                    {
                        int id = reader.GetInt32(reader.GetOrdinal("id"));
                        string name = reader.GetString(reader.GetOrdinal("name"));
                        int objectid = reader.GetInt32(reader.GetOrdinal("objectid"));
                        int type = reader.GetInt32(reader.GetOrdinal("type"));
                        int peso = reader.GetInt32(reader.GetOrdinal("peso"));
                        int slot = reader.GetInt32(reader.GetOrdinal("slot"));

                        Data.Classes.Item item = new Data.Classes.Item(id, name, objectid, type, peso);

                        switch (slot)
                        {
                            case 1:
                                inventory.slot1 = item;
                                break;

                            case 2:
                                inventory.slot2 = item;
                                break;

                            case 3:
                                inventory.slot3 = item;
                                break;

                            case 4:
                                inventory.slot4 = item;
                                break;

                            case 5:
                                inventory.slot5 = item;
                                break;

                            case 6:
                                inventory.slot6 = item;
                                break;

                            case 7:
                                inventory.slot7 = item;
                                break;

                            case 8:
                                inventory.slot8 = item;
                                break;

                            case 9:
                                inventory.slot9 = item;
                                break;

                            case 10:
                                inventory.slot10 = item;
                                break;

                            case 11:
                                inventory.slot11 = item;
                                break;

                            case 12:
                                inventory.slot12 = item;
                                break;
                        }
                    }
                }
            }

            return inventory;
        }
    }
}
