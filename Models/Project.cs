
using SQLite;
using System.Runtime.InteropServices;

namespace KanbanBoard.Models
{
    public class Project
    {

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

    }
}
