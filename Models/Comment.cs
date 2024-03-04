
using SQLite;

namespace KanbanBoard.Models
{
    public class Comment
    {

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Description { get; set; }
        public int ParentCardId { get; set; }
    }
}
