
namespace KanbanBoard.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public Card ParentCard { get; set; }
    }
}
