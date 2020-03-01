using Game.DAL.Interfaces;
using Game.Objects.Professions;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;

namespace Game.DAL.Json
{
    public class JsonProfessionDAO : IProfessionDAO
    {
        readonly string path = "../../../../Game/DAL/Json/professions.json";
        string jsonData;

        public Profession GetProfession(string title)
        {
            if (jsonData == null)
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    jsonData = sr.ReadToEnd();
                }
            }
            
            List<Profession> professionCatalog = JsonConvert.DeserializeObject<List<Profession>>(jsonData);
            var results = (from p in professionCatalog
                           where (p.Title == title || p.AltGenderTitle == title)
                           select p).ToList();
            if (results.Count == 0)
            {
                throw new InvalidProfessionException();
            }
            else
            {
                return results[0];
            }
        }
    }
}
