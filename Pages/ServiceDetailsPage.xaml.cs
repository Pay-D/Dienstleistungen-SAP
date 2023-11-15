using Dienstleistungen_SAP.ViewModel;

namespace Dienstleistungen_SAP.Pages;

public partial class ServiceDetailsPage : ContentPage
{
	public ServiceDetailsPage(ServiceDetailsViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
    }
}