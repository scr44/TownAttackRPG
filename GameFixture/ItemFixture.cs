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

        [TestInitialize]
        public void Create_items()
        {
            TestItem = ItemDAO.GetItem(ItemCatalog.TestItem);
        }

        [TestMethod]
        public void Item_has_correct_description_properties()
        {
            
        }
    }
}
