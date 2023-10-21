using Dienstleistungen_SAP.ViewModel;

namespace Dienstleistungen_SAP.Pages;

public partial class ServiceOffersPage : ContentPage
{
	public ServiceOffersPage(ServiceOffersViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
    }
}