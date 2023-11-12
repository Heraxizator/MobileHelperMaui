using MobileHelper.Models.DataItems;
using MobileHelperMaui.ViewModels.TechniqueViewModels;

namespace MobileHelperMaui.Views.TechniquePages;

public partial class PaperPage : ContentPage
{
    public PaperPage()
    {

        InitializeComponent();
        BindingContext = new PaperViewModel(Navigation);
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        var vm = BindingContext as PaperViewModel;

        Papers.ScrollTo(vm.Paper, ScrollToPosition.MakeVisible, true);
    }

    private void ImageButton_Clicked(object sender, EventArgs e)
    {
        var button = sender as ImageButton;

        var item = button.BindingContext as Paper;

        var vm = BindingContext as PaperViewModel;

        vm.Delete.Execute(item);
    }
}