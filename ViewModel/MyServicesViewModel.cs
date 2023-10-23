using CommunityToolkit.Maui.Core.Extensions;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Dienstleistungen_SAP.DataModels;
using Dienstleistungen_SAP.Pages;
using Dienstleistungen_SAP.Repositorys;
using System.Collections.ObjectModel;

namespace Dienstleistungen_SAP.ViewModel;

public partial class MyServicesViewModel: ObservableObject
{

    [ObservableProperty]
    ObservableCollection<Service> services;

    private ServiceRepository serviceRepository;

    private UserAuthentification userAuthentification;

    public MyServicesViewModel()
    {
        userAuthentification = UserAuthentification.getInstance();
        serviceRepository = ServiceRepository.getInstance();
        services = serviceRepository.getByUserId(userAuthentification.GetCurrentUserId());
    }


    [RelayCommand]
    async Task ShowService(int serviceId)
    {
        await Shell.Current.GoToAsync($"{nameof(ServiceDetailsPage)}",new Dictionary<string,object> { { "Service", serviceRepository.getById(serviceId) } });
    }

    [RelayCommand]
    async Task AddService()
    {
        await Shell.Current.GoToAsync(nameof(AddServicePage));
    }

}
