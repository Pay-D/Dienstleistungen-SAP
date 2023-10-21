using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Firebase.Auth;

namespace Dienstleistungen_SAP.ViewModel;

public partial class UserRegistrationViewModel: ObservableObject
{
    private readonly FirebaseAuthClient authClient;

    private UserAuthentification userAuthentification;

    public UserRegistrationViewModel(FirebaseAuthClient authClient)
    {
        userAuthentification = UserAuthentification.getInstance();
        this.authClient = authClient;
    }


    [ObservableProperty]
    string email;

    [ObservableProperty]
    string password;

    [ObservableProperty]
    string passwordRepeat;

    [RelayCommand]
    public async Task Register()
    {
        try {             
            if (Password != PasswordRepeat)
            {
                throw new Exception("Passwörter stimmen nicht überein");
            }

            UserCredential userCredential = await authClient.CreateUserWithEmailAndPasswordAsync(Email, Password);

            await authClient.SignInWithEmailAndPasswordAsync(Email, Password);

            userAuthentification.UserCredential = userCredential;

            await Application.Current.MainPage.DisplayAlert("Registration", "Registration war erfolgreich!", "OK");

            await Shell.Current.GoToAsync("..");
        }
        catch (Exception ex)
        {
            await Application.Current.MainPage.DisplayAlert("Es ist ein Fehler aufgetreten!", ex.Message,"OK");
        }
    }
}
