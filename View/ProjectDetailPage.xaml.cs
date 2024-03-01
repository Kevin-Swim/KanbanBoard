using KanbanBoard.Models;
using KanbanBoard.ViewModel;
using System.Collections.ObjectModel;

namespace KanbanBoard.View;

public partial class ProjectDetailPage : ContentPage
{
	
	public ProjectDetailPage(ProjectsViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
		
	}
}