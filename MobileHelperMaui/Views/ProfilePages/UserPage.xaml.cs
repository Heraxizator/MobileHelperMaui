using MobileHelper.ViewModels.ProfileViewModels;

namespace MobileHelperMaui.Views.ProfilePages;

public partial class UserPage : ContentPage
{
	public UserPage()
	{
		InitializeComponent();

        this.BindingContext = new UserViewModel(this.Navigation);
    }
}