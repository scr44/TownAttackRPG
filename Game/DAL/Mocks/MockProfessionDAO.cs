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
        public Profession GetProfession(string title)
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
                StartingVitals = new Dictionary<string, int>()
                {
                    { Vitals.HP, 10 },
                    { Vitals.SP, 10 },
                    { Vitals.HPRegen, 0 },
                    { Vitals.SPRegen, 5 }
                },
                StartingInventory = new Dictionary<string, int>()
                {
                    { ItemCatalog.Misc.Junk, 2 }
                },
                StartingEquipment = new Dictionary<string, string>()
                {
                    { Slot.Body, EquipmentCatalog.Body.Naked },
                    { Slot.MainHand, EquipmentCatalog.Hands.Longsword },
                    { Slot.OffHand, EquipmentCatalog.Hands.BareHand },
                    { Slot.Charm1, EquipmentCatalog.Charms.None },
                    { Slot.Charm2, EquipmentCatalog.Charms.None }
                },
                StartingSkills = new Dictionary<int, string>()
                {

                }
            };
        }
    }
}
