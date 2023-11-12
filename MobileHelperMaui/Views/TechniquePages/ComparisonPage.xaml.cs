using MobileHelper.ViewModels.TechniqueViewModels;

namespace MobileHelperMaui.Views.TechniquePages;

public partial class ComparisonPage : ContentPage
{
	public ComparisonPage()
	{
		InitializeComponent();

		this.BindingContext = new ComparisonViewModel(this.Navigation);
	}
}