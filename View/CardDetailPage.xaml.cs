using KanbanBoard.ViewModel;

namespace KanbanBoard.View;

public partial class CardDetailPage : ContentPage
{
	public CardDetailPage(CardDetailsViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}