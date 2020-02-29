using Game.DAL.Interfaces;
using Game.DAL.Mocks;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Objects.Items
{
    public class Item
    {
        protected IItemDAO ItemDAO { get; }
        public Item(string id)
        {
            ItemDAO = new MockItemDAO();
            //TODO: Dependency injection

            Name = ItemDAO.getName(id);
            Description = ItemDAO.getDescription(id);
            Value = ItemDAO.getValue(id);
            Weight = ItemDAO.getWeight(id);
            Tags = ItemDAO.getTags(id);
        }

        public string Name { get; }
        public string Description { get; }
        public int Value { get; }
        public double Weight { get; }
        public List<string> Tags { get; set; }
    }
}
