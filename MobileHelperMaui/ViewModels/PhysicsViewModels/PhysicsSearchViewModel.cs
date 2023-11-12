using MobileHelper.Models.Items;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace MobileHelper.ViewModels.PhysicsViewModels
{
    public class PhysicsSearchViewModel : BaseViewModel
    {
        public Dictionary<string, List<Reason>> Reasons { get; set; }
        public ObservableCollection<Reason> Results { get; set; }
        private bool _empty { get; set; }
        private bool _full { get; set; }
        public enum State
        {
            Empty,
            Full
        }

        public PhysicsSearchViewModel(INavigation navigation)
        {
            this.Title = "Поиск";

            this.Navigation = navigation;

            this.Reasons = new Dictionary<string, List<Reason>>();

            InitReasons();

            this.Results = new ObservableCollection<Reason>(this.Reasons.Values.Select(x => x.First()).ToArray());
        }

        private void InitReasons()
        {
            this.Reasons.Add("спина", new List<Reason>()
            {
                new Reason {Header = "Причина №1", Describtion = "Человек пытается самостоятельно решить свои проблемы, взваливает «непосильную ношу на свою спину», боится попросить о помощи близких людей или же просто выговориться." },
                new Reason {Header = "Причина #2", Describtion = "Боязнь признаться в своем страхе даже себе."}
            });

        }

        private void SetDefault()
        {
            this.IsEmpty = false;
            this.IsFull = false;
        }

        private void SetState(State state)
        {
            SetDefault();

            switch (state)
            {
                case State.Empty:
                    this.IsEmpty = true;
                    this.IsFull = false;
                    break;

                case State.Full:
                    this.IsEmpty = false;
                    this.IsFull = true;
                    break;
            }
        }

        public void ExecuteSearch(string input)
        {
            string text = input.ToLower();

            if (this.Reasons.ContainsKey(text))
            {
                this.Results.Clear();

                List<Reason> items = this.Reasons[text];

                foreach (Reason item in items)
                {
                    this.Results.Add(item);
                }
            }
        }

        public PhysicsSearchViewModel() { }

        public bool IsEmpty
        {
            get => this._empty;
            set
            {
                this._empty = value;
                OnPropertyChanged(nameof(this.IsEmpty));
            }
        }

        public bool IsFull
        {
            get => this._full;
            set
            {
                this._full = value;
                OnPropertyChanged(nameof(this.IsFull));
            }
        }
    }
}
