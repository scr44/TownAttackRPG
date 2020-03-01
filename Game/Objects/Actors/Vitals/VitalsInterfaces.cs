using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Objects.Actors.VitalsInterfaces
{
    public interface IHealth
    {
        public int HP { get; set; }
        public int HPRegen { get; set; }
        public void AdjustBaseHP(int points);
    }

    public interface IStamina
    {
        public int SP { get; set; }
        public int SPRegen { get; set; }
        public void AdjustBaseSP(int points);
    }

    public interface IDamage
    {
        public int HP { get; set; }
        public int MaxHP { get; }
        public double PercentHP { get; }
        public void AdjustHP(int points);
        public void Damage(double dmgAmt, string dmgType, double dmgAP = 0);
        public void Heal(double healAmt);
        public bool IsAlive { get; set; }
        public void Kill();
        public void Revive(int hp);
    }

    public interface IStaminaUsage
    {
        public int SP { get; set; }
        public int MaxSP { get; }
        public double PercentSP { get; }
        public void AdjustSP(int points);
        public void UseStamina(int points);
        public void RestoreStamina(int points);
    }

    public class NotEnoughHealthException : Exception { }
    public class NotEnoughStaminaException : Exception { }
    public class CannotHealDeadActorException : Exception { }
}
