using MobileHelper.Services;
using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MobileHelper.ViewModels.ReviewViewModels
{
    public class FormViewModel : BaseViewModel
    {
        public ICommand Send { get; set; }
        private string message_text { get; set; }
        private const string recipient_number = "89142107907";
        public FormViewModel()
        {
            this.Title = "Отзовик";

            this.MessageText = string.Empty;

            this.Send = new Command(async () =>
            {
                if (string.IsNullOrEmpty(this.MessageText))
                {
                    return;
                }

                await SendSms(this.MessageText, recipient_number);
            });
        }

        public async Task SendSms(string messageText, string recipient)
        {
            try
            {
                SmsMessage message = new(messageText, new[] { recipient });
                await Sms.Default.ComposeAsync(message);
            }
            catch (FeatureNotSupportedException)
            {
                DialogService.ShowAsync("Mobile Helper", "Отправка СМС не поддерживается");
            }
            catch (Exception)
            {
                DialogService.ShowAsync("Mobile Helper", "Ошибка при отправке СМС");
            }
        }

        public string MessageText
        {
            get => this.message_text;
            set
            {
                if (this.message_text != value)
                {
                    this.message_text = value;
                    OnPropertyChanged(nameof(this.MessageText));
                }
            }
        }
    }
}
