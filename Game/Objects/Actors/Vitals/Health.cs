using Game.Objects.Actors.VitalsInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Objects.Actors.VitalsClasses
{
    public class Health : IHealth
    {
        public Health() { }
        public int HP { get; set; }
        public int HPRegen { get; set; }
        public void AdjustBaseHP(int points)
        {
            HP += points;
        }
    }

    public class Stamina : IStamina
    {
        public int SP { get; set; }
        public int SPRegen { get; set; }
        public void AdjustBaseSP(int points)
        {
            SP += points;
        }
    }
}
