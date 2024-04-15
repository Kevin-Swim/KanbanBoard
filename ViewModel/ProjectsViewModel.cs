

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using KanbanBoard.Models;
using KanbanBoard.Services;
using KanbanBoard.View;
using System.Collections.ObjectModel;

namespace KanbanBoard.ViewModel
{
    [QueryProperty("Project", "Project")]
    public partial class ProjectsViewModel : BaseViewModel
    {

        DataService d = new();

        [ObservableProperty]
        Project project;

        private int id = 0;
        public ObservableCollection<Card> BackLogCards { get; } = [];
        public ObservableCollection<Card> InprogressCards { get; } = [];
        public ObservableCollection<Card> CompletedCards { get; } = [];
        public ObservableCollection<Card> QuestionCards { get; } = [];
        public ObservableCollection<Card> OnHoldCards { get; } = [];
        public ObservableCollection<Card> UpNextCards { get; } = [];

        public ProjectsViewModel()
        {

        }

        partial void OnProjectChanged(Project oldValue, Project newValue)
        {
            id = newValue.Id;
        }


        [RelayCommand]
        async Task LoadCards()
        {
            BackLogCards.Clear();
            foreach (Card c in await d.GetAllAsync<Card>())
            {
                if (c.ProjectId == id)
                {
                    if (c.Type == "BackLog")
                    {
                        BackLogCards.Add(c);
                    }
                }
            }
        }

        [RelayCommand]
        async Task GoToAddCardAsync(Project proj)
        {
            await Shell.Current.GoToAsync($"{nameof(AddCardPage)}", true,
                new Dictionary<string, object>
                {
                    { "Project", proj }
                });
        }

        [RelayCommand]
        async Task GoToCardDetail(Card card)
        {
            if (card is null)
            {
                return;
            }
            await Shell.Current.GoToAsync($"{nameof(CardDetailPage)}", true,
                new Dictionary<string, object>
                {
                    { "Card", card }
                });
        }



    }
}


