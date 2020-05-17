using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using GameCore.Constants;
using GameCore.DAL.Interfaces;
using GameCore.Objects.Items;
using Newtonsoft.Json;

namespace GameCore.DAL.SQLite
{
    public class SQLiteDAO : IItemDAO
    {
        string _dataSource;
        string _connectionString;

        public SQLiteDAO(string dataSource = @"../../../../Game/DAL/SQLite/gameData.db")
        {
            _dataSource = dataSource;
            _connectionString = new SQLiteConnectionStringBuilder { DataSource = _dataSource, Version = 3 }.ToString();
        }

        public Item GenerateNewItem(string itemName)
        {
            Item item;

            using (SQLiteConnection conn = new SQLiteConnection(_connectionString))
            {
                conn.Open();
                item = GetItemStats(itemName, conn);
                item.Tags = GetItemTags(itemName, conn);
            }
            if (item.IdName == null)
            {
                throw new InvalidItemException();
            }
            return item;
        }

        public EquipmentItem GenerateNewEquipmentItem(string itemName)
        {
            EquipmentItem equipmentItem = new EquipmentItem(GenerateNewItem(itemName));
            using (SQLiteConnection conn = new SQLiteConnection(_connectionString))
            {
                conn.Open();
                equipmentItem.ValidSlots = GetValidSlots(itemName, conn);
                equipmentItem.StatReqs = GetStatReqs(itemName, conn);
                equipmentItem.AttackMod = GetAtkMod(itemName, conn);
                equipmentItem.DefenseMod = GetDefMod(itemName, conn);
                equipmentItem.BonusStatMod = GetBonusStats(itemName, conn);
                equipmentItem.MaxDurability = GetMaxDurability(itemName, conn);
                equipmentItem.Durability = equipmentItem.MaxDurability;
            }
            return equipmentItem;
        }

        private Item GetItemStats(string itemName, SQLiteConnection conn)
        {
            Item item = new Item();
            string query = @"SELECT * FROM item i WHERE i.id_name = $itemName";
            using (var cmd = new SQLiteCommand { Connection = conn, CommandText = query })
            {
                cmd.Parameters.AddWithValue("$itemName", itemName);
                var queryResults = cmd.ExecuteReader();
                queryResults.Read();
                try
                {
                    item = new Item
                    {
                        IdName = queryResults[1].ToString(),
                        DisplayName = queryResults[2].ToString(),
                        Description = queryResults[3].ToString(),
                        Value = Convert.ToInt32(queryResults[4]),
                        Weight = Convert.ToDouble(queryResults[5])
                    };
                }
                catch (InvalidOperationException)
                {
                    throw new InvalidItemException();
                }
            }
            return item;
        }

        private List<string> GetItemTags(string itemName, SQLiteConnection conn)
        {
            var query = @"SELECT t.name
                                FROM tags t
                                LEFT JOIN item_tags it on t.id = it.tag_id
                                LEFT JOIN item i on i.id = it.item_id
                                WHERE i.id_name = $itemName
                                ORDER BY t.name ASC";
            var tagsList = new List<string>();
            using (var cmd = new SQLiteCommand { Connection = conn, CommandText = query })
            {
                cmd.Parameters.AddWithValue("$itemName", itemName);
                var queryResults = cmd.ExecuteReader();
                while (queryResults.Read())
                {
                    var tag = queryResults[0].ToString();
                    if (!String.IsNullOrEmpty(tag))
                    {
                        tagsList.Add(tag);
                    }
                }
            }

            return tagsList;
        }

        private List<string> GetValidSlots(string itemName, SQLiteConnection conn)
        {
            var query = @"SELECT s.name
                        FROM slots s
                        JOIN valid_slots vs on vs.slot_id = s.id
                        JOIN item i on i.id = vs.item_id
                        WHERE i.id_name = $itemName";
            var validSlotList = new List<string>();

            using (var cmd = new SQLiteCommand { Connection = conn, CommandText = query })
            {
                cmd.Parameters.AddWithValue("$itemName", itemName);
                var queryResults = cmd.ExecuteReader();
                if (!queryResults.HasRows)
                {
                    throw new InvalidEquipmentItemException();
                }
                while (queryResults.Read())
                {
                    var slot = queryResults[0].ToString();
                    if (!String.IsNullOrEmpty(slot))
                    {
                        validSlotList.Add(slot);
                    }
                }
            }
            return validSlotList;
        }

        private Dictionary<string, int> GetStatReqs(string itemName, SQLiteConnection conn)
        {
            string query = @"SELECT *
                            FROM equipment_stats e
                            JOIN item i on i.id = e.item_id
                            WHERE i.id_name = $itemName";
            var statReqs = new Dictionary<string, int>();
            using (var cmd = new SQLiteCommand { Connection = conn, CommandText = query })
            {
                cmd.Parameters.AddWithValue("$itemName", itemName);
                var stats = cmd.ExecuteReader();
                stats.Read();
                statReqs.Add(Att.STR, (stats["req_str"] is DBNull) ? -1 : Convert.ToInt32(stats["req_str"]));
                statReqs.Add(Att.DEX, (stats["req_dex"] is DBNull) ? -1 : Convert.ToInt32(stats["req_dex"]));
                statReqs.Add(Att.SKL, (stats["req_skl"] is DBNull) ? -1 : Convert.ToInt32(stats["req_skl"]));
                statReqs.Add(Att.APT, (stats["req_apt"] is DBNull) ? -1 : Convert.ToInt32(stats["req_apt"]));
                statReqs.Add(Att.FOR, (stats["req_for"] is DBNull) ? -1 : Convert.ToInt32(stats["req_for"]));
                statReqs.Add(Att.CHA, (stats["req_cha"] is DBNull) ? -1 : Convert.ToInt32(stats["req_cha"]));
            }
            foreach (var kvp in statReqs)
            {
                if (kvp.Value == -1)
                {
                    statReqs.Remove(kvp.Key);
                }
            }
            return statReqs;
        }

        private Dictionary<string, double> GetAtkMod(string itemName, SQLiteConnection conn)
        {
            var query = @"SELECT *
                            FROM equipment_stats e
                            JOIN item i on i.id = e.item_id
                            WHERE i.id_name = $itemName";
            var atkMods = new Dictionary<string, double>();
            using (var cmd = new SQLiteCommand { Connection = conn, CommandText = query })
            {
                cmd.Parameters.AddWithValue("$itemName", itemName);
                var stats = cmd.ExecuteReader();
                stats.Read();
                atkMods.Add(ATKMod.Slashing, (stats["atk_slash"] is DBNull) ? -1 : Convert.ToDouble(stats["atk_slash"]));
                atkMods.Add(ATKMod.Piercing, (stats["atk_pierce"] is DBNull) ? -1 : Convert.ToDouble(stats["atk_pierce"]));
                atkMods.Add(ATKMod.Crushing, (stats["atk_crush"] is DBNull) ? -1 : Convert.ToDouble(stats["atk_crush"]));
                atkMods.Add(ATKMod.Fire, (stats["atk_fire"] is DBNull) ? -1 : Convert.ToDouble(stats["atk_fire"]));
                atkMods.Add(ATKMod.Poison, (stats["atk_poison"] is DBNull) ? -1 : Convert.ToDouble(stats["atk_poison"]));
            }
            foreach (var kvp in atkMods)
            {
                if (kvp.Value == -1)
                {
                    atkMods.Remove(kvp.Key);
                }
            }
            return atkMods;
        }
    
        private Dictionary<string, double> GetDefMod(string itemName, SQLiteConnection conn)
        {
            var query = @"SELECT *
                        FROM equipment_stats e
                        JOIN item i on i.id = e.item_id
                        WHERE i.id_name = $itemName";
            var defMods = new Dictionary<string, double>();
            using (var cmd = new SQLiteCommand { Connection = conn, CommandText = query })
            {
                cmd.Parameters.AddWithValue("$itemName", itemName);
                var stats = cmd.ExecuteReader();
                stats.Read();
                defMods.Add(DEFMod.Slashing, (stats["def_slash"] is DBNull) ? -1 : Convert.ToDouble(stats["def_slash"]));
                defMods.Add(DEFMod.Piercing, (stats["def_pierce"] is DBNull) ? -1 : Convert.ToDouble(stats["def_pierce"]));
                defMods.Add(DEFMod.Crushing, (stats["def_crush"] is DBNull) ? -1 : Convert.ToDouble(stats["def_crush"]));
                defMods.Add(DEFMod.Fire, (stats["def_fire"] is DBNull) ? -1 : Convert.ToDouble(stats["def_fire"]));
                defMods.Add(DEFMod.Poison, (stats["def_poison"] is DBNull) ? -1 : Convert.ToDouble(stats["def_poison"]));
            }

            foreach (var kvp in defMods)
            {
                if (kvp.Value == -1)
                {
                    defMods.Remove(kvp.Key);
                }
            }

            return defMods;
        }
    
        private Dictionary<string, double> GetBonusStats(string itemName, SQLiteConnection conn)
        {
            var query = @"SELECT e.bns_stat_json
                        FROM equipment_stats e
                        JOIN item i on i.id = e.item_id
                        WHERE i.id_name = $itemName";
            var bonusStats = new Dictionary<string, double>();

            using (var cmd = new SQLiteCommand { Connection = conn, CommandText = query })
            {
                cmd.Parameters.AddWithValue("$itemName", itemName);
                var result = cmd.ExecuteReader();
                result.Read();
                var json = result[0].ToString();
                bonusStats = (Dictionary<string, double>)JsonConvert.DeserializeObject(json);
            }

            return bonusStats;
        }
    
        private double? GetMaxDurability(string itemName, SQLiteConnection conn)
        {
            var query = @"SELECT max_durability
                        FROM equipment_stats e
                        JOIN item i on i.id = e.item_id
                        WHERE i.id_name = $itemName";

            using (var cmd = new SQLiteCommand { Connection = conn, CommandText = query })
            {
                cmd.Parameters.AddWithValue("$itemName", itemName);
                var result = cmd.ExecuteReader();
                result.Read();
                if (!result.HasRows)
                {
                    throw new InvalidEquipmentItemException();
                }
                if (result[0] is DBNull)
                {
                    return null;
                }
                else
                {
                    return Convert.ToDouble(result[0]);
                }
            }
        }
    }
}
