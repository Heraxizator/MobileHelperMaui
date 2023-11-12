using MobileHelper.ViewModels.TechniqueViewModels;
using MobileHelperMaui.Views.ProfilePages;

namespace MobileHelperMaui.Views;

public partial class TechniquesPage : ContentPage
{
    private readonly TechniquesViewModel viewModel;
    public TechniquesPage()
    {
        InitializeComponent();

        this.BindingContext = new TechniquesViewModel(this.Navigation);

        this.viewModel = this.BindingContext as TechniquesViewModel;
    }

    private async void ToolbarItem_Clicked(object sender, EventArgs e)
    {
        await this.Navigation.PushAsync(new UserPage(), false);
    }
}