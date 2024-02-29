
using CommunityToolkit.Mvvm.Input;
using KanbanBoard.Models;
using KanbanBoard.Services;
using KanbanBoard.View;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace KanbanBoard.ViewModel
{
    public partial class WorkspaceViewModel : BaseViewModel
    {
        public ObservableCollection<Project> Projects { get; } = [];

        DataService d;
        public WorkspaceViewModel( DataService dataservice) {
            this.d = dataservice;
            GetProjects();
        }

        [RelayCommand]
         public async Task GetProjects()
        {
           if(IsBusy) return;

            try
            {
                IsBusy = true;
                Projects.Clear();
                foreach(Project proj in await d.GetAllAsync<Project>())
                {
                    Projects.Add(proj);
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex);
                await Shell.Current.DisplayAlert("Error!", "Unable to pull projects", "Okay");
            }
            finally
            {
                IsBusy = false;
            }

        }

        [RelayCommand]
        async Task GotoAddPageAsync()
        {
            await Shell.Current.GoToAsync($"{nameof(AddProjectPage)}", true);
        }

        [RelayCommand]
        async Task GoToProjectPage(Project proj)
        {
            if(proj is null)
                {
                    return;
                }

            await Shell.Current.GoToAsync($"{nameof(ProjectDetailPage)}",true,
                new Dictionary<string, object>
                {
                    { "Project", proj }
                });
        }
    }
}
