using CommunityToolkit.Maui;

namespace ASMBApp
{
    public static class MauiProgram
    {
   
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder.UseMauiCommunityToolkit()
                .UseMauiApp<App>()                
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
            //ViewModels.VMlc.Services = builder.Services;
            //     Services = builder.Services;
            ViewModels.VMlc.Registrar(builder.Services);
            return builder.Build();
        }
    }
}