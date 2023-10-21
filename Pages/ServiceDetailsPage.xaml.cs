using Dienstleistungen_SAP.ViewModel;

namespace Dienstleistungen_SAP;

public partial class ServiceDetailsPage : ContentPage
{
	public ServiceDetailsPage(ServiceDetailsViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
    }
}