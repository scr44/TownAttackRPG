using Game.Constants;
using Game.Objects.Items;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameFixture
{
    [TestClass]
    public class ItemFixture
    {
        Item TestItem { get; set; }

        [TestInitialize]
        public void Create_items()
        {
            TestItem = new Item(Items.TestItem);
        }

        [TestMethod]
        public void Item_has_correct_description_properties()
        {
            
        }
    }
}
