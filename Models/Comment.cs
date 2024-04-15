
using KanbanBoard.Services;
using SQLite;

namespace KanbanBoard.Models
{
    public class Comment
    {
        DataService d = new DataService();

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Description { get; set; }
        public int ParentCardId { get; set; }

        public async Task Save()
        {
            await d.AddItemAsync(this);
        }
    }
}
