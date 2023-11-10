using CommunityToolkit.Mvvm.ComponentModel;
using Dienstleistungen_SAP.DataModels;
using Dienstleistungen_SAP.Firebase;
using Dienstleistungen_SAP.Pages;
using Dienstleistungen_SAP.Repositorys;
using Firebase.Auth;

namespace Dienstleistungen_SAP;

public partial class UserAuthentification: ObservableObject
{
    [ObservableProperty]
    bool isAuthentificated;

    public DataModels.User CurrentUser { get; set; }

    private readonly FirebaseAuthClient authClient;

    private readonly FirestoreProvider firestoreProvider;

    private readonly UserRepository userRepository;

    public UserAuthentification(FirebaseAuthClient authClient,FirestoreProvider firestoreProvider, UserRepository userRepository)
    {
        IsAuthentificated = false;
        this.authClient = authClient;
        this.firestoreProvider = firestoreProvider;
        this.userRepository = userRepository;
    }

    private UserCredential UserCredential { get; set; }


    public string GetCurrentUserId()
    {
        return UserCredential.User.Uid;
    }

    public async Task Login(string email, string password)
    {
        try
        {
            UserCredential = await authClient.SignInWithEmailAndPasswordAsync(email, password);

            CurrentUser = userRepository.getById(UserCredential.User.Uid); 

            IsAuthentificated = true;

            await Application.Current.MainPage.DisplayAlert("Authentifizierung", "Authentifizierung war erfolgreich!", "OK");

            await Shell.Current.GoToAsync("///" + nameof(MainPage));
        }
        catch (Exception ex)
        {
            await Application.Current.MainPage.DisplayAlert("Es ist ein Fehler aufgetreten!", ex.Message, "OK");
        }
    }

    public async Task Register(DataModels.User user, string password, string passwordRepeat)
    {
        try
        {
            if (password != passwordRepeat)
            {
                throw new Exception("Passwörter stimmen nicht überein");
            }

            UserCredential = await authClient.CreateUserWithEmailAndPasswordAsync(user.Email, password);
            
            user.Id = UserCredential.User.Uid;
            userRepository.addOrUpdate(user);
            CurrentUser = user;

            IsAuthentificated = true;

            await Application.Current.MainPage.DisplayAlert("Registration", "Registration war erfolgreich!", "OK");

            await Shell.Current.GoToAsync("///" + nameof(MainPage));
        }
        catch (Exception ex)
        {
            await Application.Current.MainPage.DisplayAlert("Es ist ein Fehler aufgetreten!", ex.Message, "OK");
        }
    }

}
