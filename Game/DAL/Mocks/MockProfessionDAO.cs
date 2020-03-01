using Game.Constants;
using Game.DAL.Interfaces;
using Game.Objects.Items;
using Game.Objects.Professions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game.DAL.Mocks
{
    public class MockProfessionDAO : IProfessionDAO
    {
        public Profession GetProfessionStats(string title)
        {
            return new Profession()
            {
                DefaultGender = Gender.Male,
                Title = "Title",
                Description = "Description",
                AltGenderTitle = "AltTitle",
                AltGenderDescription = "AltDescription",
                StartingAttributes = new Dictionary<string, int>()
                {
                    { Stat.STR, 5 },
                    { Stat.DEX, 5 },
                    { Stat.SKL, 5 },
                    { Stat.APT, 5 },
                    { Stat.FOR, 5 },
                    { Stat.CHA, 5 }
                },
                StartingTalents = new Dictionary<string, int>()
                {
                    { Stat.Medicine, 0 },
                    { Stat.Explosives, 0 },
                    { Stat.Veterancy, 0 },
                    { Stat.Bestiary, 0 },
                    { Stat.Engineering, 0 },
                    { Stat.History, 0 }
                },
                StartingHealthAndStamina = new Dictionary<string, double>()
                {
                    { BaseStat.HP, 10 },
                    { BaseStat.SP, 10 },
                    { BaseStat.HPRegen, 0 },
                    { BaseStat.SPRegen, 5 }
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
