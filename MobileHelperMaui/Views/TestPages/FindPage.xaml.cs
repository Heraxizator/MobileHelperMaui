using MobileHelper.ViewModels.TestViewModels;

namespace MobileHelperMaui.Views.TestPages;

public partial class FindPage : ContentPage
{
	public FindPage()
	{
		InitializeComponent();

		this.BindingContext = new FindViewModel(this.Navigation);
	}
}