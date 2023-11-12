using MobileHelperMaui.Views.TestPages;
using System.Windows.Input;

namespace MobileHelper.ViewModels.TestViewModels
{
    public class FindViewModel : BaseViewModel
    {
        public ICommand Continue { get; set; }
        public FindViewModel()
        {

        }

        public FindViewModel(INavigation navigation)
        {
            this.Title = "Детектор";
            this.Navigation = navigation;
            this.Continue = new Command(ToContinue);
        }

        private async void ToContinue(object obj)
        {
            await this.Navigation.PushAsync(new TestPage());
        }
    }
}
