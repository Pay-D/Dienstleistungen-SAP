using CommunityToolkit.Maui;
using Dienstleistungen_SAP.Pages;
using Dienstleistungen_SAP.ViewModel;
using Microsoft.Extensions.Logging;

namespace Dienstleistungen_SAP
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<MainViewModel>();

            builder.Services.AddTransient<MyServicesPage>();
            builder.Services.AddTransient<MyServicesViewModel>();

            builder.Services.AddTransient<ServiceOffersPage>();
            builder.Services.AddTransient<ServiceOffersViewModel>();

            builder.Services.AddTransient<ServiceRequestsPage>();
            builder.Services.AddTransient<ServiceRequestsViewModel>();

            builder.Services.AddTransient<ServiceDetailsPage>();
            builder.Services.AddTransient<ServiceDetailsViewModel>();

            builder.Services.AddTransient<AddServicePage>();
            builder.Services.AddTransient<AddServiceViewModel>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}