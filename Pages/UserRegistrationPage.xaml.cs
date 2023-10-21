using Dienstleistungen_SAP.ViewModel;

namespace Dienstleistungen_SAP.Pages;

public partial class UserRegistrationPage : ContentPage
{
	public UserRegistrationPage(UserRegistrationViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}