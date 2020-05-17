using GameCore.DAL.Interfaces;
using GameCore.Objects.Effects;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameCore.Objects.Items
{
    public class EquipmentItem : Item
    {
        public List<string> ValidSlots { get; set; }
        public Dictionary<string, int> StatReqs { get; set; }
        public Dictionary<string, double> AttackMod { get; set; }
        public Dictionary<string, double> DefenseMod { get; set; }
        public Dictionary<string, double> CharmMod { get; set; }
        public Dictionary<string, string> Effects { get; set; }
        public double Durability { get; set; }
        public double MaxDurability { get; set; }
    }
}
