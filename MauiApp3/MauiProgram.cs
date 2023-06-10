using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;

namespace MauiApp3
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                //.RegisterBlazorMauiWebView()
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
		builder.Logging.AddDebug();
#endif
           ASMB.ViewModels.VMlc.Registrar(builder.Services);
            //builder.Services.AddBlazorWebView();
            return builder.Build();
        }
    }
}