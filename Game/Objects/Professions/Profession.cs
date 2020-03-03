using Game.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Objects.Professions
{
    public class Profession
    {
        public string id { get; set; }
        public string DefaultGender { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string AltGenderTitle { get; set; }
        public string AltGenderDescription { get; set; }
        public Dictionary<string, int> StartingAttributes { get; set; }
        public Dictionary<string, int> StartingTalents { get; set; }

        public Dictionary<string, int> StartingVitals { get; set;}
        public Dictionary<string, int> StartingInventory { get; set;}
        public Dictionary<string, string> StartingEquipment { get; set;}
        public Dictionary<int, string> StartingSkills { get; set;}

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
