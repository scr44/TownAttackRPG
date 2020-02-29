using Game.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Objects.Professions
{
    public class Profession
    {
        IProfessionDAO ProfessionDAO { get; set; }
        public Profession(string profession)
        {
            //TODO: Dependency injection for ProfDAO
            ProfessionDAO = new DAL.Mocks.MockProfessionDAO();

            DefaultGender = ProfessionDAO.getDefaultGender(profession);
            Title = ProfessionDAO.getTitle(profession);
            Description = ProfessionDAO.getDescription(profession);
            AltGenderTitle = ProfessionDAO.getAltGenderTitle(profession);
            AltGenderDescription = ProfessionDAO.getAltGenderDescription(profession);
            StartingAttributes = ProfessionDAO.getStartingAttributes(profession);
            StartingTalents = ProfessionDAO.getStartingTalents(profession);
            StartingHealthAndStamina = ProfessionDAO.getStartingHealthAndStamina(profession);
            StartingEquipment = ProfessionDAO.getStartingEquipment(profession);
            StartingSkills = ProfessionDAO.getStartingSkills(profession);
        }
        public string DefaultGender { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public string AltGenderTitle { get; private set; }
        public string AltGenderDescription { get; private set; }
        public Dictionary<string, int> StartingAttributes { get; }
        public Dictionary<string, int> StartingTalents { get; }
        public Dictionary<string, double> StartingHealthAndStamina { get; }
        public Dictionary<string, string> StartingEquipment { get; }
        public Dictionary<int, string> StartingSkills { get; }

        public void SwapDescriptions()
        {
            string mainTitle = Title;
            string mainDescrip = Description;
            Title = AltGenderTitle;
            Description = AltGenderDescription;
            AltGenderTitle = mainTitle;
            AltGenderDescription = mainDescrip;
        }
    }
}
