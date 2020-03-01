using Game.Constants;
using Game.DAL.Interfaces;
using Game.Objects.Items;
using Game.Objects.Professions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Constants.Slot.MainHand);
            var prof = new Objects.Professions.Profession()
            {
                DefaultGender = Constants.Gender.Male,
                Title = Constants.Prof.Knight,
                Description = "A sturdy knight in plate armor.",
                AltGenderTitle = "Female Knight",
                AltGenderDescription = "A female knight in plate armor.",
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
                    { Tal.Medicine, 0 },
                    { Tal.Explosives, 0 },
                    { Tal.Veterancy, 0 },
                    { Tal.Bestiary, 0 },
                    { Tal.Engineering, 0 },
                    { Tal.History, 0 }
                },
                StartingVitals = new Dictionary<string, double>()
                {
                    { Vitals.HP, 10 },
                    { Vitals.SP, 10 },
                    { Vitals.HPRegen, 0 },
                    { Vitals.SPRegen, 5 }
                },
                StartingInventory = new Dictionary<string, int>()
                {
                    { ItemNames.VendorTrash.Junk, 2 }
                },
                StartingEquipment = new Dictionary<string, string>()
                {
                    { Slot.Body, EquipmentNames.Body.Naked },
                    { Slot.MainHand, EquipmentNames.Hands.Longsword },
                    { Slot.OffHand, EquipmentNames.Hands.BareHand },
                    { Slot.Charm1, EquipmentNames.Charms.None },
                    { Slot.Charm2, EquipmentNames.Charms.None }
                },
                StartingSkills = new Dictionary<int, string>()
                {

                }
            };
        }
    }
}
