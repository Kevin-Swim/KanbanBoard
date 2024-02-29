using KanbanBoard.ViewModel;

namespace KanbanBoard.View;

public partial class AddProjectPage : ContentPage
{
	public AddProjectPage(AddProjectPageViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}