using MauiDemonstrationApp.Models;
using SQLite;

namespace MauiDemonstrationApp.Core
{
    public class DatabaseProvider
    {
        public SQLiteAsyncConnection Database { get; private set; }

        public async Task InitAsync()
        {
            if (Database is not null)
                return;

            Database = new SQLiteAsyncConnection(DatabaseConstants.DatabasePath, DatabaseConstants.Flags);

            await Database.CreateTableAsync<Customer>();

            var count = await Database.Table<Customer>().CountAsync();
            if (count <= 0)
            {
                await Database.InsertAllAsync(new List<Customer>
                {
                    new Customer(1, "Maria", "maria@email.com", "https://cdn.pixabay.com/photo/2016/09/01/08/24/smiley-1635449_1280.png"),
                    new Customer(2, "João", "joao@email.com", "https://cdn.pixabay.com/photo/2014/04/03/10/32/businessman-310819_1280.png"),
                    new Customer(3, "Pedro", "pedro@email.com", "https://cdn.pixabay.com/photo/2016/03/10/05/07/wolf-1247882_1280.png")
                });
            }
        }
    }
}
