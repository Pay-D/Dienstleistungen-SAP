using Dienstleistungen_SAP.ViewModel;

namespace Dienstleistungen_SAP.Pages;

public partial class AddServicePage : ContentPage
{
	public AddServicePage(AddServiceViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}