using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using KanbanBoard.Models;
using KanbanBoard.Services;

namespace KanbanBoard.ViewModel
{
    public partial class AddProjectPageViewModel : BaseViewModel
    {

        DataService d = new();

        [ObservableProperty]
        string projName;

        [ObservableProperty]
        string projDescription;


        [RelayCommand]
        public async Task AddProject()
        {

            if(ProjName != null && ProjDescription != null)
            {
                Project proj = new() { Name = ProjName, Description = ProjDescription };

                await proj.Save();

                await Shell.Current.GoToAsync("..");

                ProjName = "";
                ProjDescription = "";
            }
            else
            {
                await Shell.Current.DisplayAlert("Error", "Please ensure all fields are completed", "Ok");
            }
        }
    }
}
