using MobileHelper.ViewModels.PhysicsViewModels;

namespace MobileHelperMaui.Views.PhysicsPages;

public partial class PhysicsSerchPage : ContentPage
{
    PhysicsSearchViewModel ViewModel { get; set; }
    public PhysicsSerchPage()
    {
        InitializeComponent();

        BindingContext = new PhysicsSearchViewModel(Navigation);

        ViewModel = BindingContext as PhysicsSearchViewModel;
    }

    private void LocalEntry_TextChanged(object sender, TextChangedEventArgs e)
    {
        var text = e.NewTextValue;

        ViewModel.ExecuteSearch(text);
    }
}