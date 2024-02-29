

using CommunityToolkit.Mvvm.ComponentModel;
using KanbanBoard.Models;

namespace KanbanBoard.ViewModel
{
    [QueryProperty("Project", "Project")]
    public partial class ProjectsViewModel : BaseViewModel
    {
        [ObservableProperty]
        Project project;
        public ProjectsViewModel() 
        {
              
        }

    }
}
