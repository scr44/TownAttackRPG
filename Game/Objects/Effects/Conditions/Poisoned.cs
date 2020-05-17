using GameCore.Objects.Actors;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameCore.Objects.Effects.Conditions
{
    public class Poisoned : Effect
    {
        public Poisoned(Actor target, double? duration, int dmgPerTick) 
            : base(target, duration)
        {
            DmgPerTick = dmgPerTick;
        }

        public double DmgPerTick { get; private set; }
        public const string DmgType = Constants.DmgType.Poison;

        public override void OnTick()
        {
            Target.Damage(DmgPerTick, DmgType);
        }
    }
}
