using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using KanbanBoard.Models;
using KanbanBoard.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Project proj = new() { Name = ProjName, Description = ProjDescription };

            await d.AddItemAsync(proj);

            await Shell.Current.GoToAsync("..");
        }
    }
}
