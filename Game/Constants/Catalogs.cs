using System;
using System.Collections.Generic;
using System.Text;

namespace GameCore.Constants
{
    public static class ItemCatalog
    {
        public static class Consumables
        {
            public const string HealingElixerSmall = "small_healing_elixir";
        }

        public static class Misc
        {
            public const string Junk = "junk";
        }
    }

    public static class EquipmentCatalog
    {
        public static class Body
        {
            public const string Naked = "naked";
            public const string FullPlate = "full_plate_knight";
        }
        public static class Hands
        {
            public const string BareHand = "bare_hand";
            public const string TwoHanding = "two_handing";
            public const string Longsword = "longsword_basic";
        }
        public static class Charms
        {
            public const string None = "none";
            public const string LoversLocket = "lovers_locket";
        }
    }
}
