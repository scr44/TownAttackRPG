using Game.Constants;
using Game.DAL.Interfaces;
using Game.Objects.Items;
using System;
using System.Collections.Generic;
using System.Text;
using static Game.Constants.Tags;

namespace Game.DAL.Mocks
{
    public class MockItemDAO : IItemDAO
    {
        public Item CreateItem(string id)
        {
            return new Item()
            {
                Name = "Name",
                Description = "Description",
                Value = 10,
                Weight = 10.15
            };
        }

        public EquipmentItem CreateEquipment(string id)
        {
            var newItem = new EquipmentItem()
            {
                Name = EquipmentNames.Hands.Longsword,
                Description = "Description",
                Value = 10,
                Weight = 10.15,
                BlockChance = .5,
                MaxDurability = 100,
                ValidSlots = new List<string>()
                {
                    ValidSlots.MainHand
                },
                Tags = new List<string>()
                {
                    Equipment.Weapons.Weapon,
                    Equipment.Weapons.Sword
                },
                AttackMod = new Dictionary<string, double>()
                {
                    { DmgType.Slashing, 1 },
                    { DmgType.Piercing, 1 },
                    { DmgType.Crushing, 1 },
                    { DmgType.Fire, 1 },
                    { DmgType.Poison, 1 }
                },
                DefenseMod = new Dictionary<string, double>()
                {
                    { DmgType.Slashing, .25 },
                    { DmgType.Piercing, .5 },
                    { DmgType.Crushing, .2 },
                    { DmgType.Fire, 0 },
                    { DmgType.Poison, 0 }
                }
            };
            newItem.Durability = newItem.MaxDurability;
            return newItem;
        }
    }
}
