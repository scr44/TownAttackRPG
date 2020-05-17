using GameCore.Objects.Items;
using GameCore.Objects.Professions;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameCore.DAL.Interfaces
{
    public interface IProfessionDAO
    {
        public Profession GetProfession(string title);
    }

    public class InvalidProfessionException : Exception { }
}
