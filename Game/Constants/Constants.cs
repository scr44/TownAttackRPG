using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Constants
{
    public static class Gender
    {
        public static readonly string M = "Male";
        public static readonly string F = "Female";
        public static readonly string N = "No Gender";
    }

    public static class Race
    {
        public static readonly string Human = "Human";
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
    }

    public static class Slot
    {
        public static readonly string MainHand = "Main Hand";
        public static readonly string OffHand = "Off Hand";
        public static readonly string Body = "Body";
        public static readonly string Charm1 = "Charm 1";
        public static readonly string Charm2 = "Charm 2";
    }

    public class DmgType
    {
        public static readonly string Slashing = "Slashing";
        public static readonly string Piercing = "Piercing";
        public static readonly string Crushing = "Crushing";
        public static readonly string Fire = "Fire";
        public static readonly string Poison = "Poison";
    }
}
