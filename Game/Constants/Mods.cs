using System;
using System.Collections.Generic;
using System.Text;

namespace GameCore.Constants
{
    public static class Att
    {
        public const string STR = "STR";
        public const string DEX = "DEX";
        public const string SKL = "SKL";
        public const string APT = "APT";
        public const string FOR = "FOR";
        public const string CHA = "CHA";
    }

    public static class Tal
    {
        public const string Medicine = "Medicine";
        public const string Explosives = "Explosives";
        public const string Veterancy = "Veterancy";
        public const string Bestiary = "Bestiary";
        public const string Engineering = "Engineering";
        public const string History = "History";
    }

    public static class DmgType
    {
        public const string Slashing = "Slashing";
        public const string Piercing = "Piercing";
        public const string Crushing = "Crushing";
        public const string Fire = "Fire";
        public const string Poison = "Poison";
    }

    public static class ATKMod
    {
        public const string Slashing = "SlashingATK";
        public const string Piercing = "PiercingATK";
        public const string Crushing = "CrushingATK";
        public const string Fire = "FireATK";
        public const string Poison = "PoisonATK";
    }

    public static class DEFMod
    {
        public const string Slashing = "SlashingDEF";
        public const string Piercing = "PiercingDEF";
        public const string Crushing = "CrushingDEF";
        public const string Fire = "FireDEF";
        public const string Poison = "PoisonDEF";
    }

    public static class MiscMods
    {
        public const string BlockChance = "Block Chance";
    }
}
