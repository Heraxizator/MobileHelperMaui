using MobileHelper.ViewModels.TechniqueViewModels;

namespace MobileHelperMaui.Views.TechniquePages;

public partial class ExperiencePage : ContentPage
{
    public ExperiencePage()
    {
        InitializeComponent();

        this.BindingContext = new ExperienceViewModel(this.Navigation);
    }
}