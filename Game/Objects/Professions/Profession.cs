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
            DefaultGender = ProfessionDAO.getDefaultGender(profession);
            Title = ProfessionDAO.getTitle(profession);
            Description = ProfessionDAO.getDescription(profession);
            AltGenderTitle = ProfessionDAO.getAltGenderTitle(profession);
            AltGenderDescription = ProfessionDAO.getAltGenderDescription(profession);

        }
        public string DefaultGender { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public string AltGenderTitle { get; private set; }
        public string AltGenderDescription { get; private set; }
        int BaseHealth { get; }
        int BaseStamina { get; }
        double BaseHealthRegen { get; }
        double BaseStaminaRegen { get; }
        Dictionary<string, int> StartingStats { get; }
        Dictionary<string, string> StartingEquipment { get; }
        Dictionary<int, string> StartingSkills { get; }
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
