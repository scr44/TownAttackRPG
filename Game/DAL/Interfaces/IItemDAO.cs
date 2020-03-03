using Game.Objects.Items;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game.DAL.Interfaces
{
    public interface IItemDAO
    {
        public Item GetItem(string id);
        public EquipmentItem GetEquipment(string id);
    }

    public class InvalidItemException : Exception { }
    public class InvalidEquipmentItemException : Exception { }
    public class ItemIdAlreadyInUseException : Exception { }
}
