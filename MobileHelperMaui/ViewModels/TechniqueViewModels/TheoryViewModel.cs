namespace MobileHelper.ViewModels.TechniqueViewModels
{
    public class TheoryViewModel : BaseViewModel
    {
        private string text { get; set; }
        public TheoryViewModel()
        {

        }

        public TheoryViewModel(string content)
        {
            this.Title = "Теория";
            this.Text = content;

        }

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
    }
}
