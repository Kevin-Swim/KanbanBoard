
using CommunityToolkit.Mvvm.ComponentModel;
using KanbanBoard.Models;
using System.Collections.ObjectModel;

namespace KanbanBoard.ViewModel
{
    [QueryProperty("Card", "Card")]
    public partial class CardDetailsViewModel : BaseViewModel
    {
        [ObservableProperty]
        string name;
        [ObservableProperty]
        string description;

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
        public void LoadComments() 
        { 
            Comments.Clear();

            Comment c = new Comment()
            {
                Description = "This is a test Comment",
                ParentCardId = id,

            };

            Comments.Add(c);
        }

    }
}
