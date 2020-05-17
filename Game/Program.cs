using GameCore.Constants;
using GameCore.DAL.Interfaces;
using GameCore.DAL.Json;
using GameCore.Objects.Effects;
using GameCore.Objects.Items;
using GameCore.Objects.Professions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameCore
{
    class Program
    {
        static void Main(string[] args)
        {
            var ItemDAO = new JsonItemDAO();
            var item = new EquipmentItem()
            {
                id = EquipmentCatalog.Hands.TwoHanding,
                Name = EquipmentCatalog.Hands.TwoHanding,
                Description = "This character is using their main weapon with both hands.",
                Value = 0,
                Weight = 0.0,
                MaxDurability = 0.0,
                Durability = 0.0,
                Tags = new List<string>() 
                {

                },
                ValidSlots = new List<string>()
                {
                    Slot.OffHand
                },
                StatReqs = new Dictionary<string, int>()
                {
                    
                },
                AttackMod = new Dictionary<string, double>()
                {

                },
                DefenseMod = new Dictionary<string, double>()
                {
                    
                },
                CharmMod = new Dictionary<string, double>()
                {
                    
                },
                Effects = new Dictionary<string, string>()
                {

                }
            };
            ItemDAO.AddOrUpdateEquipment(item);
        }
    }
}
