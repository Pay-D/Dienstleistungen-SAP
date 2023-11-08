using CommunityToolkit.Mvvm.ComponentModel;
using Firebase.Auth;

namespace Dienstleistungen_SAP;

public partial class UserAuthentification: ObservableObject
{
    [ObservableProperty]
    bool isAuthentificated;

    private readonly FirebaseAuthClient authClient;

    public UserAuthentification(FirebaseAuthClient authClient)
    {
        IsAuthentificated = false;
        this.authClient = authClient;
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

            IsAuthentificated = true;

            await Application.Current.MainPage.DisplayAlert("Authentifizierung", "Authentifizierung war erfolgreich!", "OK");

            await Shell.Current.GoToAsync("..");
        }
        catch (Exception ex)
        {
            await Application.Current.MainPage.DisplayAlert("Es ist ein Fehler aufgetreten!", ex.Message, "OK");
        }
    }

    public async Task Register(string email, string password, string passwordRepeat)
    {
        try
        {
            if (password != passwordRepeat)
            {
                throw new Exception("Passwörter stimmen nicht überein");
            }

            UserCredential = await authClient.CreateUserWithEmailAndPasswordAsync(email, password);

           IsAuthentificated = true;

            await Application.Current.MainPage.DisplayAlert("Registration", "Registration war erfolgreich!", "OK");

            await Shell.Current.GoToAsync("..");
        }
        catch (Exception ex)
        {
            await Application.Current.MainPage.DisplayAlert("Es ist ein Fehler aufgetreten!", ex.Message, "OK");
        }
    }

}
