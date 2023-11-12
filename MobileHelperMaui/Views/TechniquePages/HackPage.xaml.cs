using MobileHelper.ViewModels.TechniqueViewModels;

namespace MobileHelperMaui.Views.TechniquePages;

public partial class HackPage : ContentPage
{
    public HackPage()
    {
        InitializeComponent();

        this.BindingContext = new HackViewModel(this.Navigation);
    }
}