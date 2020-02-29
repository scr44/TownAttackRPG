using Game.Constants;
using Game.Objects.Items;
using Game.Objects.Professions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Objects.Actors
{
    public class Character : Actor, IInventory, IEquipment
    {
        public Character(string name, string gender, string race, string profession)
            : base(name, gender, race)
        {
            Profession = new Profession(profession);
            if (gender != Profession.DefaultGender)
            {
                Profession.SwapDescriptions();
            }
            Attributes = new Attributes() { Base = Profession.StartingAttributes };
            Talents = new Talents() { Base = Profession.StartingTalents };
            BaseHP = (int)Profession.StartingHealthAndStamina[BaseStat.HP];
            BaseSP = (int)Profession.StartingHealthAndStamina[BaseStat.SP];

            //TODO initialize Equipment and Inventory

            HP = MaxHP;
            SP = MaxSP;
        }

        public Profession Profession { get; set; }
        public Attributes Attributes { get; set; }
        public Talents Talents { get; set; }

        #region Inventory
        List<Item> IInventory.ItemList { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public void AddItem(Item item)
        {
            throw new NotImplementedException();
        }
        public void RemoveItem(Item item)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Equipment
        Dictionary<string, EquipmentItem> IEquipment.Slots { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Dictionary<string, double> EquipmentModifiers { get; } // TODO: get modifiers from equipment
        bool IEquipment.TwoHanding { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        void IEquipment.EquipItem(EquipmentItem item)
        {
            throw new NotImplementedException();
        }
        void IEquipment.ToggleTwoHanding()
        {
            throw new NotImplementedException();
        }
        void IEquipment.UnequipItem(EquipmentItem item)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
