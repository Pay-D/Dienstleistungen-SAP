using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Firebase.Auth;

namespace Dienstleistungen_SAP.ViewModel;

public partial class UserRegistrationViewModel: ObservableObject
{
    private readonly FirebaseAuthClient authClient;

    public UserRegistrationViewModel(FirebaseAuthClient authClient)
    {
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

            await authClient.CreateUserWithEmailAndPasswordAsync(Email, Password);
            await Application.Current.MainPage.DisplayAlert("Registration", "Registration erfolgreich", "OK");
        }
        catch (Exception ex)
        {
            await Application.Current.MainPage.DisplayAlert("Fehler während Registration", ex.Message,"OK");
        }
    }
}
