using Game.Objects.Items;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Objects.Actors
{
    public interface IInventory
    {
        public List<Item> ItemList { get; protected set; }
        public void AddItem(Item item);
        public void RemoveItem(Item item);
    }

    public interface IEquipment
    {
        public Dictionary<string, EquipmentItem> Slots { get; protected set; }
        public Dictionary<string, double> EquipmentModifiers { get; }
        public bool TwoHanding { get; protected set; }
        public void EquipItem(EquipmentItem item);
        public void UnequipItem(EquipmentItem item);
        public void ToggleTwoHanding();
    }
}
