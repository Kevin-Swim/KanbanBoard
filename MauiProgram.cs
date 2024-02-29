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

            builder.Services.AddSingleton<DataService>();

            builder.Services.AddTransient<ProjectDetailPage>();
            builder.Services.AddTransient<ProjectsViewModel>();

            builder.Services.AddSingleton<WorkspaceViewModel>();
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<AddProjectPageViewModel>();
            builder.Services.AddSingleton<AddProjectPage>();
#endif  

            return builder.Build();
        }
    }
}
