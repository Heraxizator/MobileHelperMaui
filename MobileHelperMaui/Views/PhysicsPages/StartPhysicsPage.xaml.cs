using MobileHelper.ViewModels.PhysicsViewModels;

namespace MobileHelperMaui.Views.PhysicsPages;

public partial class StartPhysicsPage : ContentPage
{
    public StartPhysicsPage()
    {
        InitializeComponent();

        this.BindingContext = new StartPhysicsViewModel(this.Navigation);
    }
}