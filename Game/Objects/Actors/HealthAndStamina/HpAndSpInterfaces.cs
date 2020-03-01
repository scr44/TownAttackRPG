using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Objects.Actors.Statistics
{
    public interface IHealth
    {
        public int HP { get; set; }
        public int MaxHP { get; }
        public double PercentHP { get; }
        public int BaseHP { get; set; }
        public int BaseHealthRegen { get; set; }
        public bool IsAlive { get; set; }
        public void AdjustHP(double points);
        public void Kill(double points);
        public void Resurrect(double points);
        public void AdjustBaseHP(int points);
        public void AdjustBaseHPRegen(int points);
        public double Damaged(double dmgAmt, string dmgType, double dmgAP = 0);
        public double Healed(double healAmt);
    }

    public interface IStamina
    {
        public int SP { get; set; }
        public int MaxSP { get; }
        public double PercentSP { get; }
        public int BaseSP { get; set; }
        public int BaseStaminaRegen { get; set; }
        public void AdjustSP(double points);
        public void AdjustBaseSP(int points);
        public void AdjustBaseSPRegen(int points);
        public double UseStamina(double points);
        public double RestoreStamina(double points);
    }
}
