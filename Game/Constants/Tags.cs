using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Constants
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
            public static readonly string Fire = "Fire";
            public static readonly string Poison = "Poison";
        }
        public static class Equipment
        {
            public static class Weapons
            {
                public static readonly string Weapon = "Weapon";
                public static readonly string Sword = "Sword";
                public static readonly string Shield = "Shield";
                public static readonly string Unarmed = "Unarmed";
            }

            public static class Armors
            {
                public static readonly string Naked = "Naked";
                public static readonly string Armor = "Armor";
                public static readonly string Heavy = "Heavy";
                public static readonly string Light = "Light";
                public static readonly string Metal = "Metal";
                public static readonly string Padded = "Padded";
                public static readonly string Jewelry = "Jewelry";
            }
        }
        public static class ValidSlots
        {
            public static readonly string Body = "Body";
            public static readonly string MainHand = "Main Hand";
            public static readonly string OffHand = "Off Hand";
            public static readonly string Charm = "Charm";
        }
        public static class Restrictions
        {
            public static readonly string MustTwoHand = "Must be Two-Handed";
            public static readonly string CannotTwoHand = "Cannot be Two-Handed";
            public static readonly string CannotDualWield = "Cannot be Dual Wielded";
        }
        public static class Races
        {

        }
        public static class Item
        {
            public static class Consumable
            {
                public static readonly string Elixir = "Elixir";
                public static readonly string WeaponOil = "Weapon Oil";
                public static readonly string Bomb = "Bomb";
                public static readonly string Healing = "Healing Item";
            }

            public static class FlavorText
            {
                public static readonly string Relic = "Relic";
                public static readonly string Keepsake = "Keepsake";
                public static readonly string Heirloom = "Heirloom";
            }
        }
    }
}
