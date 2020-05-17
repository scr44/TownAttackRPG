using System;
using System.Collections.Generic;
using System.Text;

namespace GameCore.Constants
{
    public static class Effects
    {
        public static class Names
        {
            public const string Poisoned = "Poisoned";
        }

        public static class Buffs
        {
            public const string PercentHealingBonus = "Bonus Healing (Percent)";
            public const string FlatHealingBonus = "Bonus Healing (Flat)";
            public const string PercentDecreaseDamageTaken = "Decrease Damage Taken (Percent)";
        }

        public static class Debuffs
        {
            public const string PercentHealingPenalty = "Healing Penalty (Percent)";
            public const string FlatHealingPenalty = "Healing Penalty (Flat)";
            public const string PercentIncreaseDamageTaken = "Increase Damage Taken (Percent)";
            public const string DamageOverTime = "DoT";
        }
    }
}
