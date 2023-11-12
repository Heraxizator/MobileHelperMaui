using MobileHelper.Models.DataItems;
using MobileHelper.Services;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace MobileHelper.ViewModels.CleanViewModels
{
    public class MusicPlayerViewModel : BaseViewModel
    {
        public ObservableCollection<Audio> AllItems { get; set; }
        public ObservableCollection<Audio> SelectedItems { get; set; }
        private string search_text { get; set; }

        public MusicPlayerViewModel()
        {
            this.Title = "Очиститель";

            this.AllItems = new ObservableCollection<Audio>();

            this.SelectedItems = new ObservableCollection<Audio>();

            this.SearchText = string.Empty;

            //CrossMediaManager.Current.MediaItemFinished += OnFinish;

            //CrossMediaManager.Current.MediaItemFailed += OnFailded;

            Init();
        }

        private void Init()
        {
            ObservableCollection<Audio> collection = new ObservableCollection<Audio>()
            {
                new Audio
                {
                    Name = "Псалом 19",
                    Description = "Любовь к Господу",
                    File = "https://azbyka.ru/audio/audio1/Svjashhennoe_pisanie/psaltir_valaam/029-kafizma-3_019.mp3",
                    Loading = false,
                    ClickCommand = this.Execute
                },

                new Audio
                {
                    Name = "Псалом 22",
                    Description = "Любовь к Господу",
                    File = "https://azbyka.ru/audio/audio1/Svjashhennoe_pisanie/psaltir_valaam/032-kafizma-3_022.mp3",
                    Loading = false,
                    ClickCommand = this.Execute
                },

                new Audio
                {
                    Name = "Псалом 26",
                    Description = "Любовь к Господу",
                    File = "https://azbyka.ru/audio/audio1/Svjashhennoe_pisanie/psaltir_valaam/039-kafizma-4_026.mp3",
                    Loading = false,
                    ClickCommand = this.Execute
                },

                new Audio
                {
                    Name = "Псалом 33",
                    Description = "Любовь к Господу",
                    File = "https://azbyka.ru/audio/audio1/Svjashhennoe_pisanie/psaltir_valaam/049-kafizma-5_033.mp3",
                    Loading = false
                },

                new Audio
                {
                    Name = "Псалом 50",
                    Description = "Очищение от бесов",
                    File = "https://azbyka.ru/audio/audio1/Svjashhennoe_pisanie/psaltir_valaam/072-kafizma-7_050.mp3",
                    Loading = false,
                    ClickCommand = this.Execute

                },

                new Audio
                {
                    Name = "Псалом 90",
                    Description = "Господи, помилуй",
                    File = "https://azbyka.ru/audio/audio1/Svjashhennoe_pisanie/psaltir_valaam/127-kafizma-12_090.mp3",
                    Loading = false,
                    ClickCommand = this.Execute
                },
            };

            InitItems(collection);
        }

        private void InitItems(ObservableCollection<Audio> collection)
        {
            foreach (Audio item in collection)
            {
                this.SelectedItems.Add(item);

                this.AllItems.Add(item);
            }
        }

        public ICommand Execute => new Command<string>(file => ToExecute(file));

        private void HideAll()
        {
            for (int i = 0; i < this.SelectedItems.Count; i++)
            {
                Audio element = this.SelectedItems.ElementAt(i);

                element.Loading = false;

                this.SelectedItems[i] = element;
            }
        }

        private void OnFinish(object sender, EventArgs e)
        {
            HideAll();
        }

        private void OnFailded(object sender, EventArgs e)
        {
            DialogService.ShowAsync("Mobile Helper", "Не удалось загрузить аудио");
        }

        private void ToSearch(string input)
        {
            if (this.SelectedItems == null)
            {
                return;
            }

            this.SelectedItems.Clear();

            string target = input.ToUpper();

            foreach (Audio item in this.AllItems)
            {
                string name = item.Name.ToUpper();

                string describtion = item.Description.ToUpper();

                if (name.Contains(target) || describtion.Contains(target))
                {
                    this.SelectedItems.Add(item);
                }
            }
        }

        private void ToExecute(string file)
        {
            HideAll();

            Audio item = this.SelectedItems.FirstOrDefault(x => x.File == file);

            int index = this.SelectedItems.IndexOf(item);

            if (item.Playing)
            {
                item.Loading = false;

                item.Playing = false;

                this.SelectedItems[index] = item;

                //_ = CrossMediaManager.Current.Stop();
            }

            else
            {
                item.Loading = true;

                item.Playing = true;

                this.SelectedItems[index] = item;

                //_ = CrossMediaManager.Current.Play(file);
            }
        }

        public string SearchText
        {
            get => this.search_text;
            set
            {
                if (this.search_text != value)
                {
                    this.search_text = value;
                    ToSearch(this.search_text);
                    OnPropertyChanged(nameof(this.SearchText));
                }
            }
        }
    }
}
