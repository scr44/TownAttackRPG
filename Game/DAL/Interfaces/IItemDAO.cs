using GameCore.Objects.Items;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameCore.DAL.Interfaces
{
    public interface IItemDAO
    {
        public Item GenerateNewItem(string itemName);
        public EquipmentItem GenerateNewEquipmentItem(string itemName);
    }

    public class InvalidItemException : Exception { }
    public class InvalidEquipmentItemException : Exception { }
    public class ItemIdAlreadyInUseException : Exception { }
}
