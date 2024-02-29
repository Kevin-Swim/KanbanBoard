﻿using CommunityToolkit.Mvvm.ComponentModel;

namespace KanbanBoard.ViewModel
{

    public partial class BaseViewModel : ObservableObject
    {

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(IsNotBusy))]
        bool isBusy;

        [ObservableProperty]
        string title;

        public bool IsNotBusy => !IsBusy;


    }

    
}
