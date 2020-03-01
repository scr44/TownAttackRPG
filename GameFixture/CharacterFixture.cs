using Microsoft.VisualStudio.TestTools.UnitTesting;
using Game.Constants;
using Game.Objects.Actors;
using Game.Objects.Professions;
using Game.DAL.Interfaces;
using Game.DAL.Mocks;

namespace Fixtures
{
    [TestClass]
    public class CharacterFixture
    {
        IProfessionDAO ProfessionDAO { get; set; } = new MockProfessionDAO();
        Character Guinevere { get; set; }
        Character Alric { get; set; }
        Profession Knight { get; set; }

        [TestInitialize]
        public void generate_test_characters()
        {
            Guinevere = new Character("Guinevere", Gender.Female, Prof.Knight);
            Alric = new Character("Alric", Gender.Male, Prof.Knight);
            Knight = ProfessionDAO.GetProfessionStats(Prof.Knight);
        }

        [TestMethod]
        public void Character_has_correct_description_properties()
        {
            Assert.AreEqual("Alric", Alric.Name);
            Assert.AreEqual(Gender.Male, Alric.Gender);
            Assert.AreEqual(Race.Human, Alric.Race);
            Assert.AreEqual(Knight.Title, Alric.Profession.Title);
            Assert.AreEqual(Knight.Description, Alric.Profession.Description);
            Assert.AreEqual(Knight.AltGenderTitle, Alric.Profession.AltGenderTitle);
            Assert.AreEqual(Knight.AltGenderDescription, Alric.Profession.AltGenderDescription);

            Assert.AreEqual("Guinevere", Guinevere.Name);
            Assert.AreEqual(Gender.Female, Guinevere.Gender);
            Assert.AreEqual(Race.Human, Guinevere.Race);
            Assert.AreEqual(Knight.AltGenderTitle, Guinevere.Profession.Title);
            Assert.AreEqual(Knight.AltGenderDescription, Guinevere.Profession.Description);
            Assert.AreEqual(Knight.Title, Guinevere.Profession.AltGenderTitle);
            Assert.AreEqual(Knight.Description, Guinevere.Profession.AltGenderDescription);
        }
        [TestMethod]
        public void Character_has_correct_starting_stats()
        {
            Assert.AreEqual(Knight.StartingAttributes, Guinevere.BaseAttributes.Base);
            Assert.AreEqual(Knight.StartingTalents, Guinevere.BaseTalents.Base);
            Assert.AreEqual(Knight.StartingHealthAndStamina[BaseStat.HP], Guinevere.HP);
            Assert.AreEqual(Knight.StartingHealthAndStamina[BaseStat.SP], Guinevere.SP);
            Assert.AreEqual(Knight.StartingHealthAndStamina[BaseStat.HPRegen], Guinevere.BaseHealthRegen);
            Assert.AreEqual(Knight.StartingHealthAndStamina[BaseStat.SPRegen], Guinevere.BaseStaminaRegen);
        }
        [TestMethod]
        public void Character_has_starting_items()
        {
            Assert.AreEqual(Knight.StartingInventory.Count, Guinevere.Inventory.ItemCounts.Count);
            foreach (var kvp in Knight.StartingInventory)
            {
                Assert.AreEqual(kvp.Value, Guinevere.Inventory.ItemCounts[kvp.Key]);
            }
        }
        [TestMethod]
        public void Character_has_starting_equipment()
        {
            foreach (var kvp in Guinevere.EquipmentSlots)
            {
                Assert.AreEqual(Knight.StartingEquipment[kvp.Key], Guinevere.EquipmentSlots[kvp.Key].Name);
            }
        }
    }
}