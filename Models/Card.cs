
using SQLite;

namespace KanbanBoard.Models
{
    public class Card
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public List<Comment> Comments { get; set; } = [];
    }
}
