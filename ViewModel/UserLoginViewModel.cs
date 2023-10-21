using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Firebase.Auth;

namespace Dienstleistungen_SAP.ViewModel;

public partial class UserLoginViewModel: ObservableObject
{

    private readonly FirebaseAuthClient authClient;

    private UserAuthentification userAuthentification;

    public UserLoginViewModel(FirebaseAuthClient authClient)
    {
        userAuthentification = UserAuthentification.getInstance();
        this.authClient = authClient;
    }


    [ObservableProperty]
    string email;

    [ObservableProperty]
    string password;

    [RelayCommand]
    public async Task Login()
    {
        try
        {
            UserCredential userCredential = await authClient.SignInWithEmailAndPasswordAsync(Email, Password);

            userAuthentification.UserCredential = userCredential;

            await Application.Current.MainPage.DisplayAlert("Authentifizierung", "Authentifizierung war erfolgreich!", "OK");

            await Shell.Current.GoToAsync("..");
        }
        catch (Exception ex)
        {
            await Application.Current.MainPage.DisplayAlert("Es ist ein Fehler aufgetreten!", ex.Message, "OK");
        }
    }
}
