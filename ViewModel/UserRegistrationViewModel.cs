using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Dienstleistungen_SAP.DataModels;
using Dienstleistungen_SAP.Pages;
using Firebase.Auth;

namespace Dienstleistungen_SAP.ViewModel;

public partial class UserRegistrationViewModel: ObservableObject
{
    private readonly UserAuthentification userAuthentification;

    public UserRegistrationViewModel(UserAuthentification userAuthentification)
    {
        this.userAuthentification = userAuthentification;
        user = new DataModels.User();
    }


    [ObservableProperty]
    DataModels.User user;

    [ObservableProperty]
    string password;

    [ObservableProperty]
    string passwordRepeat;

    [RelayCommand]
    public async Task Register()
    {
        await userAuthentification.Register(User, Password, PasswordRepeat);
    }

    [RelayCommand]
    public async Task RedirectToLoginPage()
    {
        await Shell.Current.GoToAsync("../");
    }
}
