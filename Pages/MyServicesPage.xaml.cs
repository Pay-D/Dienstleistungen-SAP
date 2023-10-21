using Dienstleistungen_SAP.ViewModel;

namespace Dienstleistungen_SAP.Pages;

public partial class MyServicesPage : ContentPage
{
	public MyServicesPage(MyServicesViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
    }
}