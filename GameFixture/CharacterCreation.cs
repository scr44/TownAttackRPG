using Microsoft.VisualStudio.TestTools.UnitTesting;
using Game.Constants;
using Game.Objects.Actors;
using Game.Objects.Professions;

namespace GameFixture
{
    [TestClass]
    public class CharacterCreation
    {
        Character Guinevere { get; set; }
        Character Alric { get; set; }
        Profession knight { get; set; }

        [TestInitialize]
        public void generate_test_characters()
        {
            Guinevere = new Character("Guinevere", Gender.Female, Prof.Knight);
            Alric = new Character("Alric", Gender.Male, Prof.Knight);
            var Knight = new Profession(Prof.Knight);
        }

        [TestMethod]
        public void character_has_correct_description_properties()
        {
            Assert.AreEqual("Alric", Alric.Name);
            Assert.AreEqual(Gender.Male, Alric.Gender);
            Assert.AreEqual(knight.Title, Alric.Profession.Title);
            Assert.AreEqual(knight.Description, Alric.Profession.Description);
            Assert.AreEqual(knight.AltGenderTitle, Alric.Profession.AltGenderTitle);
            Assert.AreEqual(knight.AltGenderDescription, Alric.Profession.AltGenderDescription);

            Assert.AreEqual("Guinevere", Guinevere.Name);
            Assert.AreEqual(Gender.Female, Guinevere.Gender);
            Assert.AreEqual(knight.AltGenderTitle, Guinevere.Profession.Title);
            Assert.AreEqual(knight.AltGenderDescription, Guinevere.Profession.Description);
        }
    }
}
