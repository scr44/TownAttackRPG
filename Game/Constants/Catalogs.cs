using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Constants
{
    public static class ItemCatalog
    {
        public static class Consumables
        {
            public static readonly string HealingElixerSmall = "Small Healing Elixir";
        }

        public static class Misc
        {
            public static readonly string Junk = "Junk";
        }
    }

    public static class EquipmentCatalog
    {
        public static class Body
        {
            public static readonly string Naked = "Naked";
            public static readonly string FullPlate = "Full Plate Armor";
        }
        public static class Hands
        {
            public static readonly string BareHand = "Bare Hand";
            public static readonly string TwoHanding = "Two-handing";
            public static readonly string Longsword = "Longsword";
        }
        public static class Charms
        {
            public static readonly string None = "None";
            public static readonly string LoversLocket = "Lover's Locket";
        }
    }
}
