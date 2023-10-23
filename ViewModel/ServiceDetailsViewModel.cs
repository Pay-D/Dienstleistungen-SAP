using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Dienstleistungen_SAP.DataModels;

namespace Dienstleistungen_SAP.ViewModel;

[QueryProperty("Service", "Service")]
public partial class ServiceDetailsViewModel: ObservableObject
{
    [ObservableProperty]
    Service service;
}
