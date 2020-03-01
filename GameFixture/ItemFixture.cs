using Game.Constants;
using Game.DAL.Interfaces;
using Game.DAL.Mocks;
using Game.Objects.Items;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fixtures
{
    [TestClass]
    public class ItemFixture
    {
        IItemDAO ItemDAO { get; set; } = new MockItemDAO();
        Item TestItem { get; set; }

        [TestInitialize]
        public void Create_items()
        {
            TestItem = ItemDAO.CreateItem(ItemNames.TestItem);
        }

        [TestMethod]
        public void Item_has_correct_description_properties()
        {
            
        }
    }
}
