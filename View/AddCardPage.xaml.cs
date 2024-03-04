using KanbanBoard.ViewModel;

namespace KanbanBoard.View;

public partial class AddCardPage : ContentPage
{
	public AddCardPage(AddCardViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}