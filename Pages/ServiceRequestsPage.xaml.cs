using Dienstleistungen_SAP.ViewModel;

namespace Dienstleistungen_SAP.Pages;

public partial class ServiceRequestsPage : ContentPage
{
	public ServiceRequestsPage(ServiceRequestsViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
    }
    private void Back_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("..");
    }
}