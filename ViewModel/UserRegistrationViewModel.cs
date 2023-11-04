using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Firebase.Auth;

namespace Dienstleistungen_SAP.ViewModel;

public partial class UserRegistrationViewModel: ObservableObject
{
    private readonly UserAuthentification userAuthentification;

    public UserRegistrationViewModel(UserAuthentification userAuthentification)
    {
        this.userAuthentification = userAuthentification;
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
        await userAuthentification.Register(Email, Password, PasswordRepeat);
    }
}
