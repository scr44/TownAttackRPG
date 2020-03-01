using Game.Constants;
using Game.Objects.Items;
using Game.Objects.Professions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Game.Objects.Items.InventoryAndEquipment;
using Game.DAL.Interfaces;
using Game.DAL.Mocks;

namespace Game.Objects.Actors
{
    public class Character : Actor, IChangeEquipment
    {
        // TODO: Dependency Injection
        IItemDAO ItemDAO { get; set; } = new MockItemDAO();
        IProfessionDAO ProfessionDAO { get; set; } = new MockProfessionDAO();
        public Character(string name, string gender, string profession)
            : base(name, gender)
        {
            Profession = ProfessionDAO.GetProfessionStats(profession);
            if (gender != Profession.DefaultGender)
            {
                Profession.SwapDescriptions();
            }

            BaseAttributes = new Attributes() { Base = Profession.StartingAttributes };
            BaseTalents = new Talents() { Base = Profession.StartingTalents };
            BaseHP = (int)Profession.StartingHealthAndStamina[BaseStat.HP];
            BaseSP = (int)Profession.StartingHealthAndStamina[BaseStat.SP];

            EquipmentSlots = new Dictionary<string, EquipmentItem>()
            {
                { Slot.Body, ItemDAO.CreateEquipment(EquipmentNames.Body.Naked) },
                { Slot.MainHand, ItemDAO.CreateEquipment(EquipmentNames.Hands.BareHand) },
                { Slot.OffHand, ItemDAO.CreateEquipment(EquipmentNames.Hands.BareHand) },
                { Slot.Charm1, ItemDAO.CreateEquipment(EquipmentNames.Charms.None) },
                { Slot.Charm2, ItemDAO.CreateEquipment(EquipmentNames.Charms.None) }
            };
            foreach (var kvp in Profession.StartingEquipment)
            {
                Inventory.AddItem(ItemDAO.CreateEquipment(kvp.Value));
                Equip(kvp.Key, (EquipmentItem)Inventory.Items[0]);
            }
            foreach (var kvp in Profession.StartingInventory)
            {
                for (int i = 0; i < kvp.Value; i++)
                {
                    Inventory.AddItem(ItemDAO.CreateEquipment(kvp.Key));
                }
            }
            HP = MaxHP;
            SP = MaxSP;
        }

        public Profession Profession { get; set; }
        public Attributes BaseAttributes { get; set; }
        public Talents BaseTalents { get; set; }

        public Dictionary<string, int> Attributes
        {
            get
            {
                Dictionary<string, int> ModifiedAttributes = BaseAttributes.Base;
                foreach (var kvp in ModifiedAttributes)
                {
                    ModifiedAttributes[kvp.Key] += (int)EquipmentModifiers[kvp.Key] + (int)EffectModifiers[kvp.Key];
                }
                return ModifiedAttributes;
            }
        }
        public Dictionary<string, int> Talents
        {
            get
            {
                Dictionary<string, int> ModifiedTalents = BaseTalents.Base;
                foreach (var kvp in ModifiedTalents)
                {
                    ModifiedTalents[kvp.Key] += (int)EquipmentModifiers[kvp.Key] + (int)EffectModifiers[kvp.Key];
                }
                return ModifiedTalents;
            }
        }

        public Inventory Inventory { get; protected set; } = new Inventory();
        public Dictionary<string, EquipmentItem> EquipmentSlots { get; private set; }

        bool IsTwoHanding => EquipmentSlots[Slot.OffHand].Name == EquipmentNames.Hands.TwoHanding;
        public void Equip(string slot, EquipmentItem item)
        {
            if (!Inventory.Items.Contains(item))
            {
                throw new Exception("Item not in inventory.");
            }
            if (item.ValidSlots.Contains(slot) 
                || (item.ValidSlots.Contains(Tags.ValidSlots.Charm) 
                    && (slot == Slot.Charm1 || slot == Slot.Charm2)))
            {
                Unequip(slot);
                EquipmentSlots[slot] = item;
                Inventory.RemoveItem((Item)item);
            }
            else
            {
                throw new Exception("Invalid slot.");
            }

        }
        public void Unequip(string slot)
        {
            if (EquipmentSlots[slot].Name != EquipmentNames.Hands.BareHand
                && EquipmentSlots[slot].Name != EquipmentNames.Hands.TwoHanding)
            {
                Inventory.AddItem((Item)EquipmentSlots[slot]);
            }
            EquipmentSlots[slot] = ItemDAO.CreateEquipment(EquipmentNames.Hands.BareHand);
        }
        public void ToggleTwoHanding()
        {
            if (IsTwoHanding)
            {
                Unequip(Slot.OffHand);
            }
            else
            {
                if (EquipmentSlots[Slot.MainHand].Tags.Contains(Tags.Restrictions.CannotTwoHand))
                {
                    throw new Exception("Cannot two-hand this weapon.");
                }
                Unequip(Slot.OffHand);
                EquipmentSlots[Slot.OffHand] = ItemDAO.CreateEquipment(EquipmentNames.Hands.TwoHanding);
            }
        }

        Dictionary<string, double> EquipmentModifiers { get; set; }
    }
}
