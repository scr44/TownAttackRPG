using Game.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Objects.Items
{
    public class EquipmentItem : Item
    {
        public Dictionary<string, double> AttackMod { get; set; }
        public Dictionary<string, double> DefenseMod { get; set; }
        public double BlockChance { get; set; }
        public double Durability { get; set; }
        public double MaxDurability { get; set; }
    }
}
