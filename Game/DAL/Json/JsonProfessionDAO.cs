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

        public Profession GetProfession(string title)
        {
            using (StreamReader sr = new StreamReader(path))
            {
                string jsonData = sr.ReadToEnd();
                List<Profession> professionCatalog = JsonConvert.DeserializeObject<List<Profession>>(jsonData);
                var searchResults = (from p in professionCatalog
                                        where (p.Title == title || p.AltGenderTitle == title)
                                        select p).ToList();
                if (searchResults.Count == 0)
                {
                    throw new InvalidProfessionException();
                }
                else
                {
                    return searchResults[0];
                }
            }
        }
    }
}
