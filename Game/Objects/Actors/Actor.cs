using Game.Constants;
using Game.DAL.Interfaces;
using Game.DAL.Json;
using Game.Objects.Actors.VitalsClasses;
using Game.Objects.Actors.VitalsInterfaces;
using Game.Objects.Items.InventoryAndEquipment;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Objects.Actors
{
    public abstract class Actor : IDamage, IStaminaUsage
    {
        protected IItemDAO ItemDAO { get; set; } = new JsonItemDAO();

        public Actor(string name)
        {
            Name = name;
        }

        public string Name { get; protected set; }
        public string Gender { get; protected set; } = Constants.Gender.Male; // TODO: add pronouns for string interpolation
        public string Race { get; protected set; } = Constants.Race.Human;

        public abstract double GetNetModifier(string stat);

        public Health BaseHealth { get; protected set; }
        public int HP { get; set; }
        public int MaxHP => BaseHealth.HP + (int)GetNetModifier(Vitals.MaxHP);
        public double PercentHP => Math.Round(((HP / (double)MaxHP * 100)));

        public Stamina BaseStamina { get; protected set; }
        public int SP { get; set; }
        public int MaxSP => BaseStamina.SP + (int)GetNetModifier(Vitals.MaxSP);
        public double PercentSP => Math.Round((SP / (double)MaxSP), 2) * 100;

        public void AdjustHP(int points)
        {
            HP += points;
            if (HP > MaxHP)
            {
                HP = MaxHP;
            }
            else if (HP < 0)
            {
                Kill();
            }
        }
        public void AdjustSP(int points)
        {
            SP += points;
        }
        public void Damage(double dmgAmt, string dmgType, double dmgAP = 0)
        {
            throw new NotImplementedException();
        }
        public void Heal(double healAmt)
        {
            throw new NotImplementedException();
        }
        public bool IsAlive { get; set; } = true;
        public void Kill()
        {
            HP = 0;
            IsAlive = false;
        }
        public void Revive(int hp)
        {
            IsAlive = true;
            HP = hp;
        }
        public void UseStamina(int points)
        {
            if (SP >= points)
            {
                AdjustSP(-1 * points);
            }
            else
            {
                throw new NotEnoughStaminaException();
            }
        }
        public void RestoreStamina(int points)
        {
            throw new NotImplementedException();
        }

        public Inventory Inventory { get; protected set; } = new Inventory();

        // TODO: Skillbar
        // TODO: Active Effects
        // TODO: RewardDrops (XP, Loot)

    }

}
