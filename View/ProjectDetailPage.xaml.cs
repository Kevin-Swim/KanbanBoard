using KanbanBoard.ViewModel;

namespace KanbanBoard.View;

public partial class ProjectDetailPage : ContentPage
{
	public ProjectDetailPage(ProjectsViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}