﻿using GameCore.Objects.Items;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameCore.Objects.Items.InventoryAndEquipment
{
    public interface IItemManagement
    {
        public void AddItem(Item item);
        public void RemoveItem(Item item);
    }

    public interface IEquipmentManagement
    {
        public void Equip(string slot, EquipmentItem item);
        public void Unequip(string slot);
        public void ToggleTwoHanding();
    }
  
    public class NotInInventoryException : Exception { }
    public class InvalidSlotException : Exception { }
    public class CannotDualWieldException : Exception { }
    public class CannotTwoHandException : Exception { }
}
