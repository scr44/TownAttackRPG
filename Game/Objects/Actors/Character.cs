using System.Collections.Generic;
using GameCore.Constants;
using GameCore.DAL.Interfaces;
using GameCore.DAL.Json;
using GameCore.Objects.Actors.VitalsClasses;
using GameCore.Objects.Items;
using GameCore.Objects.Items.InventoryAndEquipment;
using GameCore.Objects.Professions;

namespace GameCore.Objects.Actors
{
    public class Character : Actor, IEquipmentManagement
    {
        // TODO: Dependency Injection
        IProfessionDAO ProfessionDAO => new JsonProfessionDAO();
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
            Health = new Health()
            { 
                MaxHP = (int)Profession.StartingVitals[Vitals.HP],
                HPRegen = (int)Profession.StartingVitals[Vitals.HPRegen]
            };
            Stamina = new Stamina()
            {
                MaxSP = (int)Profession.StartingVitals[Vitals.SP],
                SPRegen = (int)Profession.StartingVitals[Vitals.SPRegen]
            };
            EquipmentSlots = new Dictionary<string, EquipmentItem>()
            {
                { Slot.Body, ItemDAO.GenerateNewEquipmentItem(Profession.StartingEquipment[Slot.Body]) },
                { Slot.MainHand, ItemDAO.GenerateNewEquipmentItem(Profession.StartingEquipment[Slot.MainHand]) },
                { Slot.OffHand, ItemDAO.GenerateNewEquipmentItem(Profession.StartingEquipment[Slot.OffHand]) },
                { Slot.Charm1, ItemDAO.GenerateNewEquipmentItem(Profession.StartingEquipment[Slot.Charm1]) },
                { Slot.Charm2, ItemDAO.GenerateNewEquipmentItem(Profession.StartingEquipment[Slot.Charm2]) }
            };
            foreach (var kvp in Profession.StartingInventory)
            {
                for (int i = 0; i < kvp.Value; i++)
                {
                    Inventory.AddItem(ItemDAO.GenerateNewItem(kvp.Key));
                }
            }
            // Fill vitals to max after equipment bonuses are set
            HP = MaxHP;
            SP = MaxSP;
        }

        public Profession Profession { get; protected set; }
        public Attributes BaseAttributes { get; protected set; }
        public Talents BaseTalents { get; protected set; }

        public Dictionary<string, int> Attributes
        {
            get
            {
                var attributes = new Dictionary<string, int>();
                foreach (var baseStat in BaseAttributes.Base)
                {
                    attributes[baseStat.Key] = baseStat.Value + (int)Modifier(baseStat.Key);
                }
                return attributes;
            }
        }
        public Dictionary<string, int> Talents
        {
            get
            {
                var talents = new Dictionary<string, int>();
                foreach (var baseStat in BaseTalents.Base)
                {
                    talents[baseStat.Key] = baseStat.Value + (int)Modifier(baseStat.Key);
                }
                return talents;
            }
        }

        public Dictionary<string, EquipmentItem> EquipmentSlots { get; private set; }
        bool IsTwoHanding => EquipmentSlots[Slot.OffHand].DisplayName == EquipmentCatalog.Hands.TwoHanding;
        public void Equip(string slot, EquipmentItem item)
        {
            bool isCharm = item.ValidSlots.Contains(Slot.Charm);
            bool isCharmSlot = (slot == Slot.Charm1 || slot == Slot.Charm2);
            bool willDualWield = false;
            if (slot == Slot.MainHand)
            {
                willDualWield = item.DisplayName == EquipmentSlots[Slot.OffHand].DisplayName;
            }
            else if (slot == Slot.OffHand)
            {
                willDualWield = item.DisplayName == EquipmentSlots[Slot.MainHand].DisplayName;
            }
            bool mainHandRequiresTwoHanding = EquipmentSlots[Slot.MainHand].Tags.Contains(Tags.Restrictions.MustTwoHand);
            bool cannotDualWield = item.Tags.Contains(Tags.Restrictions.CannotDualWield);

            if (!Inventory.Items.Contains(item))
            {
                throw new NotInInventoryException();
            }

            // TODO: throw DoesNotMeetStatRequirements exception if applicable

            if (!(
                item.ValidSlots.Contains(slot) || (isCharm && isCharmSlot)
                ))
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
            bool canStoreItem = !(EquipmentSlots[slot].Tags.Contains(Tags.Equipment.EmptySlot));
            if (canStoreItem)
            {
                Inventory.AddItem((Item)EquipmentSlots[slot]);
            }

            switch (slot)
            {
                case Slot.MainHand:
                case Slot.OffHand:
                    EquipmentSlots[slot] = ItemDAO.GenerateNewEquipmentItem(EquipmentCatalog.Hands.BareHand);
                    if (EquipmentSlots[Slot.OffHand].IdName == EquipmentCatalog.Hands.TwoHanding)
                    {
                        EquipmentSlots[Slot.OffHand] = ItemDAO.GenerateNewEquipmentItem(EquipmentCatalog.Hands.BareHand);
                    }
                    break;

                case Slot.Body:
                    EquipmentSlots[slot] = ItemDAO.GenerateNewEquipmentItem(EquipmentCatalog.Body.Naked);
                    break;

                case Slot.Charm1:
                case Slot.Charm2:
                    EquipmentSlots[slot] = ItemDAO.GenerateNewEquipmentItem(EquipmentCatalog.Charms.None);
                    break;
            }

        }
        public void UnequipAll()
        {
            foreach (var slot in EquipmentSlots.Keys)
            {
                Unequip(slot);
            }
        }
        public void ToggleTwoHanding()
        {
            var mainHandRequiresTwoHanding = EquipmentSlots[Slot.MainHand].Tags.Contains(Tags.Restrictions.MustTwoHand);

            if (IsTwoHanding && mainHandRequiresTwoHanding)
            {
                Unequip(Slot.MainHand);
                Unequip(Slot.OffHand);
            }
            else if (IsTwoHanding && !mainHandRequiresTwoHanding)
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
                EquipmentSlots[Slot.OffHand] = ItemDAO.GenerateNewEquipmentItem(EquipmentCatalog.Hands.TwoHanding);
            }
        }

        public double GetEquipmentModifier(string stat, bool isMultiplierStat)
        {
            bool isPhysicalAtk = stat.Contains("ATK") && 
                (stat.Contains(DmgType.Slashing) || stat.Contains(DmgType.Piercing) || stat.Contains(DmgType.Crushing));
            double modifier = isMultiplierStat ? 1 : 0;
            if (isMultiplierStat)
            {
                foreach (var kvp in EquipmentSlots)
                {
                    var equipment = kvp.Value;
                    if (equipment.AttackMod.TryGetValue(stat, out double atkMod))
                    {
                        modifier *= atkMod;
                    }
                    if (equipment.DefenseMod.TryGetValue(stat, out double defMod))
                    {
                        modifier *= defMod;
                    }
                    if (equipment.BonusStatMod.TryGetValue(stat, out double charmMod))
                    {
                        modifier *= charmMod;
                    }
                }

                if (isPhysicalAtk && IsTwoHanding)
                {
                    modifier *= 1.5;
                }

                return modifier;
            }
            else
            {
                foreach (var kvp in EquipmentSlots)
                {
                    var equipment = kvp.Value;
                    if (equipment.AttackMod.TryGetValue(stat, out double atkMod))
                    {
                        modifier += atkMod;
                    }
                    if (equipment.DefenseMod.TryGetValue(stat, out double defMod))
                    {
                        modifier += defMod;
                    }
                    if (equipment.BonusStatMod.TryGetValue(stat, out double charmMod))
                    {
                        modifier += charmMod;
                    }
                }

                return modifier;
            }
        }
        public double GetAttAndTalModifier(string stat, bool isMultiplierStat)
        {
            double modifier = isMultiplierStat ? 1 : 0;
            // TODO: Implement attribute and talent mods
            return modifier;
        }
        public double GetActiveEffectModifier(string stat, bool isMultiplierStat)
        {
            double modifier = isMultiplierStat ? 1 : 0;
            // TODO: Implement effect mods
            return modifier;
        }
        public override double Modifier(string stat)
        {
            bool isAtkStat = stat.Contains("ATK");
            bool isDefStat = stat.Contains("DEF");
            bool isMultiplierStat = isAtkStat || isDefStat;
            if (isMultiplierStat)
            {
                return GetEquipmentModifier(stat, isMultiplierStat) * GetAttAndTalModifier(stat, isMultiplierStat) * GetActiveEffectModifier(stat, isMultiplierStat);
            }
            else
            {
                return GetEquipmentModifier(stat, isMultiplierStat) + GetAttAndTalModifier(stat, isMultiplierStat) + GetActiveEffectModifier(stat, isMultiplierStat);
            }
        }
    }
}
