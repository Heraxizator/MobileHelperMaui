

namespace MobileHelper.ViewModels.TechniqueViewModels
{
    public class ExperienceViewModel : BaseViewModel
    {

        public ExperienceViewModel()
        {

        }

        public ExperienceViewModel(INavigation navigation)
        {
            this.Title = "Техника";
            this.Navigation = navigation;
            this.Finish = new Command(ToFinish);
            this.Theory = new Command(ToTheory);
            this.Info = "Техника модификации опыта (ТМО) — это эффективный инструмент психологической помощи, позволяющий разобраться как с устоявшимися, так и с недавно появившимися ограничениями, убеждениями, моделями поведения в различных ситуациях. ТМО подходит для самокоучинга. Суть ТМО — позитивное перепроживание ситуаций, давших вам негативный опыт.";
        }

    }
}
