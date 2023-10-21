using Dienstleistungen_SAP.ViewModel;

namespace Dienstleistungen_SAP
{
    public partial class MainPage : ContentPage
    {

        public MainPage(MainViewModel vm)
        {
            InitializeComponent();
            BindingContext = vm;
        }
    }
}