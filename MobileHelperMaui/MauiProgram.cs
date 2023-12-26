using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using MobileHelperMaui.Application;
using MobileHelperMaui.Infrastructure;

namespace MobileHelperMaui
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            MauiAppBuilder builder = MauiApp.CreateBuilder();
            MauiAppBuilder mauiAppBuilder = builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                })
                .ConfigureMauiHandlers(handlers => handlers.AddHandler(typeof(Shell), typeof(MobileHelperMaui.Platforms.CustomShellRenderer)));

            Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping(nameof(Entry), (handler, view) => handler.PlatformView.SetBackgroundColor(Android.Graphics.Color.Transparent));

            Microsoft.Maui.Handlers.EditorHandler.Mapper.AppendToMapping(nameof(Editor), (handler, view) => handler.PlatformView.SetBackgroundColor(Android.Graphics.Color.Transparent));

#if DEBUG
            builder.Logging.AddDebug();
#endif

            builder.Services
                .AddApplication()
                .AddInfrastructure();

            return builder.Build();
        }
    }
}