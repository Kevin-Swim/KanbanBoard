

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using KanbanBoard.Models;
using KanbanBoard.Services;
using System.Collections.ObjectModel;

namespace KanbanBoard.ViewModel
{
    [QueryProperty("Project", "Project")]
    public partial class ProjectsViewModel : BaseViewModel
    {

        DataService d = new();

        [ObservableProperty]
        Project project;


        public ObservableCollection<Card> BackLogCards { get; } = [];

        public ProjectsViewModel() 
        {
            loadCards();
        }

        private async Task loadCards()
        {
            foreach (Card c in await d.GetAllAsync<Card>())
            {
                if(c.Type == "BackLog")
                {
                    BackLogCards.Add(c);
                }
            }
        }

        [RelayCommand]
        private void AddCardButton()
        {

        }

    }
}
