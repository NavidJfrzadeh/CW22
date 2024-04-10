using Core.UserEnitiy;

namespace App.Infra.DataBase.MemoryDataBase
{
    public static class InMemoryDatabase
    {
        public static Admin? ActiveAdmin { get; set; }
    }
}
