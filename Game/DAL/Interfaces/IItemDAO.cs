using System;
using System.Collections.Generic;
using System.Text;

namespace Game.DAL.Interfaces
{
    public interface IItemDAO
    {
        public string getName(string id);
        public string getDescription(string id);
        public int getValue(string id);
        public double getWeight(string id);
        public List<string> getTags(string id);
        public Dictionary<string, double> getOffense(string id);
        public Dictionary<string, double> getDefense(string id);
        public double getBlockChance(string id);
        public double getMaxDurability(string id);
    }
}
