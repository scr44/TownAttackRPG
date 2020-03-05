using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Objects.Actors
{
    public class Enemy : Actor
    {
        public Enemy(string name, string gender) : base(name, gender)
        {

        }
        public override double GetNetModifier(string stat)
        {
            throw new NotImplementedException();
        }
    }
}
