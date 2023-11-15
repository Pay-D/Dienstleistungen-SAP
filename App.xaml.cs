namespace Dienstleistungen_SAP
{
    public partial class App : Application
    {
        public App(UserAuthentification userAuthentification)
        {
            InitializeComponent();

            MainPage = new AppShell(userAuthentification);

            //Application.Current.UserAppTheme = AppTheme.Light;
        }
    }
}