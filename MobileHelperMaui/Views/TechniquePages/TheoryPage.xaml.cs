using MobileHelper.ViewModels.TechniqueViewModels;

namespace MobileHelperMaui.Views.TechniquePages;

public partial class TheoryPage : ContentPage
{
    public TheoryPage(string content)
    {
        InitializeComponent();

        this.BindingContext = new TheoryViewModel(content);
    }
}