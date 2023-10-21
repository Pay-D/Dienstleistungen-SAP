using Dienstleistungen_SAP.ViewModel;

namespace Dienstleistungen_SAP.Pages;

public partial class UserLoginPage : ContentPage
{
	public UserLoginPage(UserLoginViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}