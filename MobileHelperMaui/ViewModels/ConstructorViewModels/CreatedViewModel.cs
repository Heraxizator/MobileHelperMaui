using MobileHelper.Models.DataItems;
using MobileHelper.Models.Items.Items;
using MobileHelper.Models.Tables;
using MobileHelperMaui.Services;
using MobileHelperMaui.Views.TechniquePages.ConstructorPages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace MobileHelper.ViewModels.ConstructorViewModels
{
    public class CreatedViewModel : BaseViewModel
    {
        public ICommand Remove { get; set; }
        public ICommand Edit { get; set; }
        public ObservableCollection<Items> Elements { get; set; }
        private int currentId { get; set; }
        public CreatedViewModel()
        {

        }

        public CreatedViewModel(INavigation navigation, int id)
        {
            this.Title = "Техника";

            this.Navigation = navigation;

            this.Finish = new Command(ToFinish);

            this.Theory = new Command(ToTheory);

            this.Remove = new Command(ToRemove);

            this.Edit = new Command(ToEdit);

            this.Elements = new ObservableCollection<Items>();

            this.currentId = id;

            InitAsync();
        }

        private async void ToEdit(object obj)
        {
            await this.Navigation.PushAsync(new DesignerPage(this.currentId), false);
        }

        private new async void ToFinish(object obj)
        {
            _ = await this.Navigation.PopAsync(false);
        }

        private async void ToRemove(object obj)
        {
            bool result = await DialogService.AskAsync(null, "Вы уверены, что хотите удалить свою технику", "Да", "Нет");

            if (result)
            {
                TechniqueDB item = await DBRepository.GetTechniqueById(this.currentId);

                DBRepository.RemoveTechnique(item);

                MessagingCenter.Send<object, TechniqueDB>(this, "remove", item);

                _ = this.Navigation.PopToRootAsync(false);
            }
        }

        private async void InitAsync()
        {
            TechniqueDB item = await DBRepository.GetTechniqueById(this.currentId);

            if (item == null)
            {
                this.DialogService.ShowAsync("Ошибка", "Не удалось загрузить технику");
                return;
            }

            string[] actions = item.Algorithm.Split('\n');

            foreach (string action in actions)
            {
                this.Elements.Add(new Items
                {
                    Text = action
                });
            }
        }
    }
}
