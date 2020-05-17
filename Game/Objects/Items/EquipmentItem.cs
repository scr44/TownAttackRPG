using System.Collections.Generic;

namespace GameCore.Objects.Items
{
    public class EquipmentItem : Item
    {
        public EquipmentItem() {}
        public EquipmentItem(Item baseItem)
        {
            IdName = baseItem.IdName;
            DisplayName = baseItem.DisplayName;
            Description = baseItem.Description;
            Value = baseItem.Value;
            Weight = baseItem.Weight;
            Tags = baseItem.Tags;
        }

        public List<string> ValidSlots { get; set; } = new List<string>();
        public Dictionary<string, int> StatReqs { get; set; } = new Dictionary<string, int>();
        public Dictionary<string, double> AttackMod { get; set; } = new Dictionary<string, double>();
        public Dictionary<string, double> DefenseMod { get; set; } = new Dictionary<string, double>();
        public Dictionary<string, double> BonusStatMod { get; set; } = new Dictionary<string, double>();
        public Dictionary<string, string> Effects { get; set; } = new Dictionary<string, string>();
        public double? Durability { get; set; }
        public double? MaxDurability { get; set; }
    }
}
