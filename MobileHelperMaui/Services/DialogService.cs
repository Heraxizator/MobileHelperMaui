using MobileHelperMaui;
using MobileHelperMaui.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MobileHelper.Services
{
    public class DialogService : IDialog
    {
        public void ShowAsync(string title, string message)
        {
            App.Current.MainPage.DisplayAlert(title, message, "Ok");
        }

        public async Task<bool> AskAsync(string title, string message, string accept, string cancel)
        {
            bool result = await App.Current.MainPage.DisplayAlert(title, message, accept, cancel);

            return result;
        }
    }
}
