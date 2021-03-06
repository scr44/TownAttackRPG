﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GameCore.Objects.Items.InventoryAndEquipment
{
    public class Inventory : IItemManagement
    {
        public List<Item> Items { get; private set; } = new List<Item>();
        public Dictionary<string, int> ItemCounts
        {
            get
            {
                var counts = new Dictionary<string, int>();
                foreach (var item in Items)
                {
                    if(!counts.TryAdd(item.DisplayName, 1))
                    {
                        counts[item.DisplayName]++;
                    }
                }
                return counts;
            }
        }
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
