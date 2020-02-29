using Microsoft.VisualStudio.TestTools.UnitTesting;
using Game.Constants;
using Game.Objects.Actors;
using Game.Objects.Professions;

namespace Characters
{
    [TestClass]
    public class CharacterFixture
    {
        Character Guinevere { get; set; }
        Character Alric { get; set; }
        Profession Knight { get; set; }

        [TestInitialize]
        public void generate_test_characters()
        {
            Guinevere = new Character("Guinevere", Gender.Female, Race.Human, Prof.Knight);
            Alric = new Character("Alric", Gender.Male, Race.Human, Prof.Knight);
            Knight = new Profession(Prof.Knight);
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
            Guinevere.
        }
        [TestMethod]
        public void Character_has_starting_equipment()
        {

        }
    }
}
