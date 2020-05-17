using GameCore.DAL.SQLite;

namespace GameCore
{
    class Program
    {
        static void Main(string[] args)
        {
            var dao = new SQLiteDAO();
            var item = dao.GenerateNewEquipmentItem(Constants.EquipmentCatalog.Body.FullPlate);
        }
    }
}
