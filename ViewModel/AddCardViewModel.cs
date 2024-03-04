using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using KanbanBoard.Models;
using KanbanBoard.View;

namespace KanbanBoard.ViewModel
{
    [QueryProperty("Project", "Project")]
    public partial class AddCardViewModel : BaseViewModel
    {
        [ObservableProperty]
        string name;

        [ObservableProperty]
        public string description;

        [ObservableProperty]
        Project project;

        Card c= new();
        partial void OnProjectChanged(Project value)
        {
            c.ProjectId = value.Id;
        }

        [RelayCommand]
        public async Task AddCard()
        {
            if( Name != null || Description != null)
            {
                c.Name = this.Name;
                c.Description = this.Description;
                c.Type = "BackLog";

                await c.Save();
                await Shell.Current.GoToAsync("..");

                Name = "";
                Description = "";
            }
            else
            {
                await Shell.Current.DisplayAlert("Error", "Please ensure all fields are completed", "Ok");
            }
        }

    }
}
