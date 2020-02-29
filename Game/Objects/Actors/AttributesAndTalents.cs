using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Objects.Actors
{
    public class Attributes
    {
        public Dictionary<string, int> Base { get; set; }
        public int AttributePoints { get; private set; }
        private void AdjustAttribute(string stat, int points)
        {
            try
            {
                Base[stat] += points;
            }
            catch (KeyNotFoundException)
            {
                throw new KeyNotFoundException("Invalid Attribute, cannot adjust.");
            }
        }
        private void SetAttribute(string stat, int points)
        {
            try
            {
                Base[stat] = points;
            }
            catch (KeyNotFoundException)
            {
                throw new KeyNotFoundException("Invalid Attribute, cannot set.");
            }
        }
        public void GainAttributePoints(int points)
        {
            AttributePoints += points;
        }
        public void SpendAttributePoint(string stat)
        {
            if (AttributePoints <= 0)
            {
                throw new Exception("Not enough attribute points.");
            }
            AdjustAttribute(stat, 1);
            AttributePoints -= 1;
        }
    }
    public class Talents
    {
        public Dictionary<string, int> Base { get; set; }
        public int TalentPoints { get; set; }
        private void AdjustTalent(string stat, int points)
        {
            try
            {
                Base[stat] += points;
            }
            catch (KeyNotFoundException)
            {
                throw new KeyNotFoundException("Invalid Talent, cannot adjust.");
            }
        }
        private void SetTalent(string stat, int points)
        {
            try
            {
                Base[stat] = points;
            }
            catch (KeyNotFoundException)
            {
                throw new KeyNotFoundException("Invalid Talent, cannot set.");
            }
        }
        public void GainTalentPoints(int points)
        {
            TalentPoints += points;
        }
        public void SpendTalentPoint(string stat)
        {
            if (TalentPoints <= 0)
            {
                throw new Exception("Not enough attribute points.");
            }
            AdjustTalent(stat, 1);
            TalentPoints -= 1;
        }
    }
    // TODO: allow respeccing
}
