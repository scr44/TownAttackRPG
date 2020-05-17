using System;
using System.Collections.Generic;
using System.Text;

namespace GameCore.Constants
{
    public static class Tags
    {
        public static class Skill
        {
            public static class Type
            {

            }
        }
        public static class Elements
        {
            public const string Fire = "Fire";
            public const string Poison = "Poison";
        }
        public static class Equipment
        {
            public const string EmptySlot = "Empty Slot";

            public static class Weapons
            {
                public const string Weapon = "Weapon";
                public const string Sword = "Sword";
                public const string Shield = "Shield";
                public const string FreeHand = "Free Hand";
            }

            public static class Armors
            {
                public const string Naked = "Naked";
                public const string Armor = "Armor";
                public const string Heavy = "Heavy";
                public const string Light = "Light";
                public const string Metal = "Metal";
                public const string Padded = "Padded";
                public const string Jewelry = "Jewelry";
            }
        }
        public static class Restrictions
        {
            public const string MustTwoHand = "Must be Two-Handed";
            public const string CannotTwoHand = "Cannot be Two-Handed";
            public const string CannotDualWield = "Cannot be Dual Wielded";
        }
        public static class Races
        {

        }
        public static class Item
        {
            public static class Consumable
            {
                public const string Elixir = "Elixir";
                public const string WeaponOil = "Weapon Oil";
                public const string Bomb = "Bomb";
                public const string Healing = "Healing Item";
            }

            public static class FlavorText
            {
                public const string Relic = "Relic";
                public const string Keepsake = "Keepsake";
                public const string Heirloom = "Heirloom";
            }
        }
    }
}
