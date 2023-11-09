using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Dienstleistungen_SAP.Pages;
using Firebase.Auth;

namespace Dienstleistungen_SAP.ViewModel;

public partial class UserLoginViewModel: ObservableObject
{
    private readonly UserAuthentification userAuthentification;

    public UserLoginViewModel(UserAuthentification userAuthentification)
    {
        this.userAuthentification = userAuthentification;
    }

    [ObservableProperty]
    string email;

    [ObservableProperty]
    string password;

    [RelayCommand]
    public async Task Login()
    {
       await userAuthentification.Login(Email, Password);
    }

    [RelayCommand]
    public async Task RedirectToRegistrationPage()
    {
        await Shell.Current.GoToAsync(nameof(UserRegistrationPage));
    }
}
