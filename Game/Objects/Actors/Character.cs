using Game.Constants;
using Game.Objects.Items;
using Game.Objects.Professions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Game.Objects.Items.InventoryAndEquipment;

namespace Game.Objects.Actors
{
    public class Character : Actor, IChangeEquipment
    {
        public Character(string name, string gender, string race, string profession)
            : base(name, gender, race)
        {
            Profession = new Profession(profession);
            if (gender != Profession.DefaultGender)
            {
                Profession.SwapDescriptions();
            }
            BaseAttributes = new Attributes() { Base = Profession.StartingAttributes };
            BaseTalents = new Talents() { Base = Profession.StartingTalents };
            BaseHP = (int)Profession.StartingHealthAndStamina[BaseStat.HP];
            BaseSP = (int)Profession.StartingHealthAndStamina[BaseStat.SP];

            //TODO initialize Equipment and Inventory

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

        public Inventory Inventory { get; protected set; }

        #region Equipment
        public Dictionary<string, EquipmentItem> Slots { get; private set; }
        bool IsTwoHanding => Slots[Slot.OffHand].Name == EquipmentItems.Hands.TwoHanding;
        Dictionary<string, double> EquipmentModifiers { get; set; }
        void IChangeEquipment.EquipItem(string slot, EquipmentItem item)
        {
            var oldItem = Slots[slot];
            Slots[slot] = item;
            Inventory.RemoveItem((Item)item);
            Inventory.AddItem(oldItem);
        }
        void IChangeEquipment.ToggleTwoHanding()
        {
            throw new NotImplementedException();
        }
        void IChangeEquipment.UnequipItem(string slot)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
