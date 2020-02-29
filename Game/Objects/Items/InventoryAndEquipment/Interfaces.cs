using Game.Objects.Items;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Objects.Items.InventoryAndEquipment
{
    public interface IMoveItems
    {
        public void AddItem(Item item);
        public void RemoveItem(Item item);
    }

    public interface IChangeEquipment
    {
        public void EquipItem(string slot, EquipmentItem item);
        public void UnequipItem(string slot);
        public void ToggleTwoHanding();
    }
}
