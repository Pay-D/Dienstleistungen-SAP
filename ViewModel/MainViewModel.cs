using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Dienstleistungen_SAP.Pages;

namespace Dienstleistungen_SAP.ViewModel;

public partial class MainViewModel: ObservableObject
{
    private UserAuthentification userAuthentification;

    public MainViewModel(UserAuthentification userAuthentification)
    {
        this.userAuthentification = userAuthentification;
    }


    [RelayCommand]
    async Task RegisterUser()
    {
        await Shell.Current.GoToAsync(nameof(UserRegistrationPage));
    }

    [RelayCommand]
    async Task LoginUser()
    {
        await Shell.Current.GoToAsync(nameof(UserLoginPage));
    }

    [RelayCommand]
    async Task ServiceOffers()
    {
        if(!userAuthentification.IsAuthentificated)
        {
            redirectToLoginPage();
            return;
        }
        await Shell.Current.GoToAsync(nameof(ServiceOffersPage));
    }

    [RelayCommand]
    async Task ServiceRequests()
    {
        if (!userAuthentification.IsAuthentificated)
        {
            redirectToLoginPage();
            return;
        }
        await Shell.Current.GoToAsync(nameof(ServiceRequestsPage));
    }

    [RelayCommand]
    async Task MyServices()
    {
        if (!userAuthentification.IsAuthentificated)
        {
            redirectToLoginPage();
            return;
        }
        await Shell.Current.GoToAsync(nameof(MyServicesPage));
    }

    private void redirectToLoginPage()
    {
        Application.Current.MainPage.DisplayAlert("Authentifikation", "Bitte loggen Sie sich erst ein!", "OK");
        Shell.Current.GoToAsync(nameof(UserLoginPage));
    }

}
