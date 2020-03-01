using Game.DAL.Interfaces;
using Game.Objects.Items;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Game.DAL.Json
{
    public class JsonItemDAO : IItemDAO
    {
        readonly string jsonLibraryPath = "../../../../Game/DAL/Json";
        List<Item> itemCatalog => GetItemCatalog();
        List<EquipmentItem> equipmentCatalog => GetEquipmentCatalog();

        public Item GetItem(string id)
        {
            var searchResults = (from i in itemCatalog
                                 where i.id == id
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
        public EquipmentItem GetEquipment(string id)
        {
            var searchResults = (from e in equipmentCatalog
                                 where e.id == id
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
        public void AddItemToCatalog(Item newItem)
        {
            var updatedCatalog = itemCatalog;
            updatedCatalog.Add(newItem);
            File.WriteAllText(jsonLibraryPath + "/items.json",
                JsonConvert.SerializeObject(updatedCatalog));
        }
        public void AddEquipmentToCatalog(EquipmentItem newItem)
        {
            var updatedCatalog = equipmentCatalog;
            updatedCatalog.Add(newItem);
            File.WriteAllText(jsonLibraryPath + "/equipment.json",
                JsonConvert.SerializeObject(equipmentCatalog.Add(newItem)));
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
    }
}
