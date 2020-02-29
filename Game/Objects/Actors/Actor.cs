﻿using Game.Constants;
using Game.Objects.Actors.Statistics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Objects.Actors
{
    public abstract class Actor : IHealth, IStamina
    {
        public Actor(string name, string gender, string race)
        {
            Name = name;
            Gender = gender;
            Race = race;
        }

        public string Name { get; protected set; }
        public string Gender { get; protected set; } // TODO: add pronouns for string interpolation
        public string Race { get; protected set; }

        public Dictionary<string, int> StatModifiers { get; set; } = new Dictionary<string, int>()
        {
            { Stat.STR, 0 },
            { Stat.DEX, 0 },
            { Stat.SKL, 0 },
            { Stat.APT, 0 },
            { Stat.FOR, 0 },
            { Stat.CHA, 0 },

            { Stat.Medicine, 0 },
            { Stat.Explosives, 0 },
            { Stat.Veterancy, 0 },
            { Stat.Bestiary, 0 },
            { Stat.Engineering, 0 },
            { Stat.History, 0 },

            
        };

        public Dictionary<string, double> AttackModifiers { get; set; } = new Dictionary<string, double>()
        {
            { DmgType.Slashing, 1 },
            { DmgType.Piercing, 1 },
            { DmgType.Crushing, 1 },
            { DmgType.Fire, 1 },
            { DmgType.Poison, 1 }
        };

        public Dictionary<string, double> DefenseModifiers { get; set; } = new Dictionary<string, double>()
        {
            { DmgType.Slashing, 1 },
            { DmgType.Piercing, 1 },
            { DmgType.Crushing, 1 },
            { DmgType.Fire, 1 },
            { DmgType.Poison, 1 }
        };

        #region Health
        public int HP { get; set; }
        public int MaxHP => BaseHP + StatModifiers[Stat.MaxHP];
        public double PercentHP => Math.Round(((HP / (double)MaxHP * 100)));
        public int BaseHP { get; set; }
        public int BaseHealthRegen { get; set; }
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
        public int MaxSP => BaseSP + StatModifiers[Stat.MaxSP];
        public double PercentSP => Math.Round((SP / (double)MaxSP), 2) * 100;
        public int BaseSP { get; set; }
        public int BaseStaminaRegen { get; set; }
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