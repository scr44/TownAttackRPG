using GameCore.DAL.Interfaces;
using GameCore.Objects.Professions;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;

namespace GameCore.DAL.Json
{
    public class JsonProfessionDAO : IProfessionDAO
    {
        readonly string path = "../../../../Game/DAL/Json/professions.json";

        public Profession GetProfession(string id)
        {
            var professionCatalog = GetProfessionCatalog();
            var searchResults = (from p in professionCatalog
                                        where (p.id == id)
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

        public void AddOrUpdateProfession(Profession newProf)
        {
            var professionCatalog = GetProfessionCatalog();
            foreach (var prof in professionCatalog)
            {
                if (prof.id == newProf.id)
                {
                    professionCatalog.Remove(prof);
                }
            }
            professionCatalog.Add(newProf);
            professionCatalog.Sort((x, y) => string.Compare(x.id, y.id));
            File.WriteAllText(path, JsonConvert.SerializeObject(professionCatalog, Formatting.Indented));
        }

        public List<Profession> GetProfessionCatalog()
        {
            using (StreamReader sr = new StreamReader(path))
            {
                string jsonData = sr.ReadToEnd();
                return JsonConvert.DeserializeObject<List<Profession>>(jsonData);
            }
        }
    }
}
