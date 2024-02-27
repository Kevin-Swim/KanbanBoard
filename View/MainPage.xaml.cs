using System.Collections.ObjectModel;
using KanbanBoard.Models;


namespace KanbanBoard.View;

public partial class MainPage : ContentPage
{

	ObservableCollection<Project> projs = new();
	public MainPage()
	{
		InitializeComponent();
		ProjectsCV.ItemsSource = projs;
		LoadProjects();
	}

	private void LoadProjects()
	{
		//TODO: completed Data Retrevial
		Project p =  new Project() { Name ="Kanban Board", Description="This is a test description" };
        Project p2 = new Project() { Name = "Kanban Board", Description = "This is a test description" };
        projs.Add(p);
        projs.Add(p2);
    }
}