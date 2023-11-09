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

    public AddServiceViewModel(UserAuthentification userAuthentification, ServiceRepository serviceRepository)
    {
        this.userAuthentification = userAuthentification;
        service = new Service();
        this.serviceRepository = serviceRepository;
    }

    [RelayCommand]
    public async Task AddService()
    {
        Service.CreationDate = DateTime.Now.ToUniversalTime();
        Service.UserId = userAuthentification.GetCurrentUserId();

        serviceRepository.addOrUpdate(Service);
        await Shell.Current.GoToAsync("../..");
        await Application.Current.MainPage.DisplayAlert("Service", "Service wurde erfolgreich hinzugefügt!", "OK");
    } 

}
