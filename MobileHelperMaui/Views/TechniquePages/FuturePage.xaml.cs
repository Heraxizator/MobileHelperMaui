using MobileHelper.ViewModels.TechniqueViewModels;

namespace MobileHelperMaui.Views.TechniquePages;

public partial class FuturePage : ContentPage
{
    public FuturePage()
    {
        InitializeComponent();

        this.BindingContext = new FutureViewModel(this.Navigation);
    }
}