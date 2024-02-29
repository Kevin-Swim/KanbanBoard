using System.Collections.ObjectModel;
using KanbanBoard.Models;
using KanbanBoard.ViewModel;


namespace KanbanBoard.View;

public partial class MainPage : ContentPage
{

	WorkspaceViewModel vm;
	
	public MainPage(WorkspaceViewModel viewModel)
	{
		InitializeComponent();
		vm = viewModel;
		BindingContext = vm;

	}

    protected override async void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
		await vm.GetProjects();
    }



}