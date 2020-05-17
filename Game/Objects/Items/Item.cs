using System.Collections.Generic;

namespace GameCore.Objects.Items
{
    public class Item
    {
        public string IdName { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public int Value { get; set; }
        public double Weight { get; set; }
        public List<string> Tags { get; set; } = new List<string>();
    }
}
