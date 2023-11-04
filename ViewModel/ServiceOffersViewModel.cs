using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Dienstleistungen_SAP.DataModels;
using Dienstleistungen_SAP.Pages;
using Dienstleistungen_SAP.Repositorys;
using System.Collections.ObjectModel;

namespace Dienstleistungen_SAP.ViewModel;

public partial class ServiceOffersViewModel: ObservableObject
{

    [ObservableProperty]
    ObservableCollection<Service> services;

    private ServiceRepository serviceRepository;

    public ServiceOffersViewModel(ServiceRepository serviceRepository)
    {
        this.serviceRepository = serviceRepository;
        services = serviceRepository.getByServiceType(Service.ServiceType.Offer);
    }

    [RelayCommand]
    async Task ShowService(int serviceId)
    {
        await Shell.Current.GoToAsync($"{nameof(ServiceDetailsPage)}", new Dictionary<string, object> { { "Service", serviceRepository.getById(serviceId) } });
    }

}
