using Game.DAL.Interfaces;
using Game.DAL.Mocks;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Objects.Items
{
    public class Item
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Value { get; set; }
        public double Weight { get; set; }
        public List<string> ValidSlots { get; set; }
        public List<string> Tags { get; set; }
    }
}
