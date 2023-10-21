using CommunityToolkit.Maui.Core.Extensions;
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

    public ServiceOffersViewModel()
    {
        serviceRepository = ServiceRepository.getInstance();
        services = serviceRepository.getAll().Where(service => service.Type.Equals(Service.ServiceType.Offer)).ToObservableCollection();
    }

    [RelayCommand]
    async Task ShowService(int serviceId)
    {
        await Shell.Current.GoToAsync($"{nameof(ServiceDetailsPage)}?Id={serviceId}");
    }

    [RelayCommand]
    async Task AddService()
    {
        await Shell.Current.GoToAsync(nameof(AddServicePage));
    }

}
