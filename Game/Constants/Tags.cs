using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Constants
{
    public static class Tags
    {
        public static class Skills
        {

        }

        public static class Elements
        {
            public static readonly string Fire = "Fire";
            public static readonly string Poison = "Poison";
        }

        public static class Equipment
        {
            public static readonly string Weapon = "Weapon";
            public static class Weapons
            {
                public static readonly string Sword = "Sword";
                public static readonly string Shield = "Shield";
            }

            public static readonly string Armor = "Armor";
            public static class Armors
            {
                public static readonly string Heavy = "Heavy";
                public static readonly string Light = "Light";
            }
        }

        public static class ValidSlots
        {
            public static readonly string Body = "Body";
            public static readonly string MainHand = "Main Hand";
            public static readonly string OffHand = "Off Hand";
            public static readonly string Charm = "Charm";
            public static readonly string MustTwoHand = "Must be Two-Handed";
            public static readonly string CannotTwoHand = "Cannot be Two-Handed";
            public static readonly string CannotDualWield = "Cannot be Dual Wielded";
        }

        public static class Races
        {

        }
    }
}
