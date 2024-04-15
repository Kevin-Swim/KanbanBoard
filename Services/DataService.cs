using SQLite;
using System.Linq.Expressions;

namespace KanbanBoard.Services
{
    public class DataService
    {

        private const string DbName = "KanbanBoard.db3";
        private static string DbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, DbName);
        private SQLiteAsyncConnection _connection;
        private SQLiteAsyncConnection Database => (_connection ??= new SQLiteAsyncConnection(DbPath, SQLiteOpenFlags.Create | SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.SharedCache));

        public async Task<IEnumerable<TTable>> GetAllAsync<TTable>() where TTable : class, new()
        {

            await Database.CreateTableAsync<TTable>();
            return await Database.Table<TTable>().ToListAsync();
        }

        public async Task<IEnumerable<TTable>> GetFilteredAsync<TTable>(Expression<Func<TTable, bool>> predicate) where TTable : class, new()
        {
            await Database.CreateTableAsync<TTable>();
            return await Database.Table<TTable>().Where(predicate).ToListAsync();
        }

        public async Task<TTable> GetItemByIdAsync<TTable>(object primarykey) where TTable : class, new()
        {
            await Database.CreateTableAsync<TTable>();
            return await Database.GetAsync<TTable>(primarykey);
        }

        public async Task<bool> AddItemAsync<TTable>(TTable item) where TTable : class, new()
        {
            await Database.CreateTableAsync<TTable>();
            return await Database.InsertAsync(item) > 0;
        }

        public async Task<bool> UpdateItemAsync<TTable>(TTable item) where TTable : class, new()
        {
            await Database.CreateTableAsync<TTable>();
            return await Database.UpdateAsync(item) > 0;
        }

        public async Task<bool> DeleteItemAsync<TTable>(TTable item) where TTable : class, new()
        {
            await Database.CreateTableAsync<TTable>();
            return await Database.DeleteAsync(item) > 0;
        }
        public async Task<bool> DeleteItemByIDAsync<TTable>(object primarykey) where TTable : class, new()
        {
            await Database.CreateTableAsync<TTable>();
            return await Database.DeleteAsync<TTable>(primarykey) > 0;
        }
    }
}
