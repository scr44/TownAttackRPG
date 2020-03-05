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
    public class Character : Actor, IEquipmentManagement
    {
        // TODO: Dependency Injection
        IProfessionDAO ProfessionDAO { get; set; } = new JsonProfessionDAO();
        public Character(string name, string gender, string professionId)
            : base(name)
        {
            Gender = gender;
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
                { Slot.Body, ItemDAO.GetEquipment(Profession.StartingEquipment[Slot.Body]) },
                { Slot.MainHand, ItemDAO.GetEquipment(Profession.StartingEquipment[Slot.MainHand]) },
                { Slot.OffHand, ItemDAO.GetEquipment(Profession.StartingEquipment[Slot.OffHand]) },
                { Slot.Charm1, ItemDAO.GetEquipment(Profession.StartingEquipment[Slot.Charm1]) },
                { Slot.Charm2, ItemDAO.GetEquipment(Profession.StartingEquipment[Slot.Charm2]) }
            };
            foreach (var kvp in Profession.StartingInventory)
            {
                for (int i = 0; i < kvp.Value; i++)
                {
                    Inventory.AddItem(ItemDAO.GetItem(kvp.Key));
                }
            }
            // Fill vitals to max after equipment bonuses are set
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

        public double GetEquipmentModifier(string stat)
        {

        }
        public override double GetNetModifier(string stat)
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
