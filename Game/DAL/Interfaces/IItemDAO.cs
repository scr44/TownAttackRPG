using Game.Objects.Items;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game.DAL.Interfaces
{
    public interface IItemDAO
    {
        public Item CreateItem(string id);
        public EquipmentItem CreateEquipment(string id);
    }
}
