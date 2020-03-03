using Game.Constants;
using Game.DAL.Interfaces;
using Game.DAL.Json;
using Game.Objects.Items;
using Game.Objects.Professions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game
{
    class Program
    {
        static void Main(string[] args)
        {
            var ProfDAO = new JsonProfessionDAO();
            var prof = new Profession()
            {
                id = Prof.Knight,
                Title = "Hedge Knight",
                DefaultGender = "Male",
                Description = "A sturdy knight in plate armor.",
                AltGenderTitle = "Noble's Daughter",
                AltGenderDescription = "The daughter of a noble, who preferred swords to knitting needles.",
                StartingAttributes = new Dictionary<string, int>()
                {
                    { Att.STR, 5 },
                    { Att.DEX, 5 },
                    { Att.SKL, 5 },
                    { Att.APT, 5 },
                    { Att.FOR, 5 },
                    { Att.CHA, 5 }
                },
                StartingTalents = new Dictionary<string, int>()
                {
                    { Tal.Veterancy, 1 }
                },
                StartingVitals = new Dictionary<string, int>()
                {
                    { Vitals.HP, 10 },
                    { Vitals.SP, 10 },
                    { Vitals.HPRegen, 0 },
                    { Vitals.SPRegen, 5 }
                },
                StartingInventory = new Dictionary<string, int>()
                {
                    { ItemCatalog.Consumables.HealingElixerSmall, 3 }
                },
                StartingEquipment = new Dictionary<string, string>()
                {
                    { Slot.Body, EquipmentCatalog.Body.FullPlate },
                    { Slot.MainHand, EquipmentCatalog.Hands.Longsword },
                    { Slot.OffHand, EquipmentCatalog.Hands.TwoHanding },
                    { Slot.Charm1, EquipmentCatalog.Charms.LoversLocket },
                    { Slot.Charm2, EquipmentCatalog.Charms.None }
                },
                StartingSkills = new Dictionary<int, string>()
                {

                }
            };
            ProfDAO.AddOrUpdateProfession(prof);
        }
    }
}
