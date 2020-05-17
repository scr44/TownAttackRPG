using System;
using System.Collections.Generic;
using System.Text;

namespace GameCore.Objects.Actors
{
    public class Enemy : Actor
    {
        public Enemy(string name) : base(name)
        {

        }
        public override double Modifier(string stat)
        {
            throw new NotImplementedException();
        }
    }
}
