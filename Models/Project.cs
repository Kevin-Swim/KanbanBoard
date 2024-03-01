
using KanbanBoard.Services;
using SQLite;
using System.Runtime.InteropServices;

namespace KanbanBoard.Models
{
    public class Project
    {

        DataService d = new DataService();

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public async Task Delete()
        {
            await d.DeleteItemAsync(this);
        }

        public async Task Save()
        {
            await d.AddItemAsync(this);
        }

    }
}
