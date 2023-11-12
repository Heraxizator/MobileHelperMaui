using MobileHelper.ViewModels.TechniqueViewModels;

namespace MobileHelperMaui.Views.TechniquePages;

public partial class SpinPage : ContentPage
{
    public SpinPage()
    {
        InitializeComponent();

        this.BindingContext = new SpinViewModel(this.Navigation);
    }
}