using System;
using System.Collections.Generic;
using System.Text;
using Game.Constants;
using Game.DAL.Interfaces;
using Game.DAL.Json;
using Game.Objects.Items;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fixtures
{
    [TestClass]
    public class EquipmentFixture
    {
        IItemDAO ItemDAO = new JsonItemDAO();
        EquipmentItem Longsword;

        [TestInitialize]
        public void Generate_equipment()
        {
            Longsword = ItemDAO.GetEquipment(EquipmentCatalog.Hands.Longsword);
        }

        [TestMethod]
        public void Retrieves_correct_item()
        {
            Assert.AreEqual(EquipmentCatalog.Hands.Longsword, Longsword.id);
        }
    }
}
