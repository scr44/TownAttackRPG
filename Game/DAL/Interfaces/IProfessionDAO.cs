using Game.Objects.Items;
using Game.Objects.Professions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game.DAL.Interfaces
{
    public interface IProfessionDAO
    {
        public Profession GetProfession(string title);
    }
}
