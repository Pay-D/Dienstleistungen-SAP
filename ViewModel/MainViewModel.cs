using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Dienstleistungen_SAP.DataModels;
using Dienstleistungen_SAP.Pages;
using System.Collections.ObjectModel;

namespace Dienstleistungen_SAP.ViewModel;

public partial class MainViewModel: ObservableObject
{

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
        await Shell.Current.GoToAsync(nameof(ServiceOffersPage));
    }

    [RelayCommand]
    async Task ServiceRequests()
    {
        await Shell.Current.GoToAsync(nameof(ServiceRequestsPage));
    }

    [RelayCommand]
    async Task MyServices()
    {
        await Shell.Current.GoToAsync(nameof(MyServicesPage));
    }

}
