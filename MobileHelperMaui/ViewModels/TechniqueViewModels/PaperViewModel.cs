using MobileHelper.Models.DataItems;
using MobileHelper.ViewModels;
using MobileHelper.ViewModels;
using System.Collections.ObjectModel;

namespace MobileHelperMaui.ViewModels.TechniqueViewModels
{
    public class PaperViewModel : BaseViewModel
    {
        public string text { get; set; }
        public bool isFull { get; set; }
        private Paper paper { get; set; }
        public ObservableCollection<Paper> papers { get; set; }
        public Command Add { get; set; }
        public PaperViewModel()
        {

        }

        public PaperViewModel(INavigation navigation)
        {
            this.Title = "Техника";
            this.Info = "Учёные провели эксперимент и выявили одну замечательную закономерность: если взять лист бумаги, записать свои негативные мысли и выбросить этот лист, то тот негатив потеряют какое-либо значение для человека и перестанет его беспокоить. Но для такой практики совершенно необязательно тратить бумагу. Можно просто воспользоваться текстовым редактором на следующей странице. Техника проста до безобразия!";
            this.Navigation = navigation;
            this.Finish = new Command(ToFinish);
            this.Theory = new Command(ToTheory);
            this.papers = new ObservableCollection<Paper>();
            this.Add = new Command(ToAdd);
        }

        private void ToAdd(object obj)
        {
            if (!string.IsNullOrEmpty(this.Text))
            {
                this.IsFull = true;
                Paper item = new() { Id = "Карточка №" + (this.papers.Count + 1), Text = this.Text };
                this.papers.Add(item);
                this.Paper = item;

                this.Text = "";
            }

        }

        public Command<Paper> Delete => new((item) =>
        {
            _ = this.papers.Remove(item);
            if (this.papers.Count == 0)
            {
                this.IsFull = false;
            }
        });


        public string Text
        {
            get => this.text;
            set
            {
                if (this.text != value)
                {
                    this.text = value;
                    OnPropertyChanged(nameof(this.Text));
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
        public Paper Paper
        {
            get => this.paper;
            set
            {
                if (this.paper != value)
                {
                    this.paper = value;
                    OnPropertyChanged(nameof(this.Paper));
                }
            }
        }
    }
}
