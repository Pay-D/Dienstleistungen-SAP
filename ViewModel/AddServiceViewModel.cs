using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Dienstleistungen_SAP.DataModels;
using Dienstleistungen_SAP.Repositorys;

namespace Dienstleistungen_SAP.ViewModel;

public partial class AddServiceViewModel: ObservableObject
{
    [ObservableProperty]
    Service service;

    private ServiceRepository serviceRepository;

    private UserAuthentification userAuthentification;

    public AddServiceViewModel()
    {
        userAuthentification = UserAuthentification.getInstance();
        service = new Service();
        serviceRepository = ServiceRepository.getInstance();
    }

    [RelayCommand]
    public async Task AddService()
    {
        Service.Type = Service.ServiceType.Offer;
        Service.CreationDate = DateTime.Now;
        Service.Id = serviceRepository.getAll().Count + 1;
        Service.UserId = userAuthentification.GetCurrentUserId();

        serviceRepository.add(Service);
        await Shell.Current.GoToAsync("../..");
        await Application.Current.MainPage.DisplayAlert("Service", "Service wurde erfolgreich hinzugefügt!", "OK");
    } 

}
