using KanbanBoard.View;

namespace KanbanBoard
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(ProjectDetailPage), typeof(ProjectDetailPage));
            Routing.RegisterRoute(nameof(AddProjectPage), typeof(AddProjectPage));
            Routing.RegisterRoute(nameof(AddCardPage), typeof(AddCardPage));
            Routing.RegisterRoute(nameof(CardDetailPage), typeof(CardDetailPage));
        }
    }
}
