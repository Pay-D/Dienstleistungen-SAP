using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Dienstleistungen_SAP.ViewModel;

[QueryProperty("Id", "Id")]
public partial class ServiceDetailsViewModel: ObservableObject
{
    [ObservableProperty]
    int id;

    [RelayCommand]
    async Task GoBack()
    {
        await Shell.Current.GoToAsync("..");
    }
}
