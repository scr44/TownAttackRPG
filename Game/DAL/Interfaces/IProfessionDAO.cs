using Game.Objects.Items;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game.DAL.Interfaces
{
    public interface IProfessionDAO
    {
        public string getDefaultGender(string id);
        public string getTitle(string id);
        public string getDescription(string id);
        public string getAltGenderTitle(string id);
        public string getAltGenderDescription(string id);
        public Dictionary<string, int> getStartingAttributes(string id);
        public Dictionary<string, int> getStartingTalents(string id);
        public Dictionary<string, double> getStartingHealthAndStamina(string id);
        public Dictionary<string, string> getStartingEquipment(string id);
        public Dictionary<string, int> getStartingItems(string id);
        public Dictionary<int, string> getStartingSkills(string id);
    }
}
