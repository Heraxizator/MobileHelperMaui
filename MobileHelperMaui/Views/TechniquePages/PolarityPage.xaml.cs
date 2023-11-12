using MobileHelper.Models.Items;
using MobileHelper.ViewModels.TechniqueViewModels;

namespace MobileHelperMaui.Views.TechniquePages;

public partial class PolarityPage : ContentPage
{
    public PolarityPage()
    {
        InitializeComponent();
        this.BindingContext = new PolarityViewModel(this.Navigation);
    }

    private void ImageButton_Clicked(object sender, EventArgs e)
    {
        ImageButton button = sender as ImageButton;

        Polarity item = button.BindingContext as Polarity;

        PolarityViewModel vm = this.BindingContext as PolarityViewModel;

        vm.Delete.Execute(item);
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        PolarityViewModel vm = this.BindingContext as PolarityViewModel;

        this.Polarities.ScrollTo(vm.Polarity, ScrollToPosition.MakeVisible, true);
    }
}