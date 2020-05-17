using GameCore.Objects.Actors;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameCore.Objects.Effects
{
    public interface IEffectManagement
    {
        public void ApplyEffect(Effect effect);
        public void RemoveEffect(int index);
        public void TickEffects();
    }

    public interface IEffect
    {
        public void WhenApplied();
        public void WhenRemoved();
        public void WhenExpired();
        public void Refresh();
        public void OnTick();
        public void Tick();
        public List<string> RaiseTagOccurrence();
    }

    abstract public class Effect : IEffect
    {
        public Effect(Actor target, double? duration = null)
        {
            InitDuration = duration;
            Duration = duration;
        }
        public string id { get; }
        public string Name { get; }
        public Actor Target { get; private set; }
        public double? InitDuration { get; }
        public double? Duration { get; private set; }
        public int TicksPerDurationUnit { get; private set; } = 1;
        public bool Stacks { get; } = true;
        public bool Refreshes { get; } = false;
        public Dictionary<string, double> Modifiers { get; private set; } = new Dictionary<string, double>();
        public List<string> Tags { get; } = new List<string>() { "Effect" };

        public virtual void WhenApplied() { }
        public virtual void WhenRemoved() { }
        public virtual void WhenExpired() { }
        public virtual void OnTick() { }
        public virtual void Tick()
        {
            for (int i = 0; i < TicksPerDurationUnit; i++)
            {
                OnTick();
            }

            if (Duration != null)
            {
                Duration--;
            }
        }
        public virtual void Refresh()
        {
            Duration = InitDuration;
        }
        public virtual List<string> RaiseTagOccurrence()
        {
            return new List<string>();
        }
    }
}
