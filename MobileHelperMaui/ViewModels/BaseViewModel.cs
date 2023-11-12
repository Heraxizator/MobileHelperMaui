using MobileHelper.Services;
using MobileHelperMaui.Services.Interfaces;
using MobileHelperMaui.Views.TechniquePages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;


namespace MobileHelper.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public IDialog DialogService = new DialogService();
        public INavigation Navigation { get; set; }
        public ICommand Finish { get; set; }
        public ICommand Theory { get; set; }
        public string Info { get; set; }

        private string title = string.Empty;
        public string Title
        {
            get => this.title;
            set => SetProperty(ref this.title, value);
        }

        public async void ToTheory(object obj)
        {
            await this.Navigation.PushAsync(new TheoryPage(this.Info), false);
        }

        public async void ToFinish(object obj)
        {
            _ = await this.Navigation.PopAsync(false);
        }

        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName] string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
            {
                return false;
            }

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChangedEventHandler changed = PropertyChanged;
            if (changed == null)
            {
                return;
            }

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
