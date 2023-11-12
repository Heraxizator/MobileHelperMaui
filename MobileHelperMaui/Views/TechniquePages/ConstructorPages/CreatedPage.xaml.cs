using MobileHelper.ViewModels.ConstructorViewModels;

namespace MobileHelperMaui.Views.TechniquePages.ConstructorPages;

public partial class CreatedPage : ContentPage
{
    public CreatedPage(int id)
    {
        InitializeComponent();
        this.BindingContext = new CreatedViewModel(this.Navigation, id);
    }
}