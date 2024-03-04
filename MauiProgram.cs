using KanbanBoard.Services;
using KanbanBoard.View;
using KanbanBoard.ViewModel;
using Microsoft.Extensions.Logging;

namespace KanbanBoard
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();

            #region Services

            builder.Services.AddSingleton<DataService>();

            #endregion

            #region Pages

            builder.Services.AddTransient<ProjectDetailPage>();
            builder.Services.AddTransient<CardDetailPage>();

            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<AddProjectPage>();
            builder.Services.AddSingleton<AddCardPage>();
            #endregion

            #region ViewModels

            builder.Services.AddTransient<ProjectsViewModel>();
            builder.Services.AddTransient<CardDetailsViewModel>();

            builder.Services.AddSingleton<WorkspaceViewModel>();
            builder.Services.AddSingleton<AddProjectPageViewModel>();
            builder.Services.AddSingleton<AddCardViewModel>();

            #endregion
#endif

            return builder.Build();
        }
    }
}
