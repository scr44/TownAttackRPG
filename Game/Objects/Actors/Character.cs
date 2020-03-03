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
using Game.Objects.Actors.VitalsClasses;
using Game.DAL.Json;

namespace Game.Objects.Actors
{
    public class Character : Actor, IChangeEquipment
    {
        // TODO: Dependency Injection
        IItemDAO ItemDAO { get; set; } = new JsonItemDAO();
        IProfessionDAO ProfessionDAO { get; set; } = new JsonProfessionDAO();
        public Character(string name, string gender, string professionId)
            : base(name, gender)
        {
            Profession = ProfessionDAO.GetProfession(professionId);
            if (gender != Profession.DefaultGender)
            {
                Profession.SwapDescriptions();
            }

            BaseAttributes = new Attributes() { Base = Profession.StartingAttributes };
            BaseTalents = new Talents() { Base = Profession.StartingTalents };
            BaseHealth = new Health()
            { 
                HP = (int)Profession.StartingVitals[Vitals.HP],
                HPRegen = (int)Profession.StartingVitals[Vitals.HPRegen]
            };
            BaseStamina = new Stamina()
            {
                SP = (int)Profession.StartingVitals[Vitals.SP],
                SPRegen = (int)Profession.StartingVitals[Vitals.SPRegen]
            };

            EquipmentSlots = new Dictionary<string, EquipmentItem>()
            {
                { Slot.Body, ItemDAO.GetEquipment(EquipmentCatalog.Body.Naked) },
                { Slot.MainHand, ItemDAO.GetEquipment(EquipmentCatalog.Hands.BareHand) },
                { Slot.OffHand, ItemDAO.GetEquipment(EquipmentCatalog.Hands.BareHand) },
                { Slot.Charm1, ItemDAO.GetEquipment(EquipmentCatalog.Charms.None) },
                { Slot.Charm2, ItemDAO.GetEquipment(EquipmentCatalog.Charms.None) }
            };
            foreach (var kvp in Profession.StartingEquipment)
            {
                Inventory.AddItem(ItemDAO.GetEquipment(kvp.Value));
                try
                {
                    Equip(kvp.Key, (EquipmentItem)Inventory.Items[0]);
                }
                catch (InvalidSlotException)
                {
                    Inventory.Items.RemoveAt(0);
                }
            }
            foreach (var kvp in Profession.StartingInventory)
            {
                for (int i = 0; i < kvp.Value; i++)
                {
                    Inventory.AddItem(ItemDAO.GetEquipment(kvp.Key));
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
        bool IsTwoHanding => EquipmentSlots[Slot.OffHand].Name == EquipmentCatalog.Hands.TwoHanding;
        
        public void Equip(string slot, EquipmentItem item)
        {
            bool isCharm = item.ValidSlots.Contains(Tags.ValidSlots.Charm);
            bool isCharmSlot = (slot == Slot.Charm1 || slot == Slot.Charm2);
            bool willDualWield = false;
            if (slot == Slot.MainHand)
            {
                willDualWield = item.Name == EquipmentSlots[Slot.OffHand].Name;
            }
            else if (slot == Slot.OffHand)
            {
                willDualWield = item.Name == EquipmentSlots[Slot.MainHand].Name;
            }
            bool mainHandRequiresTwoHanding = EquipmentSlots[Slot.MainHand].Tags.Contains(Tags.Restrictions.MustTwoHand);
            bool cannotDualWield = item.Tags.Contains(Tags.Restrictions.CannotDualWield);

            if (!Inventory.Items.Contains(item))
            {
                throw new NotInInventoryException();
            }
            if (!(item.ValidSlots.Contains(slot) || (isCharm && isCharmSlot)))
            {
                throw new InvalidSlotException();
            }
            if (willDualWield && cannotDualWield)
            {
                throw new CannotDualWieldException();
            }
            if (slot == Slot.OffHand && mainHandRequiresTwoHanding)
            {
                Unequip(Slot.MainHand);
            }
            
            Unequip(slot);
            EquipmentSlots[slot] = item;
            Inventory.RemoveItem((Item)item);

            mainHandRequiresTwoHanding = EquipmentSlots[Slot.MainHand].Tags.Contains(Tags.Restrictions.MustTwoHand);
            if (mainHandRequiresTwoHanding && !IsTwoHanding)
            {
                ToggleTwoHanding();
            }

        }
        public void Unequip(string slot)
        {
            if (EquipmentSlots[slot].Name != EquipmentCatalog.Hands.BareHand
                && EquipmentSlots[slot].Name != EquipmentCatalog.Hands.TwoHanding)
            {
                Inventory.AddItem((Item)EquipmentSlots[slot]);
            }
            EquipmentSlots[slot] = ItemDAO.GetEquipment(EquipmentCatalog.Hands.BareHand);
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
                    throw new CannotTwoHandException();
                }
                Unequip(Slot.OffHand);
                EquipmentSlots[Slot.OffHand] = ItemDAO.GetEquipment(EquipmentCatalog.Hands.TwoHanding);
            }
        }

        Dictionary<string, double> EquipmentModifiers { get; set; } = new Dictionary<string, double>();
        public override double GetModifier(string stat)
        {
            double totalMod = 0;
            if (EquipmentModifiers.TryGetValue(stat, out double equipMod))
            {
                totalMod += equipMod;
            }
            if (EffectModifiers.TryGetValue(stat, out double effectMod))
            {
                totalMod += effectMod;
            }
            return totalMod;
        }
    }
}
