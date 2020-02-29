using Game.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Objects.Items
{
    public class EquipmentItem : Item
    {
        public EquipmentItem(string id) : base(id)
        {
            Attack = ItemDAO.getOffense(id);
            Defense = ItemDAO.getDefense(id);
        }
        Dictionary<string, double> Attack { get; set; }
        Dictionary<string, double> Defense { get; set; }
        double BlockChance { get; set; }
        double Durability { get; set; }
        double MaxDurability { get; set; }

    }
}
