using Game.Constants;
using Game.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using static Game.Constants.Tags;

namespace Game.DAL.Mocks
{
    public class MockItemDAO : IItemDAO
    {
        public string getDescription(string id)
        {
            return "Description";
        }
        public string getName(string id)
        {
            return "Name";
        }
        public int getValue(string id)
        {
            return 10;
        }
        public double getWeight(string id)
        {
            return 15.5;
        }
        public Dictionary<string, double> getOffense(string id)
        {
            return new Dictionary<string, double>()
            {
                { DmgType.Slashing, 1 },
                { DmgType.Piercing, 1 },
                { DmgType.Crushing, 1 },
                { DmgType.Fire, 0 },
                { DmgType.Poison, 0 }
            };
        }
        public Dictionary<string, double> getDefense(string id)
        {
            return new Dictionary<string, double>()
            {
                { DmgType.Slashing, .25 },
                { DmgType.Piercing, .5 },
                { DmgType.Crushing, .2 },
                { DmgType.Fire, 0 },
                { DmgType.Poison, 0 }
            };
        }
        public double getBlockChance(string id)
        {
            return 0.10;
        }
        public double getMaxDurability(string id)
        {
            return 100;
        }
        public List<string> getTags(string id)
        {
            return new List<string>()
            {

            };
        }
    }
}
