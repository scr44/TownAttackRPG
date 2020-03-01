using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Constants
{
    public static class ItemCatalog
    {
        public static readonly string TestItem = "Test Item";

        public static class Consumables
        {

        }

        public static class VendorTrash
        {
            public static readonly string Junk = "Junk";
        }
    }

    public static class EquipmentCatalog
    {
        public static class Body
        {
            public static readonly string Naked = "Naked";
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
        }
    }
}
