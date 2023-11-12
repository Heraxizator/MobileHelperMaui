

namespace MobileHelper.ViewModels.TechniqueViewModels
{
    public class ComparisonViewModel : BaseViewModel
    {
        public ComparisonViewModel()
        {

        }

        public ComparisonViewModel(INavigation navigation)
        {
            this.Title = "Техника";
            this.Info = "Основной причиной любого беспокойства является завышенная важность. Поэтому её нужно уметь понижать. Сравнение важностей - один из способов уменьшить значимость того, что тревожит. По сути важность - сопутствуещее любого негатива, включая страх, неверие в себя, завышенную планку, сомнения и другое. Для выполнения этой техники достаточно сравнить то, что было важно в прошлом, важно в настоящем и будет важно в будущем относительно проблемы.";
            this.Finish = new Command(ToFinish);
            this.Theory = new Command(ToTheory);
            this.Navigation = navigation;
        }
    }
}
