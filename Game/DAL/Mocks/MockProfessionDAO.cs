using Game.Constants;
using Game.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game.DAL.Mocks
{
    public class MockProfessionDAO : IProfessionDAO
    {
        string IProfessionDAO.getTitle(string profession)
        {
            return "Title";
        }

        string IProfessionDAO.getAltGenderDescription(string profession)
        {
            return "AltGenderDescription";
        }

        string IProfessionDAO.getAltGenderTitle(string profession)
        {
            return "AltGenderTitle";
        }

        string IProfessionDAO.getDescription(string profession)
        {
            return "Description";
        }

        string IProfessionDAO.getDefaultGender(string profession)
        {
            return "Male";
        }

        Dictionary<string, string> IProfessionDAO.getStartingEquipment(string profession)
        {
            return new Dictionary<string, string>() { };
        }

        Dictionary<int, string> IProfessionDAO.getStartingSkills(string profession)
        {
            return new Dictionary<int, string>()
            {

            };
        }

        Dictionary<string, int> IProfessionDAO.getStartingAttributes(string profession)
        {
            return new Dictionary<string, int>()
            {
                { Stat.STR, 5 },
                { Stat.DEX, 5 },
                { Stat.SKL, 5 },
                { Stat.APT, 5 },
                { Stat.FOR, 5 },
                { Stat.CHA, 5 }
            };
        }

        Dictionary<string, int> IProfessionDAO.getStartingTalents(string profession)
        {
            return new Dictionary<string, int>()
            {
                { Stat.Medicine, 0 },
                { Stat.Explosives, 0 },
                { Stat.Veterancy, 0 },
                { Stat.Bestiary, 0 },
                { Stat.Engineering, 0 },
                { Stat.History, 0 }
            };
        }

        Dictionary<string, double> IProfessionDAO.getStartingHealthAndStamina(string profession)
        {
            return new Dictionary<string, double>()
            {
                { BaseStat.HP, 10 },
                { BaseStat.SP, 10 },
                { BaseStat.HPRegen, 0 },
                { BaseStat.SPRegen, 5 }
            };
        }
    }
}
