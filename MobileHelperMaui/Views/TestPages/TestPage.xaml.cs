using MobileHelper.ViewModels.TestViewModels;

namespace MobileHelperMaui.Views.TestPages;

public partial class TestPage : ContentPage
{
	public TestPage()
	{
		InitializeComponent();

		this.BindingContext = new TestViewModel(this.Navigation);
	}
}