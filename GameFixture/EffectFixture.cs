using GameCore.Constants;
using GameCore.Objects.Actors;
using GameCore.Objects.Effects;
using GameCore.Objects.Effects.Conditions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace EffectFixture
{
    [TestClass]
    public class EffectManagement
    {
        private Character Guinevere { get; set; }

        [TestInitialize]
        public void Create_character_without_active_effects()
        {
            Guinevere = new Character("Guinevere", Gender.Female, Prof.Knight);
        }

        [TestMethod]
        public void Apply_effect_to_character()
        {

        }

        [TestMethod]
        public void Tick_effect_on_character()
        {

        }

        [TestMethod]
        public void Remove_effect_from_character()
        {

        }

        [TestMethod]
        public void Expire_effect()
        {

        }
    }

    [TestClass]
    public class DamageOverTime
    {
        private Character Guinevere { get; set; }

        [TestInitialize]
        public void Create_poisoned_character()
        {
            Guinevere = new Character("Guinevere", Gender.Female, Prof.Knight);
            Guinevere.ApplyEffect(new Poisoned(Guinevere, 3, 5));
        }
    }
}
