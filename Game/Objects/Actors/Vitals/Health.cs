using GameCore.Objects.Actors.VitalsInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameCore.Objects.Actors.VitalsClasses
{
    public class Health : IHealth
    {
        public Health() { }
        public int MaxHP { get; set; }
        public int HPRegen { get; set; }
        public void AdjustBaseHP(int points)
        {
            MaxHP += points;
        }
    }

    public class Stamina : IStamina
    {
        public int MaxSP { get; set; }
        public int SPRegen { get; set; }
        public void AdjustBaseSP(int points)
        {
            MaxSP += points;
        }
    }
}
