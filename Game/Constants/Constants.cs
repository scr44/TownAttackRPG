using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Constants
{
    public static class Gender
    {
        public static readonly string Male = "Male";
        public static readonly string Female = "Female";
        public static readonly string NoGender = "No Gender";
    }

    public static class Race
    {
        public static readonly string Human = "Human";
    }

    public static class Prof
    {
        public static readonly string Knight = "Knight";
    }

    public static class Stat
    {
        public static readonly string STR = "STR";
        public static readonly string DEX = "DEX";
        public static readonly string SKL = "SKL";
        public static readonly string APT = "APT";
        public static readonly string FOR = "FOR";
        public static readonly string CHA = "CHA";

        public static readonly string Medicine = "Medicine";
        public static readonly string Explosives = "Explosives";
        public static readonly string Veterancy = "Veterancy";
        public static readonly string Bestiary = "Bestiary";
        public static readonly string Engineering = "Engineering";
        public static readonly string History = "History";

        public static readonly string MaxHP = "Max HP";
        public static readonly string MaxSP = "Max SP";
    }

    public static class BaseStat
    {
        public static readonly string HP = "Base HP";
        public static readonly string SP = "Base SP";
        public static readonly string HPRegen = "Base HP Regen";
        public static readonly string SPRegen = "Base SP Regen";
    }

    public static class Slot
    {
        public static readonly string Body = "Body";
        public static readonly string MainHand = "Main Hand";
        public static readonly string OffHand = "Off Hand";
        public static readonly string Charm1 = "Charm 1";
        public static readonly string Charm2 = "Charm 2";
    }

    public static class DmgType
    {
        public static readonly string Slashing = "Slashing";
        public static readonly string Piercing = "Piercing";
        public static readonly string Crushing = "Crushing";
        public static readonly string Fire = "Fire";
        public static readonly string Poison = "Poison";
    }

    public static class ItemNames
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

    public static class EquipmentNames
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
