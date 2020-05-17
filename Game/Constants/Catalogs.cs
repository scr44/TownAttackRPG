using System;
using System.Collections.Generic;
using System.Text;

namespace GameCore.Constants
{
    public static class ItemCatalog
    {
        public static class Consumables
        {
            public const string HealingElixerSmall = "Small Healing Elixir";
        }

        public static class Misc
        {
            public const string Junk = "Junk";
        }
    }

    public static class EquipmentCatalog
    {
        public static class Body
        {
            public const string Naked = "Naked";
            public const string FullPlate = "Full Plate Armor";
        }
        public static class Hands
        {
            public const string BareHand = "Bare Hand";
            public const string TwoHanding = "Two-handing";
            public const string Longsword = "Longsword";
        }
        public static class Charms
        {
            public const string None = "None";
            public const string LoversLocket = "Lover's Locket";
        }
    }
}
