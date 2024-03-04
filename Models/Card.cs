
using KanbanBoard.Services;
using SQLite;

namespace KanbanBoard.Models
{
    public class Card
    {
        DataService d = new();

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public int ProjectId { get; set; }

        public async Task Save()
        {
            await d.AddItemAsync(this);
        }

        public async Task Delete()
        {
            await d.DeleteItemAsync(this);
        }

        public async Task Update()
        {
            await d.UpdateItemAsync(this);
        }
    }
}
