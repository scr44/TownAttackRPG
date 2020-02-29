using System;
using System.Collections.Generic;
using System.Text;

namespace Game.DAL.Interfaces
{
    public interface IProfessionDAO
    {
        public string getDefaultGender(string profession);
        public string getTitle(string profession);
        public string getDescription(string profession);
        public string getAltGenderTitle(string profession);
        public string getAltGenderDescription(string profession);
        public Dictionary<string, int> getStartingAttributes(string profession);
        public Dictionary<string, int> getStartingTalents(string profession);
        public Dictionary<string, double> getStartingHealthAndStamina(string profession);
        public Dictionary<string, string> getStartingEquipment(string profession);
        public Dictionary<int, string> getStartingSkills(string profession);
    }
}
