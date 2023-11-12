using MobileHelperMaui.Views;

namespace MobileHelperMaui
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }
    }
}