using MobileHelper.Models.Items;
using MobileHelper.Models.Tables;
using MobileHelperMaui.Helpers;
using MobileHelperMaui.Services;
using MobileHelperMaui.Services.DataStores;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace MobileHelper.ViewModels.ProfileViewModels
{
    public class UserViewModel : BaseViewModel
    {
        public ObservableCollection<TechniqueItem> Techniques { get; set; }
        public ObservableCollection<Quots> Quots { get; set; }

        public UserViewModel(INavigation navigation)
        {
            this.Title = "Профиль";

            this.Navigation = navigation;

            this.Techniques = new ObservableCollection<TechniqueItem>();

            this.Quots = new ObservableCollection<Quots>();

            InitAsync();
        }

        public UserViewModel() { }

        public async void InitAsync()
        {
            IEnumerable<TechniqueItem> source = TechniquesDataStore.GetStaticTechniques(this.Navigation);

            IEnumerable<TechniqueItem> techniques = ShareDataStore<TechniqueItem>.SelectRandomItems(source.ToList(), 3);

            foreach (TechniqueItem technique in techniques)
            {
                this.Techniques.Add(technique);
            }

            IList<Models.Tables.QuotDB> itemsDB = await DBRepository.GetQuots();

            IList<Quots> items = QuotsHandler.ParseQuots(itemsDB);

            IEnumerable<Quots> qouts = items; //ShareDataStore<Quots>.SelectRandomItems(items, 3);

            foreach (Quots quot in qouts)
            {
                this.Quots.Add(quot);
            }

            if (!qouts.Any())
            {
                IEnumerable<Quots> elems = QuotsDataStore.GetStaticQuots();

                IEnumerable<Quots> quots = ShareDataStore<Quots>.SelectRandomItems(elems.ToList(), 3);

                foreach (Quots quot in quots)
                {
                    this.Quots.Add(quot);
                }
            }
        }
    }
}
