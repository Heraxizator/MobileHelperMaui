using MobileHelper.Models.Items;
using MobileHelper.Models.Tables;
using MobileHelper.ViewModels.ConstructorViewModels;
using MobileHelperMaui.Helpers;
using MobileHelperMaui.Services;
using MobileHelperMaui.Services.DataStores;
using MobileHelperMaui.Views.TechniquePages.ConstructorPages;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MobileHelper.ViewModels.TechniqueViewModels
{
    public class TechniquesViewModel : BaseViewModel
    {
        public ObservableCollection<TechniqueItem> Techniques { get; set; }
        public ICommand ConstructorTapped { get; set; }

        public TechniquesViewModel(INavigation navigation)
        {
            this.Title = "Список техник";

            this.Navigation = navigation;

            this.Techniques = new ObservableCollection<TechniqueItem>();

            this.ConstructorTapped = new Command((object obj) => this.Navigation.PushAsync(new DesignerPage(-1), false));

            InitAsync();

            SetObservers();

            QuotsHandler.InitQuotsAsync();
        }

        public TechniquesViewModel()
        {

        }

        public async void InitAsync()
        {
            IEnumerable<TechniqueItem> source = TechniquesDataStore.GetStaticTechniques(this.Navigation);

            foreach (TechniqueItem item in source)
            {
                this.Techniques.Add(item);
            }

            IList<TechniqueDB> list = await DBRepository.GetTechniques();

            foreach (TechniqueDB item in list)
            {
                this.Techniques.Add(ParseFromDB(item));
            }
        }

        private void SetObservers()
        {
            MessagingCenter.Subscribe<object, TechniqueDB>(this, "add", (sender, item) => this.Techniques.Add(ParseFromDB(item)));

            MessagingCenter.Subscribe<object, TechniqueDB>(this, "remove", (sender, item) =>
            {
                this.Techniques.Clear();

                InitAsync();
            });

            MessagingCenter.Subscribe<object, TechniqueDB>(this, "change", (sender, item) =>
            {
                this.Techniques.Clear();

                InitAsync();
            });
        }

        private TechniqueItem ParseFromDB(TechniqueDB item)
        {
            return new TechniqueItem
            {
                Id = item.Id,
                Number = "Техника №" + (this.Techniques.Count + 1),
                Date = item.Date,
                Image = item.Image,
                Title = item.Title,
                Subtitle = item.Subtitle,
                Theme = item.Theme,
                Author = item.Author,
                Active = !item.Removed,
                TapCommand = new Command(
                    async () => await this.Navigation.PushAsync(new CreatedPage(item.Id), false))
            };
        }

    }
}