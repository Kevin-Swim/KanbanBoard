
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using KanbanBoard.Models;
using KanbanBoard.Services;
using System.Collections.ObjectModel;

namespace KanbanBoard.ViewModel
{
    [QueryProperty("Card", "Card")]
    public partial class CardDetailsViewModel : BaseViewModel
    {
        DataService d = new();

        [ObservableProperty]
        string name;
        [ObservableProperty]
        string description;

        [ObservableProperty]
        string newcomment;

        [ObservableProperty]    
        Card card;

        int id;

        partial void OnCardChanged(Card value)
        {
            id = value.Id;
        }

        public ObservableCollection<Comment> Comments { get; } =  [];

        public CardDetailsViewModel()
        {
            LoadComments();
        }
        public async Task LoadComments() 
        { 
            Comments.Clear();

            foreach(Comment c in await d.GetAllAsync<Comment>())
            {
                if(c.ParentCardId == id) Comments.Add(c);
            }
        }

        [RelayCommand]
        async Task AddComment()
        {
            Comment c = new Comment();
            c.ParentCardId = id;
            c.Description = Newcomment;

            Newcomment = "";

            await c.Save();

            await LoadComments();

        }

    }
}
