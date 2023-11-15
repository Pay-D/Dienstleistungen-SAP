using CommunityToolkit.Mvvm.ComponentModel;
using Dienstleistungen_SAP.Pages;

namespace Dienstleistungen_SAP
{
    public partial class AppShell : Shell
    {
        public UserAuthentification userAuthentification;
        public AppShell(UserAuthentification userAuthentification)
        {
            this.userAuthentification = userAuthentification;
            InitializeComponent();
            registerRoutes();
            BindingContext = userAuthentification;
        }

        private void registerRoutes()
        {
            Routing.RegisterRoute(nameof(UserLoginPage), typeof(UserLoginPage));
            Routing.RegisterRoute(nameof(UserRegistrationPage), typeof(UserRegistrationPage));
            Routing.RegisterRoute(nameof(MyServicesPage), typeof(MyServicesPage));
            Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
            Routing.RegisterRoute(nameof(ServiceOffersPage), typeof(ServiceOffersPage));
            Routing.RegisterRoute(nameof(ServiceRequestsPage), typeof(ServiceRequestsPage));
            Routing.RegisterRoute(nameof(AddServicePage), typeof(AddServicePage));
            Routing.RegisterRoute(nameof(ServiceDetailsPage), typeof(ServiceDetailsPage));
        }
    }
}