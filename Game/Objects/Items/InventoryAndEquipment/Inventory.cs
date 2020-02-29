using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Objects.Items.InventoryAndEquipment
{
    public class Inventory : IMoveItems
    {
        public List<Item> Items { get; private set; }
        public int Coins { get; private set; }

        public void SortInventory(string sortMethod)
        {
            throw new NotImplementedException();
        }

        public void AddItem(Item item)
        {
            Items.Add(item);
        }
        public void RemoveItem(Item item)
        {
            Items.Remove(item);
        }
    }
}
