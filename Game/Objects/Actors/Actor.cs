using Game.Constants;
using Game.Objects.Actors.Statistics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Objects.Actors
{
    abstract class Actor : Health, Stamina
    {
        public Actor() { }

        public string Name { get; private set; }
        public string Gender { get; private set; } // TODO: add pronouns for string interpolation
        public string Race { get; private set; }

        public Dictionary<string,int> Modifiers
        {
            get
            {
                return new Dictionary<string, int>()
                {
                    { Stat.STR, 5 },
                    { Stat.DEX, 5 },
                    { Stat.SKL, 5 },
                    { Stat.APT, 5 },
                    { Stat.FOR, 5 },
                    { Stat.CHA, 5 },

                    { Stat.Medicine, 0 },
                    { Stat.Explosives, 0 },
                    { Stat.Veterancy, 0 },
                    { Stat.Bestiary, 0 },
                    { Stat.Engineering, 0 },
                    { Stat.History, 0 }
                };
            }
        }

        #region Health
        public int HP { get; set; }
        public int MaxHP { get; set; }
        public double PercentHP => Math.Round((((double)HP / MaxHP * 100)));
        public int BaseHP { get; set; }
        public int BaseHPRegen { get; set; }
        public bool IsAlive { get; set; } = true;
        public void AdjustBaseHP(int points)
        {
            throw new NotImplementedException();
        }
        public void AdjustBaseHPRegen(int points)
        {
            throw new NotImplementedException();
        }
        public void AdjustHP(double points)
        {
            throw new NotImplementedException();
        }
        public double Damaged(double dmgAmt, string dmgType, double dmgAP = 0)
        {
            throw new NotImplementedException();
        }
        public double Healed(double healAmt)
        {
            throw new NotImplementedException();
        }
        public void Kill(double points)
        {
            throw new NotImplementedException();
        }
        public void Resurrect(double points)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Stamina
        public int SP { get; set; }
        public int MaxSP { get; }
        public double PercentSP { get; }
        public int BaseSP { get; set; }
        public int BaseSPRegen { get; set; }
        public void AdjustSP(double points)
        {
            throw new NotImplementedException();
        }
        public void AdjustBaseSP(int points)
        {
            throw new NotImplementedException();
        }
        public void AdjustBaseSPRegen(int points)
        {
            throw new NotImplementedException();
        }
        public double UseStamina(double points)
        {
            throw new NotImplementedException();
        }
        public double RestoreStamina(double points)
        {
            throw new NotImplementedException();
        }
        #endregion

        // TODO: Skillbar
        // TODO: Active Effects
        // TODO: RewardDrops (XP, Loot)

    }

}
