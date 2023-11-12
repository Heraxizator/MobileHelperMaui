using MobileHelper.Models.Items;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MobileHelper.ViewModels.TechniqueViewModels
{
    public class PolarityViewModel : BaseViewModel
    {
        public ICommand Add { get; set; }
        public string positive { get; set; }
        public string negative { get; set; }
        public bool isFull { get; set; }
        public Polarity polarity { get; set; }
        public ObservableCollection<Polarity> polarities { get; set; }
        public PolarityViewModel()
        {

        }

        public PolarityViewModel(INavigation navigation)
        {
            this.Title = "Техника";
            this.Info = "Любой внутренний конфликт связан с борьбой двух противоположных мотивов, желаний, убеждений или целей. По сути причиной многих духовных проблем являются дуальности. Поэтому работа с полярностями - ещё один путь к освобождению от того, что беспокоит. Но, как правило, далеко не одна пара дуальностей создаёт внутренний конфликт. Их может быть несколько. По этой причине рекомендуется рассматривать побольше возможных пар, связанных с проблемой.";
            this.IsFull = false;
            this.Navigation = navigation;
            this.Finish = new Command(ToFinish);
            this.polarities = new ObservableCollection<Polarity>();
            this.Add = new Command(ToAdd);
            this.Theory = new Command(ToTheory);

        }

        public Command<Polarity> Delete => new Command<Polarity>((item) =>
        {
            _ = this.polarities.Remove(item);
            if (this.polarities.Count == 0)
            {
                this.IsFull = false;
            }
        });

        private void ToAdd(object obj)
        {
            if (!string.IsNullOrEmpty(this.Negative) && !string.IsNullOrEmpty(this.Positive))
            {
                this.IsFull = true;
                Polarity item = new Polarity { Id = "Пара №" + (this.polarities.Count + 1), Positive = this.Positive, Negative = this.Negative };
                this.polarities.Add(item);
                this.Polarity = item;

                this.Negative = "";
                this.Positive = "";
            }

        }

        public string Positive
        {
            get => this.positive;
            set
            {
                if (this.positive != value)
                {
                    this.positive = value;
                    OnPropertyChanged(nameof(this.Positive));
                }
            }
        }

        public string Negative
        {
            get => this.negative;
            set
            {
                if (this.negative != value)
                {
                    this.negative = value;
                    OnPropertyChanged(nameof(this.Negative));
                }
            }
        }

        public bool IsFull
        {
            get => this.isFull;
            set
            {
                if (this.isFull != value)
                {
                    this.isFull = value;
                    OnPropertyChanged(nameof(this.IsFull));
                }
            }
        }

        public Polarity Polarity
        {
            get => this.polarity;
            set
            {
                if (this.polarity != value)
                {
                    this.polarity = value;
                    OnPropertyChanged(nameof(this.Polarity));
                }
            }
        }
    }
}
