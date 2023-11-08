using CommunityToolkit.Maui;
using Dienstleistungen_SAP.Pages;
using Dienstleistungen_SAP.Repositorys;
using Dienstleistungen_SAP.ViewModel;
using Dienstleistungen_SAP.Firebase;
using Firebase.Auth;
using Firebase.Auth.Providers;
using Google.Cloud.Firestore;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace Dienstleistungen_SAP
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var adminSDKFilepath = "dienstleistungen-sap-firebase-adminsdk-x0k8o-ae275026dd.json";

            using var reader = new StreamReader(FileSystem.OpenAppPackageFileAsync(adminSDKFilepath).GetAwaiter().GetResult());

            var adminSDKContent = reader.ReadToEnd();

            var firebaseSettings = new FirebaseSettings();

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

            builder.Services.AddTransient<UserRegistrationPage>();
            builder.Services.AddTransient<UserRegistrationViewModel>();

            builder.Services.AddTransient<UserLoginPage>();
            builder.Services.AddTransient<UserLoginViewModel>();

            var firebaseAuthClient = new FirebaseAuthClient(new FirebaseAuthConfig()
            {
                ApiKey = firebaseSettings.ApiKey,
                AuthDomain = firebaseSettings.AuthDomain,
                Providers = new FirebaseAuthProvider[]
                {
                    new EmailProvider()
                }
            });
            builder.Services.AddSingleton(new UserAuthentification(firebaseAuthClient));




            var firestoreProvider = new FirestoreProvider(new FirestoreDbBuilder
            {
                ProjectId = firebaseSettings.ProjectId,
                JsonCredentials = adminSDKContent
            }.Build());


            builder.Services.AddSingleton(new ServiceRepository(firestoreProvider));
            builder.Services.AddSingleton(new UserRepository(firestoreProvider));


#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}