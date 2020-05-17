using GameCore.DAL.Interfaces;
using GameCore.Objects.Items;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace GameCore.DAL.Json
{
    public class JsonItemDAO : IItemDAO
    {
        readonly string jsonLibraryPath = "../../../../Game/DAL/Json";
        List<Item> itemCatalog => GetItemCatalog();
        List<EquipmentItem> equipmentCatalog => GetEquipmentCatalog();

        public Item GenerateNewItem(string id)
        {
            var searchResults = (from i in itemCatalog
                                 where i.IdName == id
                                 select i).ToList();
            if (searchResults.Count == 0)
            {
                throw new InvalidItemException();
            }
            else
            {
                return searchResults[0];
            }
        }
        public EquipmentItem GenerateNewEquipmentItem(string id)
        {
            var searchResults = (from e in equipmentCatalog
                                 where e.IdName == id
                                 select e).ToList();
            if (searchResults.Count == 0)
            {
                throw new InvalidEquipmentItemException();
            }
            else
            {
                return searchResults[0];
            }
        }
        public void AddOrUpdateItem(Item newItem)
        {
            var updatedCatalog = GetItemCatalog();
            foreach (var item in updatedCatalog.ToList())
            {
                if (item.IdName == newItem.IdName)
                {
                    updatedCatalog.Remove(item);
                }
            }
            updatedCatalog.Add(newItem);
            updatedCatalog.Sort((x, y) => string.Compare(x.IdName, y.IdName));
            File.WriteAllText(jsonLibraryPath + "/items.json",
                JsonConvert.SerializeObject(updatedCatalog,Formatting.Indented));
        }
        public void AddOrUpdateEquipment(EquipmentItem newEquipment)
        {
            var updatedCatalog = GetEquipmentCatalog();
            foreach (var item in updatedCatalog.ToList())
            {
                if (item.IdName == newEquipment.IdName)
                {
                    updatedCatalog.Remove(item);
                }
            }
            updatedCatalog.Add(newEquipment);
            updatedCatalog.Sort((x, y) => string.Compare(x.IdName, y.IdName));
            File.WriteAllText(jsonLibraryPath + "/equipment.json",
                JsonConvert.SerializeObject(updatedCatalog,Formatting.Indented));
        }
        public List<Item> GetItemCatalog()
        {
            string path = jsonLibraryPath + "/items.json";
            using (StreamReader sr = new StreamReader(path))
            {
                string jsonData = sr.ReadToEnd();
                return JsonConvert.DeserializeObject<List<Item>>(jsonData);
            }
        }
        public List<EquipmentItem> GetEquipmentCatalog()
        {
            string path = jsonLibraryPath + "/equipment.json";
            using (StreamReader sr = new StreamReader(path))
            {
                string jsonData = sr.ReadToEnd();
                return JsonConvert.DeserializeObject<List<EquipmentItem>>(jsonData);
            }
        }

        public void SaveItemToDB(Item item)
        {
            throw new NotImplementedException();
        }
    }
}
