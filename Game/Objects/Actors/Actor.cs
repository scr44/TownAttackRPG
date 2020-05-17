using GameCore.Constants;
using GameCore.DAL.Interfaces;
using GameCore.DAL.Json;
using GameCore.Objects.Actors.VitalsClasses;
using GameCore.Objects.Actors.VitalsInterfaces;
using GameCore.Objects.Effects;
using GameCore.Objects.Items.InventoryAndEquipment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameCore.Objects.Actors
{
    public abstract class Actor : IDamage, IStaminaUsage, IEffectManagement
    {
        protected IItemDAO ItemDAO => new JsonItemDAO();

        public Actor(string name)
        {
            Name = name;
        }

        public string Name { get; protected set; }
        public string Gender { get; protected set; } = Constants.Gender.Male; // TODO: add pronouns for string interpolation
        public string Race { get; protected set; } = Constants.Race.Human;

        public abstract double Modifier(string stat);

        public Health Health { get; protected set; }
        public int HP { get; set; }
        public int MaxHP => Health.MaxHP + (int)Modifier(Vitals.MaxHP);
        public double PercentHP => Math.Round((HP / (double)MaxHP * 100));

        public Stamina Stamina { get; protected set; }
        public int SP { get; set; }
        public int MaxSP => Stamina.MaxSP + (int)Modifier(Vitals.MaxSP);
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
        public void Damage(double dmgAmt, string dmgType, double dmgArmorPiercing = 0)
        {
            var typeDef = dmgType + "DEF";
            var dmgDef = Modifier(typeDef);
            var dmgUnblocked = dmgAmt * (1 - dmgDef);
            double dmgArmorIgnoring = 0;
            if (dmgDef > 0)
            {
                var dmgBlocked = (dmgAmt - dmgUnblocked);
                dmgArmorIgnoring = dmgBlocked - dmgArmorPiercing > 0 ? dmgArmorPiercing : dmgBlocked;
            }
            int totalDmg = (int)(
                (dmgUnblocked + dmgArmorIgnoring) * 
                    (1 + Modifier(Constants.Effects.Debuffs.PercentIncreaseDamageTaken) 
                    - Modifier(Constants.Effects.Buffs.PercentDecreaseDamageTaken))
                );
            AdjustHP(-1 * totalDmg);
        }
        public void Heal(double healAmt)
        {
            int healTotal = (int)(
                healAmt * (1 + Modifier(Constants.Effects.Buffs.PercentHealingBonus) - Modifier(Constants.Effects.Debuffs.PercentHealingPenalty)) 
                + Modifier(Constants.Effects.Buffs.FlatHealingBonus) - Modifier(Constants.Effects.Debuffs.FlatHealingPenalty));
            AdjustHP(healTotal);
        }
        public bool IsAlive { get; set; } = true;
        public void Kill()
        {
            HP = 0;
            IsAlive = false;
            // TODO: remove all active effects
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

        public List<Effect> ActiveEffects { get; private set; } = new List<Effect>();
        public void ApplyEffect(Effect effect)
        {
            var activeInstances = ActiveEffects.Where(x => x.id == effect.id).ToList<Effect>();
            if (effect.Refreshes && activeInstances.Count > 0)
            {
                activeInstances[0].Refresh();
            }
            else if (!effect.Stacks && activeInstances.Count > 0)
            {
                throw new NotImplementedException();
            }
            else
            {
                ActiveEffects.Add(effect);
                ActiveEffects[ActiveEffects.Count - 1].WhenApplied();
            }
        }
        public void RemoveEffect(int index)
        {
            ActiveEffects[index].WhenRemoved();
            ActiveEffects.RemoveAt(index);
        }
        public void TickEffects()
        {
            foreach (var effect in ActiveEffects)
            {
                effect.Tick();
            }

            for (int i = ActiveEffects.Count - 1; i >= 0; i--)
            {
                if (ActiveEffects[i].Duration == 0)
                {
                    ActiveEffects[i].WhenExpired();
                    ActiveEffects.RemoveAt(i);
                }
            }
        }

        // TODO: Skillbar
        // TODO: RewardDrops (XP, Loot)

    }

}
