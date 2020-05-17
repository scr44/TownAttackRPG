using GameCore.Constants;
using GameCore.Objects.Actors;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace CharacterFixture
{
    [TestClass]
    public class EquipmentModifiers
    {
        protected Character Guinevere { get; set; }

        [TestInitialize]
        public void Create_character()
        {
            Guinevere = new Character("Guinevere", Gender.Female, Prof.Knight);
        }

        [TestMethod]
        public void Non_active_stat_returns_zero_modifier()
        {
            var fakeStatMod = Guinevere.Modifier("Fake Stat");
            Assert.AreEqual(0, fakeStatMod);
        }

        [TestMethod]
        public void Weapon_grants_atk_mod()
        {
            Guinevere.Unequip(Slot.Body);
            Guinevere.Unequip(Slot.Charm1);
            Guinevere.Unequip(Slot.Charm2);

            var slash = Guinevere.Modifier(ATKMod.Slashing);
            var pierce = Guinevere.Modifier(ATKMod.Piercing);
            var crush = Guinevere.Modifier(ATKMod.Crushing);
            var poison = Guinevere.Modifier(ATKMod.Poison);
            var fire = Guinevere.Modifier(ATKMod.Fire);
            Assert.IsTrue(slash > 0);
            Assert.IsTrue(pierce > 0);
            Assert.IsTrue(crush > 0);
            Assert.IsTrue(poison == 1);
            Assert.IsTrue(fire == 1);
        }

        [TestMethod]
        public void Armor_grants_def_mod()
        {
            Guinevere.Unequip(Slot.MainHand);
            Guinevere.Unequip(Slot.OffHand);
            Guinevere.Unequip(Slot.Charm1);
            Guinevere.Unequip(Slot.Charm2);

            var slash = Guinevere.Modifier(DEFMod.Slashing);
            var pierce = Guinevere.Modifier(DEFMod.Piercing);
            var crush = Guinevere.Modifier(DEFMod.Crushing);
            var poison = Guinevere.Modifier(DEFMod.Poison);
            var fire = Guinevere.Modifier(DEFMod.Fire);
            Assert.IsTrue(slash < 1);
            Assert.IsTrue(pierce < 1);
            Assert.IsTrue(crush < 1);
            Assert.IsTrue(poison == 1);
            Assert.IsTrue(fire == 1);
        }

        [TestMethod]
        public void Charm_grants_stat_mod()
        {
            var strBase = Guinevere.BaseAttributes.Base[Att.STR];
            var strMod = Guinevere.Modifier(Att.STR);
            var strEffective = Guinevere.Attributes[Att.STR];

            Assert.IsTrue(strMod > 0);
            Assert.AreEqual(strBase + strMod, strEffective);

            Guinevere.UnequipAll();

            strBase = Guinevere.BaseAttributes.Base[Att.STR];
            strMod = Guinevere.Modifier(Att.STR);
            strEffective = Guinevere.Attributes[Att.STR];

            Assert.AreEqual(0, strMod);
            Assert.AreEqual(strBase, strEffective);
        }
    }
}
