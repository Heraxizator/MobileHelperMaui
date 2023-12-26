using MobileHelper.Models.Items;
using MobileHelperMaui.Views.TechniquePages;

namespace MobileHelperMaui.Services.DataStores
{
    public static class TechniquesDataStore
    {
        private static readonly string image = "technique.png";
        public static IEnumerable<TechniqueItem> GetStaticTechniques(INavigation navigation)
        {
            List<TechniqueItem> items = new()
            {
                new TechniqueItem
                {
                    Number = "Техника №1",
                    Date="26.01.2023",
                    Image = image,
                    Title = "Крутилка",
                    Subtitle = "Метод мгновенной нейтрализации травм и шоков",
                    Theme = "Эпизоды",
                    Author = "Живорад Славинский",
                    Active = true,
                    TapCommand = new Command(async () => await navigation.PushAsync(new SpinPage(), false))
                },

                new TechniqueItem
                {
                    Number = "Техника №2",
                    Date="26.01.2023",
                    Image = image,
                    Title = "Сравнение важностей",
                    Subtitle = "Прошлое, настоящее и будущее",
                    Theme = "Важность",
                    Author = "НЛП",
                    Active = true,
                    TapCommand = new Command(async () => await navigation.PushAsync(new ComparisonPage(), false))
                },
                new TechniqueItem
                {
                    Number = "Техника №3",
                    Date="26.01.2023",
                    Image = image,
                    Title = "Полярности",
                    Subtitle = "Работа с противоположными аспектами",
                    Theme = "Аспекты",
                    Author = "Живорад Славинский",
                    Active = true,
                    TapCommand = new Command(async () => await navigation.PushAsync(new PolarityPage(), false))
                },
                new TechniqueItem
                {
                    Number = "Техника №4",
                    Date="26.01.2023",
                    Image = image,
                    Title = "Лист бумаги",
                    Subtitle = "Быстрое очищение от негативных мыслей",
                    Theme = "Мысли",
                    Author = "Психика",
                    Active= true,
                    TapCommand = new Command(async () => await navigation.PushAsync(new PaperPage(), false))
                },
                new TechniqueItem
                {
                    Number = "Техника №5",
                    Date="30.01.2023",
                    Image = image,
                    Title = "50 лет спустя",
                    Subtitle = "Понижение важности за 10 секунд",
                    Theme = "Важность",
                    Author = "НЛП",
                    Active = true,
                    TapCommand = new Command(async () => await navigation.PushAsync(new FuturePage(), false))
                },

                new TechniqueItem
                {
                    Number = "Техника №6",
                    Date="30.01.2023",
                    Image = image,
                    Title = "Протокол Руби",
                    Subtitle = "Ликвидация любых привязанностей, зависимостей и привычек",
                    Theme = "Обработчик",
                    Author = "Турбо-Суслик",
                    Active = true,
                    TapCommand = new Command(async () => await navigation.PushAsync(new HackPage(), false))
                },

                new TechniqueItem
                {
                    Number = "Техника №7",
                    Date="08.02.2023",
                    Image = image,
                    Title = "Модификация опыта",
                    Subtitle = "Проработка ограничений, убеждений и моделей поведения",
                    Theme = "Эпизоды",
                    Author = "Филипп Славинский",
                    Active = true,
                    TapCommand = new Command(async () => await navigation.PushAsync(new ExperiencePage(), false))
                }
            };

            return items;
        }
    }
}
