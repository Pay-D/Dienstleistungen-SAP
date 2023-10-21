using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Dienstleistungen_SAP.DataModels;
using Dienstleistungen_SAP.Pages;
using System.Collections.ObjectModel;

namespace Dienstleistungen_SAP.ViewModel;

public partial class MainViewModel: ObservableObject
{

    [ObservableProperty]
    ObservableCollection<Service> services;

    public MainViewModel()
    {
        services = new ObservableCollection<Service>
       {
           new Service() { Id=1, Title = "Test1", CreationDate = DateTime.Now, Description = "Test1Desc", Plz="99999"},
           new Service() { Id=2, Title = "Test2", CreationDate = DateTime.Now, Description = "Test2Desc", Plz="99999"},
           new Service() { Id=3, Title = "Test3", CreationDate = DateTime.Now, Description = "Test3Desc", Plz="99999"},
           new Service() { Id=4, Title = "Test4", CreationDate = DateTime.Now, Description = "Test4Desc", Plz="99999"}
       };

    }


    [RelayCommand]
    async Task AddService()
    {
        await Shell.Current.GoToAsync(nameof(AddServicePage));
    }

    [RelayCommand]
    async Task ShowService(int serviceId)
    {
        await Shell.Current.GoToAsync($"{nameof(ServiceDetailsPage)}?Id={serviceId}");
    }



}
