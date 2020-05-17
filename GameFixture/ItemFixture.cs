using System;
using System.Collections.Generic;
using System.Text;
using GameCore.Constants;
using GameCore.DAL.Interfaces;
using GameCore.DAL.Json;
using GameCore.Objects.Items;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ItemFixture
{
    [TestClass]
    public class Equipment
    {
        IItemDAO ItemDAO = new JsonItemDAO();
        EquipmentItem Longsword;

        [TestInitialize]
        public void Generate_equipment()
        {
            Longsword = ItemDAO.GenerateNewEquipmentItem(EquipmentCatalog.Hands.Longsword);
        }

        [TestMethod]
        public void Retrieves_correct_item()
        {
            Assert.AreEqual(EquipmentCatalog.Hands.Longsword, Longsword.IdName);
        }
    }
}
