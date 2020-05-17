using GameCore.DAL.Interfaces;
using GameCore.DAL.Mocks;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameCore.Objects.Items
{
    public class Item
    {
        public string id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Value { get; set; }
        public double Weight { get; set; }
        public List<string> Tags { get; set; }
    }
}
